import { makeObservable, makeAutoObservable, observable, computed, action, runInAction } from 'mobx';
import agent from '../api/agent';
import { v4 as uuid } from 'uuid';
import { Bid ,BidFormValues} from '../bid';
import { Loader } from 'semantic-ui-react';
import { format } from 'date-fns';
export default class bidStore {
  bidRegistry = new Map<string, Bid>();

  selectedBid: Bid | undefined = undefined;
  editMode = false;
  loading = false;
  loadingInitial = false;

  constructor() {
    makeAutoObservable(this);
  }


  updateBid = async (bid: Bid) => {
    try {
      await agent.Bids.update(bid);
      runInAction(() => {
        if (bid.id) {
          const updatedBid = { ...this.getBid(bid.id), ...bid };
          this.bidRegistry.set(bid.id, updatedBid as Bid);
          this.selectedBid = updatedBid as Bid;
        }
      });
    } catch (error) {
      console.log(error);
    }
  };

  get bidsByDate() {
    return Array.from(this.bidRegistry.values()).sort(
      (a, b) => a.date.getTime() - b.date.getTime()
    );
  }
 
  get groupedBids() {
	return Object.entries(
		this.bidsByDate.reduce((bids, bid) => {
		//	const date = bid.date.toISOString().split('T')[0];
    const date=format(bid.date!,'dd MMM yyyy');
			bids[date] = bids[date] ? [...bids[date], bid] : [bid];
			return bids;
		}, {} as {[key: string]: Bid[]})
	)
}

loadBid = async (id: string) => {
  let bid = this.getBid(id);
  if (bid) {
      this.selectedBid = bid;
      return bid;
  } else {
      this.loadingInitial = true;
      try {
          bid = await agent.Bids.details(id);
          this.setBid(bid!);
          runInAction(() => {
              this.selectedBid = bid;
          })
          this.setLoadingInitial(false);
          return bid;
      } catch (error) {
          console.log(error);
          this.setLoadingInitial(false);
      }
  }
}



  loadBids = async () => {
    this.setLoadingInitial(true);

    try {
      const bids = await agent.Bids.list();
      //   console.log("THESE BIDS")
      //    console.log(bids);
      bids.forEach((bid: Bid) => {
        this.setBid(bid);
   //     bid.date = bid.date.split("T")[0];
    //    this.bidRegistry.set(bid.id, bid);
      });
      this.setLoadingInitial(false);
    } catch (error) {
      console.log(error);
      this.setLoadingInitial(false);
    }
  };

  setLoadingInitial = (state: boolean) => {
    this.loadingInitial = state;
  };

  selectBid = (id: string) => {
    this.selectedBid = this.bidRegistry.get(id);
  };

  cancelSelectedBid = () => {
    this.selectedBid = undefined;
  };
  openForm = (id?: string) => {
    id ? this.selectBid(id) : this.cancelSelectedBid();
    this.editMode = true;
  };
  closeForm = () => {
    this.editMode = false;
  };

  createBid = async (bid: Bid) => {
    this.loading = true;
    bid.id = uuid();
    try {
      await agent.Bids.create(bid);
   //   const newBid = new Bid(bid);
     // this.setBid(newBid);
      runInAction(() => {
        this.bidRegistry.set(bid.id, bid);
        this.selectedBid = bid;
        this.editMode = false;
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loading = false;
      });
    }
  };


  private setBid = (bid: Bid) => {
    bid.date = new Date(bid.date!);
    this.bidRegistry.set(bid.id, bid);
  };

  private getBid = (id: string) => {
    return this.bidRegistry.get(id);
}


  deleteBid = async (id: string) => {
    this.loading = true;
    try {
      await agent.Bids.delete(id);
      runInAction(() => {
        this.bidRegistry.delete(id);
        if (this.selectedBid?.id === id) this.cancelSelectedBid();
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loading = false;
      });
    }
  };
}

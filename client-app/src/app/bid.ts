export interface Bid {
  id: string;
  bidAmount: string;
  productId: string;
  sellerId: string;
  category:string;
  buyerId:string;
  date: Date ;
}
export class Bid implements Bid {
  constructor(init?: BidFormValues) {
    Object.assign(this, init);
  }
}

export class BidFormValues {
  id?: string = undefined;
  bidAmount: string = "";
  productId: string = "";
  sellerId: string = "";
  buyerId: string = "";
  category:string="";
  date: Date | null = null;

  constructor(bid?: BidFormValues) {
    if (bid) {
      this.id = bid.id;
      this.bidAmount = bid.bidAmount;
      this.productId = bid.productId;
      this.sellerId = bid.sellerId;
      this.buyerId=bid.buyerId;
      this.category=bid.category;
      this.date = bid.date;
    }
  }
}

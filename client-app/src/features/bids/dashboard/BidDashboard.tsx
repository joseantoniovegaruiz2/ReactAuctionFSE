import React , {useEffect}from 'react';
import { Grid, List } from 'semantic-ui-react';
import BidDetails from '../details/BidDetails';
import BidForm from '../form/BidForm';
import BidList from './BidList';
import  {useStore}  from '../../../app/stores/store';
import {observer} from 'mobx-react-lite';
import LoadingComponent from '../../../app/layout/LoadingComponent';




export default observer (function BidDashBoard() {
        const {bidStore}=useStore();

        

        useEffect(() => {
          bidStore.loadBids();
          //  console.log("APPBIDS");
          //  console.log(bidStore.bids);
          // console.log("APPBIDSEND");
        }, [bidStore]);
      
        if (bidStore.loadingInitial)
          return <LoadingComponent content="Loading app" />;

    return (
        <Grid>
            <Grid.Column width='10'>
                <BidList/>
            </Grid.Column>
            <Grid.Column width='6'>
                <h2>Bid filters</h2>
            </Grid.Column>
        </Grid>
    )
})
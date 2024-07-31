import React, { Fragment } from "react";
import { Header } from "semantic-ui-react";
import { Bid } from "../../../app/bid";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { useState } from "react";
import BidListItem from "./BidListItem";

export default observer(function BidList() {
  const { bidStore } = useStore();
  const { groupedBids } = bidStore;
  return (
    <>
      {groupedBids.map(([group, bids]) => (
        <Fragment key={group}>
          <Header sub color="teal">
            {group}
          </Header>
          {bids.map((bid) => (
            <BidListItem key={bid.id} bid={bid} />
          ))}
        </Fragment>
      ))}
    </>
  );
});

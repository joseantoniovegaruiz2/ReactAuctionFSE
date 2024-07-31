import React,{useEffect} from "react";
import { Card, Icon, Image, Button } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useParams, Link } from 'react-router-dom';
import {observer} from 'mobx-react-lite';


export default observer( function BidDetails() {
  const { bidStore } = useStore();
  const {
    selectedBid: bid,
    openForm,
    cancelSelectedBid,
    loadBid,
    loadingInitial,
  } = bidStore;
  const { id } = useParams<{ id: string }>();
  useEffect(() => {
    if (id) loadBid(id);
  }, [id, loadBid]);

  if (loadingInitial || !bid) return <LoadingComponent />;
  return (
    <Card fluid>
      <Card.Content>
        <Card.Header>{bid.productId}</Card.Header>

        <Card.Description>{bid.sellerId}</Card.Description>
        <Card.Description>{bid.buyerId}</Card.Description>
        <Card.Description>{bid.category}</Card.Description>
        <Card.Description>{bid.bidAmount}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group widths="2">
          <Button
           as ={Link}  to={`/manage/${bid.id}`}
            basic
            color="blue"
            content="Edit"
          />
          <Button
             as ={Link}  to={'/bids'}
            basic
            color="grey"
            content="Cancel"
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
})

import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Icon, Item, Segment,Label } from 'semantic-ui-react';
import { Bid } from '../../../app/bid';
import {format} from 'date-fns';
import HomePage from '../../Home/HomePage';

interface Props {
    bid: Bid
}

export default function BidListItem({ bid }: Props) {

    return (
        
        <Segment.Group>
            <Segment>
            <span>
                    <Label as='a' basic>Category <Icon name='sitemap' /></Label>
                     {bid.category}
                </span>
            </Segment>
            <Segment>
            <span>
                    <Label as='a' basic>Product Id <Icon name='product hunt' /></Label>
                     {bid.productId}
                </span>
            </Segment>
            <Segment>
                <span>
                <Label as='a' basic>Bid Date <Icon name='clock' /></Label>
                     {format(bid.date!, 'dd MMM yyyy h:mm aa')}
                <Label as='a' basic>Bid Amount <Icon name='dollar sign' /></Label>
                    {bid.bidAmount}
                   

                </span>
            </Segment>
         
            <Segment clearing>

                <span>
                    <Label as='a' basic>Seller Id <Icon name='buysellads' /></Label>
                    {bid.sellerId}
                </span>
                <span>
                    <Label as='a' basic>Buyer Id <Icon name='shopping cart' /></Label>
                    {bid.buyerId}
                </span>
                <Button 
                    as={Link}
                    to={`/bids/${bid.id}`}
                    color='teal'
                    floated='right'
                    content='View'
                />
            </Segment>
        </Segment.Group>
    )
}
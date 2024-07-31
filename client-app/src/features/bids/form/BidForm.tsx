import React, { useEffect, useState, ChangeEvent } from "react";
import { Link, useHistory, useParams } from 'react-router-dom';
import { Segment, Header, Button, Label } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { BidFormValues } from "../../../app/bid";
import { v4 as uuid } from "uuid";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import MyTextIinput from "../../../app/common/form/MyTextInput";
import { Bid } from "../../../app/bid";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import MySelectInput from '../../../app/common/form/MySelectInput';
import { categoryOptions } from '../../../app/common/options/categoryOptions';

export default observer(function BidForm() {
  const history = useHistory();
  const { bidStore } = useStore();
  const {  createBid, updateBid, loading, loadBid, loadingInitial } = bidStore;
  const { id } = useParams<{ id: string }>();


  const validationSchema = Yup.object({
    productId: Yup.string().required("The ProductId is required for the Bid"),
    sellerId: Yup.string().required("The sellerId is required for the Bid"),
    buyerId: Yup.string().required("The buyerId is required for the Bid"),
    bidAmount: Yup.string().required("The bidAmount is required for the Bid"),
  });

  //const [bid, setBid] = useState<Bid>(initialState);

  const [bid, setBid] = useState<Bid>({
    id: "",
    productId: "",
    sellerId: "",
    buyerId: "",
    bidAmount: "",
    category: "",
    date: new Date(),
  });

  useEffect(() => {
    if (id) loadBid(id).then((bid) => setBid(bid!));
  }, [id, loadBid]);

  function handleFormSubmit(bid: Bid) {
    //bid.id? updateBid(bid):createBid(bid);
    if (!bid.id) {
      const newBid = {
        ...bid,
        id: uuid(),
      };
      createBid(newBid).then(()=>history.push(`/bids/${newBid.id}`));
    } else {
      updateBid(bid).then(() => history.push(`/bids/${bid.id}`));
    }
  }



  if (loadingInitial) return <LoadingComponent content="Loading Bid" />;

  return (
    <Segment clearing>
      <Header content='Bid Details' sub color='teal'/>
      <Formik
        validationSchema={validationSchema}
        enableReinitialize
        initialValues={bid}
        onSubmit={(values) =>handleFormSubmit(values)}
      >
        {({ handleSubmit,isValid,isSubmitting,dirty }) => (
          <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
            <MyTextIinput name="productId" placeholder="productId" />
            <MyTextIinput placeholder="buyerId" name="buyerId" />
            <MyTextIinput placeholder="sellerId" name="sellerId" />
            <MySelectInput options={categoryOptions} placeholder='Category' name='category' />
            <MyTextIinput placeholder="bidAmount" name="bidAmount" />
            <Button
              disabled={isSubmitting||!dirty||!isValid}
              loading={loading}
              floated="right"
              positive
              type="submit"
              content="Submit"
            />

            <Button
              as={Link}
              to={"/bids"}
              basic
              color="grey"
              content="Cancel"
            />
          </Form>
        )}
      </Formik>
    </Segment>
  );
});

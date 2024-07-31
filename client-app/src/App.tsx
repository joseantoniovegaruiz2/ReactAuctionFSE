import React, { Fragment, useEffect } from "react";

import "./App.css";
import axios from "axios";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import BidDashBoard from "./features/bids/dashboard/BidDashboard";
import LoadingComponent from "./app/layout/LoadingComponent";

import { v4 as uuid } from "uuid";
import { useStore } from "./app/stores/store";
import { observer } from "mobx-react-lite";
import HomePage from "./features/Home/HomePage";
import { useLocation } from "react-router-dom";
import { BrowserRouter, Route,Switch} from 'react-router-dom';

import BidForm from "./features/bids/form/BidForm";
import BidDetails from "./features/bids/details/BidDetails";
import TestErrors from "./features/errors/TestError";

import {ToastContainer} from 'react-toastify';
import NotFound from './features/errors/NotFound';









function App() {
  const location = useLocation();

  return (
    <>
     <ToastContainer position='bottom-right' hideProgressBar />
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <>
            <NavBar />
            <Container style={{ marginTop: "7em" }}>
              <Switch>
                <Route exact path="/" component={HomePage} />
                <Route exact path="/bids" component={BidDashBoard} />
                <Route path="/bids/:id" component={BidDetails} />
                <Route path={['/createBid','/manage/:id']} component={BidForm} />
                <Route path='/errors' component={TestErrors}/>
                <Route  component={NotFound}/>
              </Switch>
            </Container>
          </>
        )}
      />
    </>
  );
}

export default observer(App);

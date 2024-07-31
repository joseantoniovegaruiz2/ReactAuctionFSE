import {createContext,useContext} from 'react';
import BidStore from "./bidStore";
import CommonStore from "./commonStore";


interface Store {
    bidStore:BidStore;
    commonStore: CommonStore;

}
export const store:Store={
    bidStore: new BidStore(),
    commonStore: new CommonStore()

}

export const StoreContext=createContext(store);

export function useStore(){

    return useContext(StoreContext);
}
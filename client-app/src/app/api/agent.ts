import axios, { AxiosError, AxiosResponse } from 'axios';
import {Bid} from '../bid';
import { store } from '../stores/store';
import { toast } from 'react-toastify';
import { history } from '../..';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import TestErrors from '../../features/errors/TestError';



/*axios.defaults.baseURL = 'https://auctionrestfse.azurewebsites.net'*/

//axios.defaults.baseURL = 'http://localhost:5001';
axios.defaults.baseURL=process.env.REACT_APP_API_URL;
//  https://localhost:5000/e-auction/api/v1/seller/show-bids/

const sleep     =(delay :number)=>{
    return new Promise((resolve)=>{
        setTimeout(resolve, delay);
    })

}



axios.interceptors.response.use(async response => {
  if(process.env.NODE_ENV==='development')  await sleep(1000);
    return response;
}, (error: AxiosError) => {
    const {data,status} = error.response!;

    switch (status) {
        case 400:
          
            if (data.errors) {
                const modalStateErrors = [];
                for (const key in data.errors) {
                    if (data.errors[key]) {
                        modalStateErrors.push(data.errors[key])
                    }
                }
                throw modalStateErrors.flat();
            } else {
                toast.error(data);
                
            }
            break;
            case 401:
                toast.error('unauthorised');
                break;
            case 404:
                history.push('not found');
                break;
            case 500:
                history.push('/server-error');
                break;
        }
        return Promise.reject(error);
    })


    const responseBody = <T>(response: AxiosResponse<T>) => response.data;

//const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post:<T> (url: string, body: {}) => axios.post<T>(url,body).then(responseBody),
    put: <T>(url: string, body:{}) => axios.put<T>(url,body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
}

const Bids = {


    list: () => requests.get<Bid[]>('/e-auction/api/v1/seller/show-bids'),
    details:(id:string)=>requests.get<Bid>(`/e-auction/api/v1/seller/show-bids/${id}`),
    create:(bid:Bid)=>requests.post<void>('/e-auction/api/v1/seller/add-bid',bid),
    update:(bid:Bid)=>axios.put<void>(`/e-auction/api/v1/buyer/update-bid/${bid.id}`,bid),
    delete:(id:string)=>axios.delete<void>(`/e-auction/api/v1/Bids/${id}`)
   // log(list.bids.length);
}

const agent = {
        Bids
}
export default agent;
import {makeObservable,observable} from 'mobx';

export default class productStore{
    title='Hello world';
    constructor(){
        makeObservable(this,{
            title:observable
        })
    }
}
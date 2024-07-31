import { useField } from 'formik';
import React from 'react';
import { Select,Form, Label } from 'semantic-ui-react';


interface Props{
    placeholder:string;
    options:any;
    name:string;
    label?:string;
}
export default function MySelectInput(props:Props){
    const [field,meta,helpers]=useField(props.name);
    return (
        <Form.Field error={meta.touched&&!!meta.error}>
                <label>{props.label}</label>
                <Select
                        clearable
                        options ={props.options} 
                        value={field.value}
                        onChange={(e,d)=>helpers.setValue(d.value)}
                        onBlur={()=>helpers.setTouched(true)}
                        placeholder={props.placeholder}

                        
                />
                {meta.touched&&meta.error?(
                <Label basic color='red'>{meta.error}</Label>
                ):null}
        </Form.Field>
    )


}
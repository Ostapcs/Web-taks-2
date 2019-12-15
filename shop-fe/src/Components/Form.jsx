import React from "react";
import Input from "./Input";

class Form extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            inputConfig: props.inputConfig,
            validatedObjects: {}
        }
    }


    onSubmit = () => {
        const formData = this.props.baseState.formData;
        let validatedObjects = {};
        Object.values(this.state.inputConfig).map((config) => {
            validatedObjects = Object.assign({}, validatedObjects);
            if (config.hasOwnProperty('required')) {
                if (formData.hasOwnProperty(config.name)) {
                    validatedObjects[config.name] = formData[config.name].toString().trim() !== "";
                } else {
                    validatedObjects[config.name] = false
                }
            } else {
                validatedObjects[config.name] = true;
            }

        });
        //console.log(validatedObjects);
        this.props.setBaseState({validatedObjects: validatedObjects});

        if (!Object.values(validatedObjects).includes(false)) {
            this.props.onSubmit();
        }
        // this.props.onSubmit();

    };

    render() {
        return <form ref={this.props.ref} autoComplete={'off'} >
            {this.props.inputConfig.map((_inputConfig) => {
                return <Input
                    setBaseState={this.props.setBaseState}
                    baseState={this.props.baseState}
                    data={_inputConfig}
                    isValid={this.props.baseState.validatedObjects[_inputConfig.name]}
                />
            })}
            {/*<input type={'reset'} value={'Reset'}/>*/}
            <button className='submit-button btn btn-success' onClick={this.onSubmit} type="button">Submit</button>
        </form>
    }
}

export default Form;
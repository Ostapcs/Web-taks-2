import React from "react";

class Input extends React.Component {
    constructor(props) {
        const {
            name,
            value,
            placeholder,
            type,
            required,
            cssClass,
            data,
            checked,
            label,
            disabled,
            labelCss,
            errorMessage,
            min,
        } = props.data;
        super(props);
        this.state = {
            inputData: {
                name: name,
                val: value,
                placeholder: placeholder,
                label: label,
                type: type,
                required: required,
                cssClass: cssClass,
                data: data,
                checked: checked,
                disabled: disabled,
                labelCss: labelCss,
                errorMessage: errorMessage,
                min: min
            }
        };
        this.inputRef = React.createRef();
    }


    onChange = async (e) => {
        //e.preventDefault();
        let formData = Object.assign({}, this.props.baseState.formData);
        const input = this.inputRef.current;
        if (this.state.inputData.type === 'checkbox' && !input.checked) {
            delete formData[e.target.name];
            await this.props.setBaseState({selectedRow: "", formData: formData});
            return;
        }
        else if(this.state.inputData.type === 'file') {
            formData[e.target.name] = e.target.files[0];
            await this.props.setBaseState({selectedRow: "", formData: formData});
            return;
        }

        formData[e.target.name] = e.target.value;

        await this.props.setBaseState({selectedRow: "", formData: formData});

    };

    render() {
        const isValid = this.props.isValid;
        const {value, checked, disabled, min} = this.props.data;
        const {name, placeholder, type, required, cssClass, data, label, labelCss, errorMessage} = this.state.inputData;
        return <div className={'answers'}>
            {label && <div>

                <label className={labelCss}>
                    {label}
                </label>
                {isValid === false && <div style={{color: 'red'}}>{errorMessage}</div>}
            </div>}

            <div>

                <input
                    ref={this.inputRef}
                    // className={cssClass === '' ? cssClass : "form-control"}
                    className={cssClass === '' ? '' : cssClass}
                    name={name}
                    value={value}
                    placeholder={placeholder}
                    onChange={this.onChange}
                    type={type}
                    required={required}
                    checked={checked}
                    disabled={disabled}
                    min={min}
                    // required
                /> {data}
                <br/>
            </div>
        </div>
    }
}

export default Input;
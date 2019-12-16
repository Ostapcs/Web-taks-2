import React from "react";

class Table extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: props.data,
            additionalHeader: "",
            ActionColumn: "",
            headers: [],
            rowData: [],
        };

    }

    formHeaders(headers) {
        if(!headers) return ;
        let rowData = headers.map((header) => <th>{header}</th>);
        return <tr>{rowData}</tr>;
    }

    formRows(response) {
        if (response === undefined || response.length === 0) {
            return;
        }

        let formattedData = [];

        for (let i of response) {
            formattedData.push(Object.values(i));
        }

        return formattedData.map((quiz) => {
            let row = quiz.map((info) => <td style={{textAlign: 'center'}}
                                             >{typeof (info) === 'object' ? info : info.toString()}</td>);
            return <tr >{row}</tr>;
        });
    }

    render() {
        return <div style={{margin: '2%'}}>
            <table className="table table-bordered table-hover">
                <thead>
                {this.formHeaders(this.props.headers)}
                </thead>
                <tbody>
                {this.formRows(this.props.data)}
                </tbody>
            </table>
        </div>
    }
}

export default Table;
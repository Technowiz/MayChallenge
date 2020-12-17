import React, { Component } from 'react'
import { MDBContainer, MDBRow, MDBCol, MDBBtn, MDBInput ,MDBTable, MDBTableBody, MDBTableHead } from 'mdbreact';
import {insertRecurrence,fetchALL} from '../util/restutil'
import axios from "axios";
class Schedule extends Component {
    state = {
        id: null,
        name:null,
        type:null, 
        startDate:"", 
        endDate:"", 
        recurringday:"",
        recurrences:[]
    };
    
    componentDidMount(){
        axios.get("https://localhost:44339/api/Schedules")
        .then(response => {
            const data = response.data
            this.setState({recurrences: [...data]})
        })//[{name: "meeting1",type:"Daily", startDate: "2020:12:22", endDate :"2020:12:22"}]
        //this.setState({recurrences: [...recurrences]})
        console.log(this.state.recurrences)
    }

    handleChange = (e) => {
        console.log(e.target.id,e.target.value)
        this.setState({
            [e.target.id]: e.target.value
        })
    }
    edit = (id) => {
        let recur = this.state.recurrences.find(obj => obj.id === id)
        console.log(recur)
        this.setState({id: recur.id,
            name : recur.name ,
            type : recur.type ,
            startDate : recur.startDate,
            endDate : recur.endDate,
            recurringday : recur.recurringday
        })
    }

    delete = (id) => {
        axios.delete("https://localhost:44339/api/Schedules/"+ id)
        .then((response) => {
            if(response.status = 200){
                const resur = this.state.recurrences.filter(obj => obj.id != id)
                this.setState({recurrences: [...resur]})
            }
        })
    }

    handleSubmit = (e) => {
        e.preventDefault();
        let newRecurence = {
            id :this.state.id,
            name: this.state.name, 
            type: this.state.type,
            startDate: this.state.startDate,
            endDate: this.state.endDate,
            recurringday: this.state.recurringday
        }
        console.log(newRecurence)
        this.setState({recurrences:[...this.state.recurrences, newRecurence]})
        if(this.state.id==null)
        {
            //TODO use axios to update in the db
            insertRecurrence(newRecurence)
            
        }
        else
        {
            axios.put("https://localhost:44339/api/Schedules/"+newRecurence.id,newRecurence)
            .then(response => {
                if(response.status = 200){
                    const resur = this.state.recurrences.filter(obj => obj.id != newRecurence.id)
                    this.setState({recurrences: [...resur,newRecurence]})
                }
            })
 
        }
        axios.get("https://localhost:44339/api/Schedules")
            .then(response => {
                const data = response.data
                this.setState({recurrences: [...data]})
            })

        console.log(this.state.name)
        console.log(this.state.recurrences)
    }

    handleServerUpdate(type, payload){
    }



    renderTable(){
        console.log("called")
        return this.state.recurrences.map((listValue, index) => {
            return (
              <tr key={index}>
                <td>{listValue.id}</td>
                <td>{listValue.name}</td>
                <td>{listValue.type}</td>
                <td>{listValue.startDate}</td>
                <td>{listValue.endDate}</td>
                <td>{listValue.recurringday}</td>
                <td onClick={() => this.edit(listValue.id)}><button type="button" class="btn btn-primary">Edit</button></td>
                <td onClick={() => this.delete(listValue.id)}><button type="button" class="btn btn-primary">Delete</button></td>
                
              </tr>
            );
          })
    }

    render() {
        return (
            <div>
               
               
 
<MDBContainer>
    <MDBRow md="4">
        <MDBCol md="6">
                <form onSubmit={this.handleSubmit} >
                <p className="h5 text-center mb-4"></p>
                <div className="form-group row">
                    <label className=" control-label col-md-4" htmlFor="Name">Name</label>
        <MDBInput className="form-control" type="text" id="name" value={this.state.name} onChange={this.handleChange} required/>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-4" htmlFor="Type">Type</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" id="type"  value={this.state.type} onChange={this.handleChange} required>
                            <option value="">-- Select Recurring Type --</option>
                            <option value="Daily">Daily</option>
                            <option value="Weekly" >Weekly</option>
                        </select>
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-4" htmlFor="startDate" >StartDate</label>
                    <div className="col-md-4">
                        <MDBInput className="form-control" type="text" value={this.state.startDate} id="startDate" onChange={this.handleChange} required />
                    </div>

                </div>
                <div className="form-group row">
                    <label className="control-label col-md-4" htmlFor="endDate" >EndDate</label>
                    <div className="col-md-4">
                        <MDBInput className="form-control" type="text" value={this.state.endDate} id="endDate" onChange={this.handleChange} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-4" htmlFor="RecurringDay" >Recurrence Day</label>
                    <div className="col-md-4">
                        <MDBInput className="form-control" type="text" value={this.state.recurringday} id="recurringday" onChange={this.handleChange} required />
                    </div>
                </div>
                <div className="form-group">
                    <MDBBtn type="submit" onClick={this.handleSubmit} className="btn btn-default">Save</MDBBtn>
                    <MDBBtn className="btn" onClick={this.handleCancel}>Cancel</MDBBtn>
                </div >
            </form >
            </MDBCol>
    </MDBRow>
</MDBContainer>
                <hr/> 
                <MDBTable>
                <MDBTableHead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Type</th>
                        <th>StartDate</th>
                        <th>EndDate</th>
                        <th>Recurring Day</th>
                    </tr>
                    </MDBTableHead>
                    <MDBTableBody>
                        {this.renderTable()}
                    </MDBTableBody>
                   
      </MDBTable>
                   
            </div>
        )
    };
}


export default Schedule

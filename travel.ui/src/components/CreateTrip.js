import React from 'react'

const CreateTrip = ({ onChangeForm, createTrip }) => {

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-7 mrgnbtm">
                    <h2>Create Trip</h2>
                    <form>
                        <div className="row">
                            <div className="form-group col-md-6">
                                <label htmlFor="exampleInputEmail">Trip Name</label>
                                <input type="text" onChange={(e) => onChangeFrom(e)} className="form-control" name="tripname" id="tripname" aria-describedby="emailHelp" placeholder="Trip Name" />
                            </div>
                        </div>
                        <button type="button" onClick={(e) => createTrip()} className="btn btn-danger">Create</button>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default CreateTrip
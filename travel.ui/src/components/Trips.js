import React from 'react'

export const Trips = ({ trips }) => {
    console.log('trips length:::', trips.length)
    if (trips.length === 0) return null

    const TripRow = (trip, index) => {

        return (
            <tr key={trip.tripId} className={trip.tripId}>
                <td>{trip.tripId}</td>
                <td>{trip.tripName}</td>
            </tr>
        )
    }

    const tripTable = trips.map((trip, index) => TripRow(user, index))

    return (
        <div className="container">
            <h2>Trips</h2>
            <table className="table table-bordered">
                <thead>
                    <tr>
                        <th>Trip ID</th>
                        <th>Trip Name</th>
                    </tr>
                </thead>
                <tbody>
                    {tripTable}
                </tbody>
            </table>
        </div>
    )
}
export async function getAllTrips() {
    const response = await fetch('/api/trips')
    return await response.json();
}

export async function createTrip(data) {
    const response = await fetch('/api/trip', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    })
    return await response.json();
}
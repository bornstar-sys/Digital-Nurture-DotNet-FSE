import React from 'react';

function GuestPage() {
  return (
    <div>
      <h2>Welcome Guest!</h2>
      <p>Available Flights:</p>
      <ul>
        <li>Delhi to Mumbai - ₹5000</li>
        <li>Bangalore to Chennai - ₹3000</li>
        <li>Kolkata to Hyderabad - ₹4500</li>
      </ul>
      <p>Please login to book tickets.</p>
    </div>
  );
}

export default GuestPage;
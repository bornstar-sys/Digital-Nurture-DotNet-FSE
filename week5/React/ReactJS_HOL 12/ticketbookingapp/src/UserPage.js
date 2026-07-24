import React from 'react';

function UserPage() {
  return (
    <div>
      <h2>Welcome User!</h2>
      <p>Book Your Tickets:</p>
      <ul>
        <li>Delhi to Mumbai - ₹5000 <button>Book Now</button></li>
        <li>Bangalore to Chennai - ₹3000 <button>Book Now</button></li>
        <li>Kolkata to Hyderabad - ₹4500 <button>Book Now</button></li>
      </ul>
    </div>
  );
}

export default UserPage;
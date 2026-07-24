import React from 'react';

function App() {
  // Office object
  const office = {
    name: "Tech Hub",
    rent: 75000,
    address: "123 MG Road, Bangalore"
  };

  // List of offices
  const officeList = [
    { id: 1, name: "Tech Hub", rent: 75000, address: "123 MG Road, Bangalore" },
    { id: 2, name: "StartUp Space", rent: 45000, address: "456 Brigade Road, Bangalore" },
    { id: 3, name: "Elite Office", rent: 95000, address: "789 Whitefield, Bangalore" },
    { id: 4, name: "Budget Space", rent: 30000, address: "321 Koramangala, Bangalore" },
    { id: 5, name: "Premium Hub", rent: 120000, address: "654 Indiranagar, Bangalore" }
  ];

  return (
    <div>
      {/* Heading */}
      <h1>Office Space Rental</h1>

      {/* Single Office Details */}
      <h2>Featured Office</h2>
      <p>Name: {office.name}</p>
      <p>Address: {office.address}</p>
      <p style={{ color: office.rent < 60000 ? 'red' : 'green' }}>
        Rent: ₹{office.rent}
      </p>

      {/* Office List */}
      <h2>Available Offices</h2>
      {officeList.map(item => (
        <div key={item.id} style={{ border: '1px solid black', margin: '10px', padding: '10px' }}>
          <h3>{item.name}</h3>
          <p>Address: {item.address}</p>
          <p style={{ color: item.rent < 60000 ? 'red' : 'green' }}>
            Rent: ₹{item.rent}
          </p>
        </div>
      ))}
    </div>
  );
}

export default App;
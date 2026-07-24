import React from 'react';

function IndianPlayers() {
  const players = ["Virat Kohli", "Rohit Sharma", "MS Dhoni", 
                   "Hardik Pandya", "Jasprit Bumrah"];

  return (
    <div>
      <h2>Indian Players</h2>
      {players.map((player, index) => (
        <p key={index}>{player}</p>
      ))}
    </div>
  );
}

export default IndianPlayers;
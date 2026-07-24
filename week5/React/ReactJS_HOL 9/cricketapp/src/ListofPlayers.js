import React from 'react';

function ListofPlayers() {
  const players = [
    { name: "Virat Kohli", score: 85 },
    { name: "Rohit Sharma", score: 92 },
    { name: "KL Rahul", score: 65 },
    { name: "Shikhar Dhawan", score: 55 },
    { name: "MS Dhoni", score: 78 },
    { name: "Hardik Pandya", score: 45 },
    { name: "Ravindra Jadeja", score: 60 },
    { name: "Jasprit Bumrah", score: 30 },
    { name: "Mohammed Shami", score: 25 },
    { name: "Yuzvendra Chahal", score: 40 },
    { name: "Rishabh Pant", score: 88 }
  ];

  // ES6 arrow function + filter
  const lowScorers = players.filter(player => player.score < 70);

  return (
    <div>
      <h2>All Players</h2>
      {players.map((player, index) => (
        <p key={index}>{player.name} - Score: {player.score}</p>
      ))}

      <h2>Players with Score below 70</h2>
      {lowScorers.map((player, index) => (
        <p key={index}>{player.name} - Score: {player.score}</p>
      ))}
    </div>
  );
}

export default ListofPlayers;
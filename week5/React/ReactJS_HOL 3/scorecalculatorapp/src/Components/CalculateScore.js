import React from 'react';

function CalculateScore(props) {
  const average = props.Total / props.goal;
  return (
    <div>
      <h2>Student Score Calculator</h2>
      <p>Name: {props.Name}</p>
      <p>School: {props.School}</p>
      <p>Total Score: {props.Total}</p>
      <p>Goal: {props.goal}</p>
      <p>Average Score: {average.toFixed(2)}</p>
    </div>
  );
}

export default CalculateScore;
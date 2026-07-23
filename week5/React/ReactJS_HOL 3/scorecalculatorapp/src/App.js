import React from 'react';
import CalculateScore from './Components/CalculateScore';

function App() {
  return (
    <div>
      <CalculateScore 
        Name="John" 
        School="ABC School" 
        Total={450} 
        goal={5} 
      />
    </div>
  );
}

export default App;
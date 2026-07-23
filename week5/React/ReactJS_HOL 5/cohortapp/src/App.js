import React from 'react';
import CohortDetails from './CohortDetails';

function App() {
  return (
    <div>
      <h1>Cognizant Academy - Cohort Dashboard</h1>
      <CohortDetails name="DotNet FSE" status="Ongoing" students={30} />
      <CohortDetails name="React Batch" status="Completed" students={25} />
      <CohortDetails name="Angular Batch" status="Ongoing" students={20} />
    </div>
  );
}

export default App;
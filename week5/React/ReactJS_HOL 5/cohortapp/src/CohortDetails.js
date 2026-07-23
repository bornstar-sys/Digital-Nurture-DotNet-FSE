import React from 'react';
import styles from './CohortDetails.module.css';

function CohortDetails(props) {
  return (
    <div className={styles.box}>
      <h3>{props.name}</h3>
      <p>Status: {props.status}</p>
      <p>Students: {props.students}</p>
    </div>
  );
}

export default CohortDetails;
import React from 'react';

function CourseDetails() {
  const courses = [
    { id: 1, name: "React JS", duration: "30 hrs" },
    { id: 2, name: "ASP.NET Core", duration: "40 hrs" },
    { id: 3, name: "Entity Framework", duration: "20 hrs" }
  ];

  return (
    <div>
      <h2>Course Details</h2>
      {courses.map(course => (
        <div key={course.id}>
          <p>{course.name} - {course.duration}</p>
        </div>
      ))}
    </div>
  );
}

export default CourseDetails;
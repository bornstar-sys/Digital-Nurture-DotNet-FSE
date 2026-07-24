import React, { useState } from 'react';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';
import CourseDetails from './CourseDetails';

function App() {
  const [show, setShow] = useState('all');

  return (
    <div>
      <h1>Blogger App</h1>
      <button onClick={() => setShow('all')}>Show All</button>
      <button onClick={() => setShow('books')}>Books</button>
      <button onClick={() => setShow('blogs')}>Blogs</button>
      <button onClick={() => setShow('courses')}>Courses</button>
      <hr />
      {(show === 'all' || show === 'books') && <BookDetails />}
      {(show === 'all' || show === 'blogs') && <BlogDetails />}
      {(show === 'all' || show === 'courses') && <CourseDetails />}
    </div>
  );
}

export default App;
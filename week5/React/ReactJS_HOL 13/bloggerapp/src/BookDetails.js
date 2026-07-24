import React from 'react';

function BookDetails() {
  const books = [
    { id: 1, title: "Clean Code", author: "Robert Martin" },
    { id: 2, title: "The Pragmatic Programmer", author: "Andrew Hunt" },
    { id: 3, title: "Design Patterns", author: "Gang of Four" }
  ];

  return (
    <div>
      <h2>Book Details</h2>
      {books.map(book => (
        <div key={book.id}>
          <p>{book.title} - {book.author}</p>
        </div>
      ))}
    </div>
  );
}

export default BookDetails;
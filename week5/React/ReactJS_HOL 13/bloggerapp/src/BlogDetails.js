import React from 'react';

function BlogDetails() {
  const blogs = [
    { id: 1, title: "React Hooks", isPublished: true },
    { id: 2, title: "Redux Guide", isPublished: false },
    { id: 3, title: "JSX Deep Dive", isPublished: true }
  ];

  return (
    <div>
      <h2>Blog Details</h2>
      {blogs.map(blog => (
        <div key={blog.id}>
          <p>{blog.title} - {blog.isPublished ? "Published" : "Draft"}</p>
        </div>
      ))}
    </div>
  );
}

export default BlogDetails;
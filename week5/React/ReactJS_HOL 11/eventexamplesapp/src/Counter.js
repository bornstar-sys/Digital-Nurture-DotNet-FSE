import React, { useState } from 'react';

function Counter() {
  const [count, setCount] = useState(0);

  const increment = () => setCount(count + 1);
  const sayHello = () => alert("Hello! Welcome to React Events!");
  const decrement = () => setCount(count - 1);
  const sayWelcome = (msg) => alert(msg);
  const onPress = (e) => alert("I was clicked");

  return (
    <div>
      <h2>Counter: {count}</h2>
      <button onClick={() => { increment(); sayHello(); }}>Increment</button>
      <button onClick={decrement}>Decrement</button>
      <br /><br />
      <button onClick={() => sayWelcome("welcome")}>Say Welcome</button>
      <br /><br />
      <button onClick={onPress}>Synthetic Event Button</button>
    </div>
  );
}

export default Counter;
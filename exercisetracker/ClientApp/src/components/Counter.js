import React, { Component } from 'react';

export class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0, squareCount: 2 };
    this.incrementCounter = this.incrementCounter.bind(this);
    this.squareCounter = this.squareCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }
  
  squareCounter() {
      this.setState({
        squareCount: this.state.squareCount * this.state.squareCount
        });
  }
  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>
        <p aria-live="polite">Squared count: <strong>{this.state.squareCount}</strong></p>

        <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
        <button className="btn btn-primary" onClick={this.squareCounter}>Square</button>
      </div>
    );
  }
}

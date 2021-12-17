import React, { Component } from 'react';

import * as signalR from '@microsoft/signalr'

export default class App extends Component {

  constructor() {
    super();

    this.state = {
      message: [],
      number: 1,
    }
  }
  componentDidMount() {
    let connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:5001/chart")
      .build();

      connection.start()

      connection.on("chartStation1", (data) => {
            console.log('DATA: ', data);
            this.setState({ number: this.state.number + 1 })
      })
    connection.on("chartStatus2", data => {
      console.log(data);
  });
  }

  fetchData() {
    fetch("https://localhost:5001/Chart/send/graph1")
  }

  render() {
    return (
      <div>
        APP
        <button onClick={this.fetchData}>
          click
        </button> <br /><br />

        {this.state.number}
      </div>
    )
  }
}


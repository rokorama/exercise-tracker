//create a React component to view a single workout session
//

import React, { Component } from 'react';
import { Button } from 'reactstrap';

export class WorkoutSessionDetails extends Component {
    static displayName = WorkoutSessionDetails.name;
    constructor(props) {
        super(props);
        this.state = {
            workoutSession: {
                id: '',
                userid: '',
                date: '',
                notes: '',
            }
        };
    }

    componentDidMount() {
        const { id } = this.props.match.params;
        fetch(`api/workout/${id}`)
            .then(response => response.json())
            .then(data => {
                this.setState({ workoutSession: data });
            });
    }

    render() {
        const { workoutSession } = this.state;
        const { id, userid, date, notes } = workoutSession;

        return (
            <div>
                <h1>Workout session</h1>
                <dl>
                    <dt>Date</dt>
                    <dd>{date}</dd>
                    <dt>Notes</dt>
                    <dd>{notes}</dd>
                </dl>
                <Button href={`/workout/edit/${id}`}>Edit</Button>
                <Button href="/workout">Back to list</Button>
            </div>
        );
    }
}
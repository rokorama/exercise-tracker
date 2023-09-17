// noinspection SpellCheckingInspection

import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

export class WorkoutSessionForm extends Component {
    static displayName = WorkoutSessionForm.name;
    constructor(props) {
        super(props);
        this.state = {
            workoutSession: {
                id: '486ca60b-8c2c-411e-b54e-67c74a4fb925',
                userid: '93243b0e-6fbf-4a68-a6c1-6da4b4e3c3e4',
                date: '',
                notes: '',
            }
        };
    }

    handleChange = (event) => {
        const { name, value } = event.target;
        const { workoutSession } = this.state;
        this.setState({
            workoutSession: {
                ...workoutSession,
                [name]: value
            }
        });
    }

    handleSubmit = (event) => {
        event.preventDefault();
        const { workoutSession } = this.state;
        console.log(workoutSession);
        fetch('workout', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(workoutSession)
        })
            .then(response => response.json())
            .then(data => {
                this.setState({
                    workoutSession: {
                        id: '486ca60b-8c2c-411e-b54e-67c74a4fb925',
                        date: '',
                        notes: ''
                    }
                });
            });
    }

    render() {
        const {workoutSession} = this.state;
        const {handleChange, handleSubmit} = this;

        return (
            <div>
                <h1>New workout session</h1>
                <Form onSubmit={handleSubmit}>
                    <FormGroup>
                        <Label for="date">Date</Label>
                        <Input id="date" name="date" type="date" value={workoutSession.date} onChange={handleChange}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="notes">Notes</Label>
                        <Input id="notes" name="notes" value={workoutSession.notes} onChange={handleChange}/>
                    </FormGroup>
                    <Button>Submit</Button>
                </Form>
            </div>
        )
    }}
            
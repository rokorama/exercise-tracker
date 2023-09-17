// noinspection SpellCheckingInspection

import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

export class RunForm extends Component {
    static displayName = RunForm.name;
    constructor(props) {
        super(props);
        this.state = {
            run: {
                id: 'd397e908-07be-4768-84e5-598914f2e264',
                sessionid: '486ca60b-8c2c-411e-b54e-67c74a4fb925',
                userid: '93243b0e-6fbf-4a68-a6c1-6da4b4e3c3e4',
                time: '',
                warmupTime: '',
                outside: false,
                notes: ''
            }
        };
    }

    handleChange = (event) => {
        const { name, value } = event.target;
        const { run } = this.state;
        this.setState({
            run: {
                ...run,
                [name]: value
            }
        });
    }

    handleSubmit = (event) => {
        event.preventDefault();
        const { run } = this.state;
        console.log(run);
        fetch('run', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(run)
        })
            .then(response => response.json())
            .then(data => {
                this.setState({
                    run: {
                        id: 'd397e908-07be-4768-84e5-598914f2e264',
                        sessionid: '486ca60b-8c2c-411e-b54e-67c74a4fb925',
                        userid: '93243b0e-6fbf-4a68-a6c1-6da4b4e3c3e4',
                        time: '',
                        warmupTime: '',
                        outside: false,
                        notes: ''
                    }
                });
            });
    }

    render() {
        const {run} = this.state;
        const {handleChange, handleSubmit} = this;

        return (
            <div>
                <h1>New workout session</h1>
                <Form onSubmit={handleSubmit}>
                    <FormGroup>
                        <Label for="distance">Distance</Label>
                        <Input id="distance" name="distance" type="number" step="0.01" value={run.distance} onChange={handleChange}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="date">Time</Label>
                        <Input id="time" name="time" type="time" step="2" value={run.time} onChange={handleChange}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="warmupTime">Warmup time</Label>
                        <Input id="warmupTime" name="warmupTime" type="time" step="2" value={run.warmupTime} onChange={handleChange}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="outside">Outside?</Label>
                        <Input id="outside" name="outside" type="checkbox" value={run.outside} onChange={handleChange}/>
                    </FormGroup>
                    <FormGroup>
                        <Label for="notes">Notes</Label>
                        <Input id="notes" name="notes" value={run.notes} onChange={handleChange}/>
                    </FormGroup>
                    <Button>Submit</Button>
                </Form>
            </div>
        )
    }}
            
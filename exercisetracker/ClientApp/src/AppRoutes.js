import { Home } from "./components/Home";
import {WorkoutSessionForm} from "./components/WorkoutSessionForm";
import {WorkoutSessionDetails} from "./components/WorkoutSessionDetails";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: "/new-workout-session",
    element: <WorkoutSessionForm />
  },
  {
    path: "/workout/:id",
    element: <WorkoutSessionDetails/>
  }
];

export default AppRoutes;

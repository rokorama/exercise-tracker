import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import {WorkoutSessionForm} from "./components/WorkoutSessionForm";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: "/new-workout-session",
    element: <WorkoutSessionForm />
  }
];

export default AppRoutes;

import Home from "./components/Home.vue";
import Login from "./components/Login.vue";
import Register from "./components/Register.vue";
import CreateWorkoutSession from "./components/CreateWorkoutSession.vue";
import {createRouter, createWebHistory} from "vue-router";

const routes = [
    {
        path: "/",
        component: Home,
        name: 'Home',
        meta: { requiresAuth: false },
    },
    {
        path: "/login",
        component: Login,
        name: 'Login',
        meta: { requiresAuth: false }
    },
    {
        path: "/register",
        component: Register,
        name: 'Register',
        meta: { requiresAuth: false }
    },
    {
        path: "/workout",
        component: CreateWorkoutSession,
        name: 'Workout',
        meta: { requiresAuth: true }
    },
];

const router = createRouter({
    routes: routes,
    history: createWebHistory(),
});

router.beforeEach( (to, from) => {
    const isAuthenticated = window.$cookies.get('jwt');
    if (to.meta.requiresAuth && !isAuthenticated)
    {
        console.log('unauthenticated, redirecting')
        return '/login'
    }
})

export default router;
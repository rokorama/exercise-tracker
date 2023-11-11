import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import {createRouter, createWebHistory} from "vue-router";
import Home from "./components/Home.vue";
import Login from "./components/Login.vue";
import Register from "./components/Register.vue";

const routes = [
    {
        path: "/",
        component: Home,
    },
    {
        path: "/login",
        component: Login,
    },
    {
        path: "/register",
        name: "Register",
        component: Register,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

createApp(App)
    .use(router)
    .mount("#app");
import {createApp} from 'vue'
import './style.css'
import VueCookies from 'vue-cookies';
import App from './App.vue'
import router from "./router.js";

createApp(App)
    .use(router)
    .use(VueCookies)
    .mount("#app");
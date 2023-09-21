import {createRouter, createWebHistory} from "vue-router";
import Dashboard from "../components/DashboardView.vue";
import LoginView from "../components/LoginView.vue";
import Members from "../components/Members.vue";
import Ping from "../components/Ping.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: "/",
            name: "dashboard",
            component: Dashboard,
        },
        {
            path: "/login",
            name: "login",
            component: LoginView,
        },
        {
            path: "/Employee",
            name: "Members",
            component: Members,
        },
        {
            path: "/ping",
            name: "ping",
            component: Ping,
        },

    ],
});

export default router;

import {createRouter, createWebHistory} from "vue-router";
import Dashboard from "../components/pages/DashboardView.vue";
import LoginView from "../components/pages/LoginView.vue";
import LogoutView from "../components/pages/LogoutView.vue";
import Members from "../components/pages/Members.vue";
// import Ping from "../components/Ping.vue";

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
            // redirect: "/",
        },
        {
            path: "/logout",
            name: "logout",
            component: LogoutView,
            // redirect: "/login",
        },
        {
            path: "/employee",
            name: "Members",
            component: Members,
        },

    ],
});

export default router;

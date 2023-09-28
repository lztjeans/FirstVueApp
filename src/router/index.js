import {createRouter, createWebHistory} from "vue-router";
import Dashboard from "../components/pages/DashboardView.vue";
import LoginView from "../components/pages/LoginView.vue";
import LogoutView from "../components/pages/LogoutView.vue";
import Members from "../components/pages/Members.vue";
import Register from "../components/pages/RegisterView.vue";
import CatalogList from "../components/catalog/List.vue";
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
            name: "Login",
            component: LoginView,
            // redirect: "/",
        },
        {
            path: "/logout",
            name: "Logout",
            component: LogoutView,
            // redirect: "/login",
        },
        {
            path: "/employee",
            name: "Members",
            component: Members,
        },
        {
            path: "/register",
            name: "Register",
            component: Register,
        },
        {
            path: "/list",
            name: "CatalogList",
            component: CatalogList,
        }
    ],
});

export default router;

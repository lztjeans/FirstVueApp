import {createRouter, createWebHistory} from "vue-router";
import Members from "../components/Members.vue";
// import Books from "../components/Books.vue";
import Ping from "../components/Ping.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: "/",
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

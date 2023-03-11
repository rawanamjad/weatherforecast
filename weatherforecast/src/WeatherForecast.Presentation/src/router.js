import { createWebHistory, createRouter,isNavigationFailure, NavigationFailureType  } from "vue-router";
import Weather from "./components/Weather.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: Weather,
  },
  {
    path: "/weather",
    name: "Weather",
    component: Weather,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

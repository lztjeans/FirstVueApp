<template>

  <AppHeader> </AppHeader>
  <p></p>
  <router-view id="content" />
</template>

<script setup>
// import {RouterView} from "vue-router";
import AppHeader from "./components/AppHeader.vue";
</script>


<style>
/* #app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
} */
</style>
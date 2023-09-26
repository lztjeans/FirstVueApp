<template>

  <!-- *************************************************************************                          -->
  <navbar> </navbar>
  <router-view id="content" />
  <!-- *************************************************************************                          -->
</template>

<script>
// import {RouterView} from "vue-router";
    import navbar  from "./components/shared/AppHeader.vue";
    export default {
      components:{
        navbar : navbar ,
      }
    }
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
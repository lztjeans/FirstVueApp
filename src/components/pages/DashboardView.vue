<template>
  <!-- <h3>Welcome, {{getUsername()}}</h3> -->
  <h1>This is DashboardView</h1>
</template>

<script>

  export default {
    // name: 'DashboardView',
    data() {
      return {
      }
    },
    methods:{
      getUsername() {
        let userNmB = sessionStorage.getItem("LoginAccount");
        return  userNmB
      }, 
    },
    created() {
      console.log("component: 'Dashboard' created!");//for test
      this.getUsername();
      console.log(sessionStorage.getItem("LoginSuccess"));
      // window.location.reload(true);
    },
   
  
  
  }

  /*
  Session["LoginAccount"] = item.Account;
  */

</script>

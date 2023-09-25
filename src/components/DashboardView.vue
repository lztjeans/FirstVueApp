<template>
  <h3>Welcome, {{getUsername()}}</h3>
  <h1>This is DashboardView</h1>
</template>

<script>

import {  GET_USERNAME } from "../store/storeconstants";
  export default {
    // name: 'DashboardView',
    data() {
      return {
      }
    },
    methods:{
      getUsername() {
        var userNmA = this.$store.getters[`auth/${GET_USERNAME}`];
        let userNmB = sessionStorage.getItem("LoginAccount");
        return userNmA +"_;_"+ userNmB
      }, 
    },
    created() {
      console.log("component: 'Members' created!");//for test
      this.getUsername();
      console.log(sessionStorage.getItem("LoginSuccess"));
    },
   
  
  
  }

  /*
  Session["LoginAccount"] = item.Account;
  */



// export default {
//   data() {
//     return {
//       message: "",
//       showMessage: false,
//     };
//   },
//   methods: {
//     // signOut() {
//     //   console.log("signOut click!");
//     //   // auth
//     //   //   .signOut()
//     //   //   .then(() => {
//     //   //     console.log("Sign Out completed");
//     //   //     this.$router.push("/");
//     //   //   })
//     //   //   .catch((error) => console.log(error));
//     // },
//   },
//   created() {
//     // console.log("component: 'Members' created!");//for test
//     // let userInfo = sessionStorage.getItem("user-info");
//     // if (userInfo["succeeded"]){
//     //   alert('Login succeeded');
//     // }else{
//     //   alert('Login fail');
//     // }
//     this.showMessage=true;
//     this.message="This is Dashboard View";

//   },
// };
</script>

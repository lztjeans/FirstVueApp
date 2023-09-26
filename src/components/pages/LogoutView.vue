<template>
    <div class="container m-5">
        <h3>您好，請問要登出嗎?</h3>
        <p>{{getUsername()}}</p>
           <!-- <p>{{user.displayName}}</p>
           <p>{{user.email}}</p> -->
        
        <button 
        type="submit" 
        class="btn btn-dark btn-lg btn-block"
        @click="logOut()">
            登出
        </button>
    </div>
</template>

<script>
// import { SET_AUTHENTICATION, SET_USERNAME, GET_USERNAME } from "../store/storeconstants";
import axios from "axios";

export default {
  data() {
    return {
      user: null,
      output: "",
    };
  },
  created() {
    // firebaseAuth.onAuthStateChanged((user) => {
    //   if (user) {
    //     this.user = user;
    //   } else {
    //     this.user = null;
    //   }
    // });
    this.getUsername();
  },
  methods: {
    logOut() {
      const path = "http://localhost:5001/account/logout";
      axios.get(path)
          .then((res) => {
            console.log(res);
            sessionStorage.removeItem("LoginAccount");
            sessionStorage.removeItem("LoginSuccess");
            this.$router.push("/");
          })
          .catch((error) => {
            console.log(error.code);
            console.log(error.message);
            sessionStorage.removeItem("LoginAccount");
            sessionStorage.removeItem("LoginSuccess");
            this.output = "Username and password can not be empty"
          });
    },
    getUsername(){
      return sessionStorage.getItem("LoginAccount");
    },
  }
};
</script>
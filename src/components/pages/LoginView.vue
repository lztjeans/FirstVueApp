<template>
  <div class="container">
    <h1 class="bg-info text-white">Login</h1>
    <div class="form-group">
      <span>Email address</span>
      <input
        class="form-control"
        type="text"
        if="email"
        placeholder="email@adress.com"
        v-model="this.email" />
    </div>
    <div class="form-group">
      <span>Password</span>
      <input
        class="form-control"
        type="password"
        id="password"
        placeholder="password123"
        v-model="this.password" />
    </div>
    <div class="form-group">
      Remember me? 
      <input 
      type="checkbox" 
      v-model="remember" />
    </div>
    <div class="alternative-option mt-4">
      You don't have an account? <span  class="btn" @click="moveToRegister">Register</span>
    </div>
    <button class="btn btn-primary" type="button" @click="login()">Log In</button>
    <div
      class="alert alert-warning alert-dismissible fade show mt-5 d-none"
      role="alert"
      id="alert_2"
    >
      Lorem ipsum dolor sit amet consectetur, adipisicing elit.
      <button
        type="button"
        class="btn-close"
        data-bs-dismiss="alert"
        aria-label="Close"
      ></button>
    </div>
    <h4>{{ output }}</h4>
  </div>
</template>

<script>
// import { SET_AUTHENTICATION, SET_USERNAME } from "../store/storeconstants";
import axios from "axios";

export default {
  data() {
    return {
      email: "",
      password: "",
      remember: false,
      output: "",
    };
  },
  methods: {
    //async
     login() {
      const url = "http://localhost:5001/account/login";
      var data ={
        Email: this.email,
        password: this.password,
        Remember: this.remember,
        returnUrl:"/",
      };

      axios.post(url, data)
          .then((res) => {
            // console.log("axios.post then " + res);
            sessionStorage.setItem("LoginAccount", data.Email);
            sessionStorage.setItem("LoginSuccess", res.data.succeeded);
            this.output="Login success!";

            this.$router.push({name: "dashboard"});

          })
          .catch((error) => {
              const errorCode = error.code;
              const errorMessage = error.message;
              console.log(errorCode);
              console.log(errorMessage);
              let alert_2 = document.querySelector("#alert_2");
              alert_2.classList.remove("d-none");
              alert_2.innerHTML = errorMessage;
              console.log(alert_2);
              sessionStorage.setItem("LoginSuccess", false);
              this.output = "Username and password can not be empty"
          })
          .finally(() => {
            // alert(sessionStorage.getItem("LoginSuccess"));
            // alert(this.output);
          });
    },
    moveToRegister() {
      this.$router.push("/register");
    },
  },
  created(){
    console.log("component: 'LoginView' created!");//for test

  },
};
</script>

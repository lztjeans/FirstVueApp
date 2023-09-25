<template>
  <div class="container">
    <form>
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
      <!-- <div class="alternative-option mt-4">
        You don't have an account? <span @click="moveToRegister">Register</span>
      </div> -->
      <button class="btn btn-primary" type="submit" @click="login()">Log In</button>
    </form>
    <h4>{{ output }}</h4>
    <!-- <div
      class="alert alert-warning alert-dismissible fade show mt-5 d-none"
      role="alert"
      id="alert_1"
    >
      Lorem ipsum dolor sit amet consectetur, adipisicing elit.
      <button
        type="button"
        class="btn-close"
        data-bs-dismiss="alert"
        aria-label="Close"
      ></button>
    </div> -->
  </div>
</template>

<script>
import { SET_AUTHENTICATION, SET_USERNAME } from "../store/storeconstants";
import axios from "axios";

export default {
  data() {
    return {
      email: "",
      password: "",
      remember: false,
      output: "",
      // message: "",
      // showMessage: false,
    };
  },
  methods: {
    login() {
      const path = "http://localhost:5001/account/login";
      var payload ={
        Email: this.email,
        password: this.password,
        Remember: this.remember,
        returnUrl:"/",
      };
      axios.post(path, payload)
          .then((res) => {
            console.log(res);
            sessionStorage.setItem("LoginAccount", payload.Email);
            sessionStorage.setItem("LoginSuccess", true);

            this.output = "Authentication complete"
            //stores true to the set_authentication and username to the set_username 
            this.$store.commit(`auth/${SET_AUTHENTICATION}`, true);
            this.$store.commit(`auth/${SET_USERNAME}`, this.email);
            this.output = "Authentication complete."

            // this.$router.push({name: "dashboard"});
            // router.push({name: "dashboard"})
            // this.$router.push('/logout');
            this.$router.push("/");
          })
          .catch((error) => {
            console.log(error.code);
            console.log(error.message);
            this.$store.commit(`auth/${SET_AUTHENTICATION}`, false);
            sessionStorage.setItem("LoginSuccess", false);
            this.output = "Username and password can not be empty"
          });
    },
    // moveToRegister() {
    //   this.$router.push("/register");
    // },
  },
};
</script>

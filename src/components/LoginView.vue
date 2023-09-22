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
      <div
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
      </div>
    </form>
  </div>
</template>

<script>
// import { getAuth, signInWithEmailAndPassword } from "firebase/auth";
import axios from "axios";

export default {
  data() {
    return {
      email: "",
      password: "",
      remember: false,
      // message: "",
      // showMessage: false,
    };
  },
  methods: {
    login() {
      const path = "http://localhost:5001/account/login";
      var payload ={
        account: this.email,
        password: this.password,
        IsRemeber: this.remember,
        returnUrl:"/",
      };
      axios.post(path, payload)
          .then(() => {
            this.$router.push("/dashboard");
          })
          .catch((error) => {
            // this.message = "Member added";
            // this.showMessage = true;
            const errorCode = error.code;
            const errorMessage = error.message;
            console.log(errorCode);
            console.log(errorMessage);
            let alert_1 = document.querySelector("#alert_1");
            alert_1.classList.remove("d-none");
            alert_1.innerHTML = errorMessage;
            console.log(alert_1);
          });
    },
    moveToRegister() {
      this.$router.push("/register");
    },
  },
};
</script>

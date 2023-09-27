<template>
  <div class="container">
    <h2 class="bg-info text-white">Register</h2>
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

    <div class="alternative-option mt-4">
      Already have an account? <span class="btn" @click="moveToLogin">Login</span>
    </div>

    <button class="btn btn-primary" type="button" @click="register">Register</button>
    <div
      class="alert alert-warning alert-dismissible fade show mt-5 d-none"
      role="alert"
      id="alert_2">
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
import axios from "axios";

export default {
  data() {
    return {
      email: "",
      password: "123456",
      output: "",
    };
  },
  methods: {
    register() {
      const url = "http://localhost:5001/account/register";
      var data ={
        Email: this.email,
        password: this.password
      };

      axios.post(url, data)
          .then((res) => {
            // console.log("axios.post then " + res);
            this.output="register success!";

            this.$router.push("/login");

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
        });
    },
    moveToLogin() {
      this.$router.push("/login");
    },
  },
};
</script>

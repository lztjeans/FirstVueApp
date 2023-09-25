<template>

    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">FirstApp</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="/">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="/Employee">All Employee</a>
                    </li>
                    <li class="nav-item"></li>
                </ul>
                <form class="d-flex">
                    <!-- <a class="btn btn-danger" href="/logout" >Logout</a>
                    <a class="btn nav-link" href="/login">Login</a>         -->
                    <button class="btn btn-danger" type="button" @click="handleLogout()">Logout</button>
                    <button class="btn nav-link" type="button" @click="handleLogin()">Login</button>
                </form>
            </div>
        </div>
    </nav>
</template>

<script>
  export default {
    // name: 'AppHeader',
    data() {
      return {
      }
    },
    methods:{
        handleLogout() {
            // var userNmA = this.$store.getters[`auth/${GET_USERNAME}`];
            // let userNmB = sessionStorage.getItem("LoginAccount");
            // return userNmA +"_;_"+ userNmB
            this.$router.push('/logout');
        },
        handleLogin() {
            console.log("click=handleLogin");
            this.$router.push('/login');
        },
    },
    created() {
      console.log("component: 'AppHeader' created!");//for test
    //   this.getUsername();
    //   console.log(sessionStorage.getItem("LoginSuccess"));
    },
   
  
  
  }
</script>

<!--

-->

    <!-- <b-nav-item-dropdown text="User" right>
        <b-dropdown-item><router-link to="/login">Login</router-link></b-dropdown-item>
        <b-dropdown-item><router-link to="/register">Register</router-link></b-dropdown-item>
        <b-dropdown-item><router-link to="/logout">Logout</router-link></b-dropdown-item>
    </b-nav-item-dropdown> -->
                    <!-- <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Dropdown
          </a>
          <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Another action</a></li>
            <li><hr class="dropdown-divider"></li>
            <li><a class="dropdown-item" href="#">Something else here</a></li>
          </ul>
        </li> -->
                                <!-- <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a> -->
                                                    <!-- <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                    <button class="btn btn-outline-success" type="submit">Search</button> -->
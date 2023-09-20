<script setup>
import 'bootstrap/dist/css/bootstrap.css';
var homePageUrl = "/Home/Index";
var empIndexUrl = "/Employee/Index";
var loginUrl = "/Account/Login";
var logoutUrl = "/Account/Logout";
defineProps({
  curUser: {
    type: String,
    // required: true,
    default: ""
  },
  isLogin : {
    type: Boolean,
    // required: true,
    default: false
  }
})
</script>

<template>
    <div class="container-fluid">
        <a class="navbar-brand" :href="homePageUrl">FirstApp</a>
        <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
            <ul class="navbar-nav flex-grow-1">
                <li class="nav-item">
                    <a class="nav-link text-dark" :href="empIndexUrl">All Employee</a>
                </li>
            </ul>
        </div>


        <div class="display-8">Welcome {{ curUser }} </div>
        <div class="nav-item"> </div>
        <div class="nav-item">
            <a :href="logoutUrl" v-if="isLogin" class="btn btn-danger">Logout</a>
            <a :href="loginUrl" v-else class="nav-link text-dark" ReturnUrl="/">Login</a>
        </div>



    </div>        
</template>

<style>

</style>


<!-- <li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Employee" asp-action="Index">All Employee</a>
</li> -->
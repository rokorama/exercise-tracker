<script setup>

import {ref} from "vue";

const userLogin = ref({username: '', password:''});

function handleLogin() {
  
  console.log(userLogin.value);
}
</script>

<template>
  <h1>Login</h1>
  <form class="form-group">
    <input type="text" required placeholder="Username" v-model="userLogin.username">
    <br>
    <input type="password" required placeholder="Password" v-model="userLogin.password">
    <br>
    <button type="button" @click="handleLogin">Log in</button>
  </form>
  
</template>

<style scoped>
.form-group {
  input {
    margin-bottom: 20px;
  }
}
</style>
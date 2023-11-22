<script setup>

import {onMounted, ref} from "vue";
import axios from 'axios';
import {createRouter as router} from "vue-router";

const username = ref('');
const password = ref('');

async function handleLogin() {
  await axios.post("https://localhost:44420/api/auth/login", JSON.stringify({
    Username: username.value,
    Password: password.value
  }), {
    headers: {
      "Content-Type": "application/json",
    }
  }).then(() => {
    router.back();
  }).catch(() => {
    console.log("An error occured while logging in. Please try again later.")
  })
}
</script>

<template>
  <h1>Log in</h1>
  <form class="form-group">
    <input type="text" required placeholder="Username" v-model="username">
    <br>
    <input type="password" required placeholder="Password" v-model="password">
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
<script setup>
import {ref} from 'vue';
import axios from "axios";
import {createRouter as router} from "vue-router";

const username = ref('');
const password = ref('');
const passwordConfirm = ref('');
const passwordsMatch = ref(true);

async function handleClick() {
  await axios.post("https://localhost:44420/api/auth/login", JSON.stringify({
    Username: username.value,
    Password: password.value,
    ConfirmPassword: passwordConfirm.value
  }), {
    headers: {
      "Content-Type": "application/json"
    }
  }).then(() => {
    router.push("/");
  }).catch(() => {
    console.log("An error occured while creating the account. Please try again later.")
  })
}
</script>

<template>
  <h1>Create a new account</h1>
  <form class="form-group">
    <input type="text" required placeholder="Username" v-model="username">
    <br>
    <input type="password"
           required 
           placeholder="Password"
           v-model="password"
           :class="passwordsMatch ? '' : 'invalid'"
    >
    <br>
    <input type="password"
           required
           placeholder="Confirm password"
           v-model="passwordConfirm"
           v-on:blur="passwordsMatch = password === passwordConfirm"
           :class="passwordsMatch ? '' : 'invalid'"
    >
    <br>
    <p v-if="!passwordsMatch">Passwords do not match!</p>
    <button type="button" :disabled="!passwordsMatch" @click="handleClick">Register</button>
  </form>
</template>

<style scoped>
input {
  margin: 5px;
  border-radius: 5px;
}

.invalid {
  border: 2px solid red;
}
</style>
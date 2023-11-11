<script setup>
import {ref} from 'vue';

const username = ref('');
const password = ref('');
const passwordConfirm = ref('');
const passwordsMatch = ref(true);

async function handleClick() {
  await fetch("https://localhost:44420/api/auth/register",
      {
        method: "POST",
        body: JSON.stringify({
              Username: username.value,
              Password: password.value,
              ConfirmPassword: passwordConfirm.value
            }
        ),
        headers: {
          "Content-Type": "application/json"
        },
      })
      .then((response) => {
        console.log(response);
        response.json().then((data) => {
          console.log(data.message)
        }).catch(() => console.log("An error has occured, please try again."))
      })
}
</script>

<template>
  <h1>Create a new account</h1>
  <form class="form-group">
    <input type="text" required placeholder="Username" v-model="username">
    <br>
    <input type="password" required placeholder="Password" v-model="password">
    <br>
    <input type="password" required placeholder="Confirm password" v-model="passwordConfirm" v-on:blur="passwordsMatch = password === passwordConfirm">
    <br>
    <p v-if="!passwordsMatch">Passwords do not match!</p>
    <button type="button" :disabled="!passwordsMatch" @click="handleClick">Register</button>
  </form>
</template>

<style scoped>
input {
  margin: 5px;
}
</style>
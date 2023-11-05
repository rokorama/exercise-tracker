<script setup>
</script>

<template>
  <div id="app">
    <header>
      <ul>
        <li><router-link to="/">Exercise Tracker</router-link></li>
        <li id="user-button"><router-link to="/login">Login</router-link></li>
      </ul>
    </header>
    <div id="router-view">
      <router-view />
    </div>
  </div>
</template>

<style scoped>
header {
  background-color: #9294cb;
  top: 0;
  width: 100%;
  position: fixed;
}

#router-view {
  height: 100%;
}

ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  overflow: hidden;
}

li {
  float: left
}

#user-button {
  float:right
}

li a {
  display: block;
  color: white;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
}
</style>

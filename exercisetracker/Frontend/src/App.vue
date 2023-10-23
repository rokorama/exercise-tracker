<script setup>
import {onMounted, ref} from 'vue'

const result = ref({test: ""});
onMounted(async () => {
  console.log('ima fetch')
  result.value = await (await fetch("/api/test")).json();
})
</script>

<template>
  <div>
    <p>Result: {{ result.test}}</p>
  </div>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>

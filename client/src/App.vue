<template>
  <div class="background-container">
    <h1 class="">hello, world</h1>
  </div>
</template>

<script>
export default {
  name: 'App',
}
</script>





<style>
html, body {
  margin: 0;
  padding: 0;
}
</style>

<style scoped>
.background-container{
  width: 100%;
  min-height: 100vh;
  background-image: url('@/assets/bg-image.jpg');
  background-size: cover;
  background-position: center;
}
</style>

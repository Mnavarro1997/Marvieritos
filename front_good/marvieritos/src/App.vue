<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App"/>
  <div id="nav">
    <router-view>
    <router-link to="/home">Home</router-link> |
      <router-link to="/products">Products</router-link> |
      <router-link to="/cart">Cart</router-link>
    </router-view>

    </div>
    <h1 v-if="isMock">Working with MOCK data</h1>
    
</template>

<script>

export default {
  created(){
    fetch(("https://localhost:44330/api/Products"))
  },
  computed: {
    isMock() {
      return process.env.VUE_APP_API_IS_MOCK === "true"
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>

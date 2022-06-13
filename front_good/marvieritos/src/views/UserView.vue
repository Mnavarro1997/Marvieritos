<template>
<h1>LOGEATE ESTA Y LA OTRA</h1>
<div class="login">
  <input type="text" v-model = "email" placeholder="Introduce email"/>
  <input type="password" v-model = "password" placeholder="Introduce contraseña"/>
  <button>Login</button> 
</div>
       
</template>
<script>

export default {
  data()
  {
    return{
      email: '',
      password: '',
      users : [],
      products: []
    }
  },
  methods: {
    async login(){
      let result = console.warn(this.email, this.password)
        this.$router.push({name: 'Product'})
        console.warn(result)
      }
      
    },
  created(){
    fetch(`https://localhost:44330/api/Users?email=${this.email}&password=${this.password}`)
      .then((result) => result.json())
      .then((data) => (this.users = data)),
    fetch('https://localhost:44330/api/Products')
      .then(result => result.json())
      .then(data => this.products = data)
    },
}
</script>
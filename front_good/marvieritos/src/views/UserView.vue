<template>
<body>

    <form action="#">
      <div class="field email">
        <div class="input-area">
          <input type="text" placeholder="Email">
          <i class="icon fas fa-envelope"></i>
          <i class="error error-icon fas fa-exclamation-circle"></i>
        </div>
      </div>
      <div class="field password">
        <div class="input-area">
          <input type="password" placeholder="Password">
          <i class="icon fas fa-lock"></i>
          <i class="error error-icon fas fa-exclamation-circle"></i>
        </div>

      </div>
          <div class="error error-txt">¿Ha olvidado su contraseña?</div>
      <div class="comprar">
                <router-link :to="{ name: 'Home' }">
                <b-button class="boton">
                  <h1>Login</h1>
                </b-button>
                </router-link>
            </div>
    </form>
<div class="comprar">
                <router-link :to="{ name: 'Registro' }">
                <b-button class="bt">
                  <h1>Crear Cuenta</h1>
                </b-button>
                </router-link>
            </div>
</body>

</template>
<script>

export default {
  created(){
    fetch('https://localhost:44330/api/Users')
      .then((result) => result.json())
      .then((data) => (this.users = data)),
    fetch('https://localhost:44330/api/Products')
      .then(result => result.json())
      .then(data => this.products = data)
    },
  data() {
    return {
      email: '',
      password: '',
      users: [],
      products: []
    };
  },
};
</script>
<style>
form{
  height: 310px;
  margin-top: 50px;
  text-align: center;
  
}

.field{
  margin-bottom: 5px;
}
</style>
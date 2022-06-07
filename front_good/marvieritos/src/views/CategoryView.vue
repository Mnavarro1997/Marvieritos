<template>
  <div class="home">
    <div class="listadoProducto">
      <div class="producto" v-for="product in products" :key="product.categoryId">
        <div class="imgProducto">
          <img v-bind:src="product.urlImg">
          
        </div>
        <div class="datosProducto">
          <h1>{{product.name}}</h1><br/>
          <h2>{{product.price}}€</h2>
          <router-link :to="{ name: 'Product', params: { id: product.id } }">
            <b-button class="botonDetalles">
              Detalles
            </b-button>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  created() {
    this.getCategoryById(this.$route.params.id);
  },
  beforeRouteUpdate(to) {
    this.getCategoryById(to.params.id);
  },
  data() {
    return {
      categories: [],
      products: []
    };
  },
  methods: {
    getCategoryById(categoryId) {
      fetch('https://localhost:44330/api/Products/category/' + categoryId)
        .then((result) => result.json())
        .then((data) => (this.products = data));
    }
  },
};
</script>

<style>
.listadoProducto{
  margin: 0 auto;
  text-align: left;
  width: 50%;
}

.producto{
  margin-top: 15px;
  display: flex;
}

.datosProducto{
  margin: auto;
  text-align: center;
}

.botonDetalles{
  color: black;
}
</style>
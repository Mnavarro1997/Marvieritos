<template>
  <div class="tituloNovedades">
    <img src="../images/corazon.jpg" alt="corasao" style="height: 35px; margin-right: 10px;">
    <b>Novedades</b>
    <img src="../images/corazon.jpg" alt="corasao" style="height: 35px; margin-left: 10px;">
  </div>
  <div class="novedades">
    <div v-for="product in products" :key="product.id">
        <div v-if="product.id>0 && product.id<6" class="novedad">
          <router-link :to="{ name: 'Product', params: { id: product.id } }">
            <b-button>
              <img class="imgenNovedad" :src="product.urlImg" alt="">
              <p><b>{{product.name}} - {{product.price}}€</b></p>
            </b-button>
          </router-link>
        </div>
    </div>
  </div>
  <div class="divVerProductos">
    <div class="comprar">
      <router-link :to="{ name: 'Category'}">
      <b-button class="boton">
        <h1>Ver productos</h1>
      </b-button>
      </router-link>
    </div> 
  </div>
  <div class='rowa'>
    <div class="columna"
      v-for="category in categories"
      :key="category.id">
      <div class="hola">
        <router-link :to="{ name: 'Category'}">
        <img class="imgenCategoria" :src="category.description" alt="">
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {

  components: {},
  created() {
    fetch('https://localhost:44330/api/Categories')
      .then((result) => result.json())
      .then((data) => (this.categories = data)),
    fetch('https://localhost:44330/api/Products')
      .then((result) => result.json())
      .then((data) => (this.products = data))
  },
  data() {
    return {
      categories: [],
      products: []
    };
  },
};
</script>

<style>
.tituloNovedades{
  margin-top: 25px;
  display: flex;
  font-size: 35px;
  justify-content: center;
}

.rowa {
  display: flex;
  flex-wrap: wrap;
  margin-top: 50px;
  justify-content: space-around;
}

.columna {
  margin-top: 25px;
}

.imgenCategoriaa{
  border-radius: 5px;
  box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.2);
}

.comprar {
  width: 210px;
  box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.2);
  height: 56px;
  margin: 0 auto;
  background-image: url('../images/fondoBotonLadrillos.jpg');
  text-align: center;
}

.boton {
  font-family: 'New Super Mario Font U', sans-serif;
  color: rgb(0, 0, 0);
  text-shadow: 3px 0 0 rgb(255, 255, 255), -3px 0 0 rgb(255, 255, 255), 0 3px 0 rgb(255, 255, 255), 0 -3px 0 rgb(255, 255, 255), 2px 2px rgb(255, 255, 255), -2px -2px 0 rgb(255, 255, 255), 2px -2px 0 rgb(255, 255, 255), -2px 2px 0 rgb(255, 255, 255);
  font-size: 12px;
  box-shadow: 2px 2px 2px 1px rgba(0, 0, 0, 0.4);
  text-align: center;
  vertical-align: middle;
  line-height: 56px;
}

.divVerProductos{
  padding-top: 50px;
}

.spanVerProductos{
  color: black;
}

.novedades{
  display: flex;
  margin: 0 auto;
  margin-top: 80px;
  align-items: center;
  justify-content: center;
  height: 150px;
}

.novedad{
  padding: 15px;
  box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.2);
  border-radius: 7px;
  margin-left: 50px;
}

.novedad p{
  color: black;
  font-size: 17px;

}

.imgenNovedad{
  height: 150px;
}

.listaCategorias{
  margin: 0 auto;
}

.categoria{
  margin-top: 50px;
}

.imgenCategoria{
  border-radius: 5px;
  box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.2);
}

/* Clear floats after the columns */
.row {
  display: grid;
  grid-template-columns: 1fr 1fr;
  
}
@media only screen and (max-width: 600px) {
.novedades{
    display: inline;
    text-align: center;
}

.imgenCategoria{
  height: 120px;
}

}
</style>
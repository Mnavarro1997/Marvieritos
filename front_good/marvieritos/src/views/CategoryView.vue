<template>
    <div class='rowListProducts'>
      <div class="columnaListProducts" v-for="product in products" :key="product.id" v-on:click="editar(product.id)">
        <div class="divEachProduct">
          <img class="imgenCategoriaa" :src="product.urlImg" alt="">
          <p><b>{{product.name}} - {{product.price}}€</b></p>
          <div class="divVerProductos">
              <div class="comprar">
                <router-link :to="{ name: 'Product', params: { id: product.id} }">
                <b-button class="boton">
                  <h1>Detalles</h1>
                </b-button>
                </router-link>
              </div>
          </div>
        </div>
        <hr>
      </div>
    </div>
</template>

<script>

export default {
  created() {
      fetch('https://localhost:44330/api/Products')
        .then(result => result.json())
        .then(data => this.products = data)
    },
    data() {
    return {
      products: [],
      data: []
    };
  },
  methods: {
    editar(id){
      this.$router.push('/product/' + id);
    },
    viewProduct(product){
      this.product = product
      this.active.product_drawer = true;
      console.log(this.product);
    },
    closeProductDrawer(){
      this.active.product_drawer = false;
    },
    getProduct(id){
      let data = fetch('https://localhost:44330/api/Products/' + id)
      .then(response=> response.json())
      .then(data=> data.filter(product=> product.id == id))
      .then(data=> {
          if(data.length > 0){
              return data[0]
          }else{
              return null
          }
      })
      return data

    }
  },
  asyncComputed:{
    async quantity(){
      let p = await this.getProduct(this.product.id)
      console.log(p);
      return p.quantity
    }       
  },
  computed:{
    rows() {
        return this.items.length
      },
    actualItems(){
      return this.items.slice(this.currentPage*6 -6, this.currentPage*6)
    }
  }

}
</script>


<style>
.rowListProducts {
  display: flex;
  justify-content: space-around;
  text-align: center;
}

.columnaListProducts {
margin-top: 30px;
}

.divEachProduct{
  padding-top: 50px;
  box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.2);
  border-radius: 5px;
  height: 350px;
  width: 300px;
}

.imgenCategoriaa{
  height: 150px;
}

.column {
  float: left;
  margin-left: 40px;
  width: 30%;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

.cositaimg{
  height: 100px;
}
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
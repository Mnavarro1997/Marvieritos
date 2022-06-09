<template>
  <div class="home">
    <div class="row">
        <div class="column" v-for="product in products" :key="product.id">
          <div class="producto">
            <div class="wrapper">
              <div>
                <div class="divImagen" ng-repeat="a in modules">
                  <div class="overlay">
                      <div class="carrusel" style="display: flex">
                          <img class="imgProductoHover" :src="product.urlImg" />
                      </div>
                  </div>
                </div>
              </div>
            <div>
            </div>
          </div>
          <div class="divVerProductos">
            <router-link :to="{ name: 'Product', params: { id: product.id } }">
              <div class="comprar">
                <b-button class="boton">
                  <h1>Detalles </h1>
                  <img class="imgenNovedad" :src="product.urlImg" alt="">
                <p><b>{{product.name}} - {{product.price}}€</b></p>
                </b-button>
              </div>
            </router-link>  
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
      <!--
    <div class="listadoProducto">
      <div class="producto" v-for="product in products" :key="product.id">
        <div class="imgProducto">
          <img v-bind:src="product.urlImg">
          
        </div>
        <div class="datosProducto">
          <h1>{{product.name}}</h1><br/>
          <h2>{{product.price}}€</h2>
          <router-link :to="{ name: 'Carts' }">
          <b-button
                    @click="anadirCarrito(product.id, product.name, product.price)"
                    style="
                      width: 40%;
                      margin-left: 13%;
                      background-color: purple;
                      color: white;">
                    <b>Añadir</b>
            </b-button>
            <b-button class="botonDetalles">
              Detalles
            </b-button>
          </router-link>
        </div>
      </div>
    </div>
    -->


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
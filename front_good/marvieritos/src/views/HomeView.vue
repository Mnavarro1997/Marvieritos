<template>
  <div class="home">
    <HomeComponent msg="Listado de juegos"/>
        <select name="my_html_select_box">
          <option selected="yes"> - Selecciona una categoría - </option>
          <option>RTS - Real-Time Strategy</option>
          <option>FPS - First Person Shooter</option>
          <option>MOBA - Multiplayer Online Battle Arena</option>
          <option>RP - Role-Playing</option>
        </select>
    <input type="submit" id="lname" value="Buscar">
  </div>
</template>

<script>
// @ is an alias to /src

export default {

 data(){
    let orderProduct = async () =>{
            return await this.getProduct(this.product.id)
        }
    return {
      items: [],
      product:null,
      active: {
        product_drawer: false
      },
      orderProduct: orderProduct(),
      perPage: 6,
      currentPage: 1
    }

  },
  created() {
      fetch('http://localhost:44330/products')
        .then(result => result.json())
        .then(data => this.items = data)
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
      let data = fetch(`http://localhost:44330/cart`)
      .then(response=> response.json())
      .then(data=> data.filter(product=> product.product.id == id))
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

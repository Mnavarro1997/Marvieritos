<template>
      <header>
        <nav id="navArea">
            <router-link to="/">
            <div class="titulo">
                <p style="color: red;">M</p>
                <p style="color: rgb(55, 185, 16);">a</p>
                <p style="color: rgb(175, 0, 175);">r</p>
                <p style="color: rgb(0, 250, 175);">V</p>
                <p style="color: rgb(255, 126, 40);">i</p>
                <p style="color: rgb(227, 86, 255);">e</p>
                <p style="color: rgb(224, 221, 18);">r</p>
            </div>
            </router-link>
        </nav>
    </header>
  <router-view/>
  <footer>
      <br>
      <p>
        ¿Te gustaría alguna categoría que no aparece o algún producto concreto?<br>
        ¡ Mándanoslo y lo añadiremos !<br>
      </p>
      <input type="text" value="Artículo o categoría"> <input type="submit" value="Solicitar"><br>
        <h3>
            Y no te olvides de seguirnos en Instagram :)
        </h3>
        <a href="https://www.instagram.com/marvier.sa/">
            <img style="height: 40px;" src="./images/Insta.svg.png" alt="IG">
        </a>
        
      
      
  </footer>
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
  }
}
</script>

<style>

body {

    font-family: 'New Super Mario Font U', sans-serif;
    margin: 0 auto;
    width: 80%;
}


/* NAV MENU HEADER */
#navArea {
    display: flex;
    margin: 0 auto;
    margin-top: 2%;
    border-radius: 10px;
    width: 90%;
    height: 105px;
    background-image: url('./images/fondo.jpg');
    box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.4);
}

.titulo {
    display: flex;
    vertical-align: middle;
    line-height: 9px;
    padding-left: 75px;
}

.titulo p {
    font-size: 45px;
    text-shadow: 1px 0 0 white, 2px 0 0 black, -2px 0 0 black, 0 2px 0 black, 0 -2px 0 black, 1px 1px black, -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black;
}

.hamburger-menu h1 {
    text-align: right;
    font-size: 25px;
    background-color: red;
    text-shadow: 2px 0 0 white, -2px 0 0 white, 0 2px 0 white, -2px 0 white, 1px 1px white, -1px -1px 0 white, 1px -1px 0 white, -1px 1px 0 white;
}

main {
    text-align: center;
    margin: 0 auto;
}

footer{
    text-align: center;
    background: rgb(255, 255, 255);
    background: linear-gradient(180deg, rgba(255, 255, 255, 1) 5%, rgba(158, 158, 158, 1) 45%, rgba(0, 0, 0, 1) 100%);
}
footer h3{
    color: rgb(255, 200, 0);
    text-shadow: 1px 0 0 rgb(255, 0, 0);
}

@media only screen and (max-width: 600px) {
body{
    width: 100%;
}

}
</style>

<template>
  <div id="nav">
      <header>
        <nav id="navArea">
            <div class="titulo">
                <p style="color: red;">M</p>
                <p style="color: rgb(55, 185, 16);">a</p>
                <p style="color: rgb(175, 0, 175);">r</p>
                <p style="color: rgb(0, 250, 175);">V</p>
                <p style="color: rgb(255, 126, 40);">i</p>
                <p style="color: rgb(227, 86, 255);">e</p>
                <p style="color: rgb(224, 221, 18);">r</p>
            </div>
            <div class="hamburger-menu">
                <h1><router-link to="/">Página principal</router-link></h1>
            </div>
        </nav>
    </header>
  </div>
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
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
body {
    font-family: 'New Super Mario Font U', sans-serif;
    margin: 0 auto;
    width: 90%;
}

header {
    z-index: 30;
}




/* NAV MENU HEADER */

.hamburger-menu h1 {
    margin-left: 250px;
    margin-top: 30px;
    font-size: 25px;
    text-shadow: 2px 0 0 white, -2px 0 0 white, 0 2px 0 white, -2px 0 white, 1px 1px white, -1px -1px 0 white, 1px -1px 0 white, -1px 1px 0 white;
}

#menu__toggle {
    opacity: 0;
}

#menu__toggle:checked+.menu__btn>span {
    transform: rotate(45deg);
}

#menu__toggle:checked+.menu__btn>span::before {
    top: 0;
    transform: rotate(0deg);
}

#menu__toggle:checked+.menu__btn>span::after {
    top: 0;
    transform: rotate(90deg);
}

#menu__toggle:checked~.menu__box {
    right: 0 !important;
}

.menu__btn {
    position: fixed;
    top: 75px;
    left: 87%;
    width: 26px;
    height: 26px;
    cursor: pointer;
    z-index: 1;
}

.menu__btn>span,
.menu__btn>span::before,
.menu__btn>span::after {
    display: block;
    position: absolute;
    right: 0;
    width: 100%;
    height: 2px;
    background-color: #000000;
    transition-duration: .25s;
}

.menu__btn>span::before {
    content: '';
    top: -8px;
}

.menu__btn>span::after {
    content: '';
    top: 8px;
}

.menu__box {
    position: absolute;
    right: -300px;
    width: 250px;
    border: 1px solid #000;
    margin: 0;
    padding: 20px 0;
    list-style: none;
    background-color: #2d97dd;
    box-shadow: 2px 2px 6px rgba(0, 0, 0, .4);
    transition-duration: 0.25s;
}

.menu__item {
    display: block;
    padding: 12px 24px;
    font-size: 25px;
    font-weight: 600;
    text-decoration: none;
    transition-duration: .25s;
    text-shadow: 1px 0 0 rgb(255, 255, 255), -1px 0 0 rgb(255, 255, 255), 0 1px 0 rgb(255, 255, 255), 0 -1px 0 rgb(255, 255, 255), 1px 1px rgb(255, 255, 255), -1px -1px 0 rgb(255, 255, 255), 1px -1px 0 rgb(255, 255, 255), -1px 1px 0 rgb(255, 255, 255);
}

.VideoPane-video {
    position: absolute;
    top: 50%;
    left: 50%;
    -webkit-transform: translate(-50%, -50%);
    transform: translate(-50%, -50%);
    height: auto;
    min-height: 100%;
    min-width: 100%;
    width: auto
}

.VideoPane-content {
    position: relative;
    z-index: 0
}


#myVideo {
    right: 0;
    bottom: 0;
    min-width: 100%;
    min-height: 100%;
}

main {
    text-align: center;
    margin: 0 auto;
}

.titulo {
    display: flex;
    margin-top: -60px;
    margin-left: 250px;
}

.titulo p {
    font-size: 70px;
    text-shadow: 1px 0 0 white, 2px 0 0 black, -2px 0 0 black, 0 2px 0 black, 0 -2px 0 black, 1px 1px black, -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black;
}

#navArea {
    display: grid;
    margin: 0 auto;
    grid-template-columns: 70% 30%;
    justify-content: space-between;
    border-radius: 10px;
    width: 80%;
    height: 105px;
    top: 0px;
    background-image: url('./images/fondo.jpg');
    box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.4);
}

footer h3{
    color: rgb(255, 200, 0);
    text-shadow: 1px 0 0 rgb(255, 0, 0);
}
</style>

<template>
  <div class="home">
    <Product msg="Welcome to Your Vue.js App"/>
    
  </div>
</template>

<script>
// @ is an alias to /src
import Product from '@/components/Product.vue'

export default {
  name: 'TodoProduct',
  components: {
    Product
  },

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
      fetch('http://localhost:44330/product')
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
<style>
body {
    font-family: 'New Super Mario Font U', sans-serif;
    margin: 0 auto;
    background-color: rgb(250, 250, 250);
}

header {
    z-index: 30;
}

main {
    z-index: 4;
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


/* FIN MENU HEADER */

#myVideo {
    right: 0;
    bottom: 0;
    min-width: 100%;
    min-height: 100%;
}

.marines {
    background-image: url('../images/SpaceMarines2/wallpaperSM.jpg');
    background-repeat: no-repeat;
    background-size: auto;
}

.nier {
    background-image: url('../images/NierAutomata/wallpaperNier.jpg');
    background-repeat: no-repeat;
    background-size: auto;
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
    background-image: url('../images/fondo.jpg');
    box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.4);
}

.cuerpo {
    padding-top: 130px;
    display: block;
    width: 90%;
    margin-left: auto;
    margin-right: auto;
}

.productoYvideo {
    margin: 0 auto;
    border-radius: 5px;
    width: 70%;
    box-shadow: 3px 3px 3px 1px rgba(0, 0, 0, 0.4);
    /*background-color: rgb(161, 173, 255);*/
    background-image: linear-gradient(to right, transparent, rgb(255, 255, 255));
}

.video {
    margin: 5%;
}


/*  Producto  */

.producto {
    display: grid;
    grid-template-columns: 40% 40% 20%;
}

.wrapper {
    display: grid;
    grid-template-columns: 80% 20%;
}

.imgProducto {
    width: 90%;
    margin: 5%;
    box-shadow: 2px 2px 2px 1px rgba(0, 0, 0, 0.4);
}

.link {
    margin-top: 50%;
    align-items: center;
}

.lista {
    margin-left: 20px;
}

a {
    text-decoration: none;
}

.nombreFigura {
    margin-top: 100%;
    text-align: center;
}

.nombreFigura h3 {
    font-size: 32px;
    text-shadow: 2px 0 0 rgb(255, 255, 255), -2px 0 0 rgb(255, 255, 255), 0 2px 0 rgb(255, 255, 255), 0 -2px 0 rgb(255, 255, 255), 1px 1px rgb(255, 255, 255), -1px -1px 0 rgb(255, 255, 255), 1px -1px 0 rgb(255, 255, 255), -1px 1px 0 rgb(255, 255, 255);
}

.nombreFigura h2 {
    font-size: 25px;
    text-shadow: 2px 0 0 rgb(255, 255, 255), -2px 0 0 rgb(255, 255, 255), 0 2px 0 rgb(255, 255, 255), 0 -2px 0 rgb(255, 255, 255), 1px 1px rgb(255, 255, 255), -1px -1px 0 rgb(255, 255, 255), 1px -1px 0 rgb(255, 255, 255), -1px 1px 0 rgb(255, 255, 255);
}

.comprar {
    text-align: center;
}

.boton {
    background-image: url('../images/fondoBotonLadrillos.jpg');
    height: 60px;
    font-family: 'New Super Mario Font U', sans-serif;
    color: rgb(0, 0, 0);
    text-shadow: 3px 0 0 rgb(255, 255, 255), -3px 0 0 rgb(255, 255, 255), 0 3px 0 rgb(255, 255, 255), 0 -3px 0 rgb(255, 255, 255), 2px 2px rgb(255, 255, 255), -2px -2px 0 rgb(255, 255, 255), 2px -2px 0 rgb(255, 255, 255), -2px 2px 0 rgb(255, 255, 255);
    font-size: 25px;
    box-shadow: 2px 2px 2px 1px rgba(0, 0, 0, 0.4);
    width: 220px;
}

.img {
    margin-left: 2.5%;
    width: 80px;
    height: auto;
    visibility: hidden;
}

.linkYComprar {
    margin-right: 50px;
}

.coin {
    width: 50px;
    margin-left: 2%;
}

.ope h3 {
    font-size: 25px;
    text-shadow: 2px 0 0 rgb(255, 255, 255), -2px 0 0 rgb(255, 255, 255), 0 2px 0 rgb(255, 255, 255), 0 -2px 0 rgb(255, 255, 255), 1px 1px rgb(255, 255, 255), -1px -1px 0 rgb(255, 255, 255), 1px -1px 0 rgb(255, 255, 255), -1px 1px 0 rgb(255, 255, 255);
}

p a {
    color: white;
    text-shadow: 2px 0 0 black, -2px 0 0 black, 0 2px 0 black, 0 -2px 0 black, 1px 1px black, -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black;
    font-size: 20px;
    text-decoration: none;
    display: inline-block;
    position: relative;
}

a.efectoLinea:after {
    content: '';
    position: relative;
    left: 0;
    display: inline-block;
    height: 1em;
    width: 100%;
    border-bottom: 2px solid black;
    margin-top: 5px;
    opacity: 0;
    -webkit-transition: opacity 0.35s, -webkit-transform 0.35s;
    transition: opacity 0.35s, transform 0.35s;
    -webkit-transform: scale(0, 1);
    transform: scale(2);
}

a.efectoLinea:hover:after {
    opacity: 1;
    -webkit-transform: scale(1);
    transform: scale(1);
}


/* probando imagen */

.overlay {
    display: none;
    margin-top: 7%;
    margin-left: 12%;
}

.divImagen:hover .overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 1275px;
    background: rgba(1, 0, 0, 0.2);
    overflow: auto;
    display: inline-block;
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
    z-index: 3;
}

.imgProducto {
    height: 350px;
    width: 300px;
}

.imgProductoHover {
    margin: 1%;
    height: 450px;
    width: 400px;
}

h4,
small,
a {
    margin: 0;
    padding: 0;
    color: white;
    backdrop-filter: blur(5px);
    border-radius: 20px;
}

a {
    text-decoration: none;
}

iframe {
    border-radius: 5px;
}

.Carousel {
    align-items: center;
    padding-bottom: 40px;
}

.Carousel h2 {
    font-size: 26px;
    line-height: 38px;
    padding: 24px;
    opacity: .9;
    text-transform: uppercase;
    letter-spacing: 10px;
    text-align: center;
    color: white;
    text-shadow: 2px 0 0 black, -2px 0 0 black, 0 2px 0 black, 0 -2px 0 black, 1px 1px black, -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black;
}

.recommendations {
    display: flex;
    font-size: 40px;
    justify-content: center;
    text-shadow: 0.5px 0 0 white, -2px 0 0 black, 0 2px 0 black, 0 -2px 0 black, 1px 1px black, -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black;
}

.linkPage {
    color: #ec0a0a;
}


/* images */

.slick-list {
    position: relative;
    display: flex;
    align-items: center;
    width: fit-content;
    margin: 0px auto;
    max-width: 65vw;
    overflow: hidden;
}

.maaaario {
    background-color: black;
    border-radius: 50px;
    margin-top: 2px;
}

.slick-track {
    position: relative;
    top: 0;
    left: 0;
    display: flex;
    justify-content: center;
    transition: .5s ease-in-out;
}

.slick {
    position: relative;
    width: 275px;
    padding: 0 18px;
    float: left;
    box-sizing: border-box;
    display: flex;
    height: 100%;
}

.slick h4 {
    position: absolute;
    z-index: 1;
    font-size: 22px;
    line-height: 23px;
    color: white;
    margin-top: 10px;
    margin-left: 10px;
    padding: 5px;
    text-shadow: 2px 0 0 black, -2px 0 0 black, 0 2px 0 black, 0 -2px 0 black, 1px 1px black, -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black;
}

.slick h4 small {
    font-size: 15px;
    display: block;
}

.slick h3 {
    text-shadow: 2px 0 0 black, -2px 0 0 black, 0 2px 0 black, 0 -2px 0 black, 1px 1px black, -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black;
    position: absolute;
    z-index: 1;
    margin-top: 240px;
    margin-left: 10px;
}

.slick h3 small {
    font-size: 22px;
    padding: 5px;
    display: block;
}

.slick a img {
    object-fit: cover;
    height: 300px;
    width: 100%;
    border-radius: 4px;
    box-shadow: 0 2px 5px 0 rgba(0, 0, 0, .5);
}

.slick:hover {
    transform: scale(0.90);
    transition: .3s ease-in-out;
}


/* buttons */

.slick-arrow {
    border-radius: 30px;
    background-color: #fff;
    position: absolute;
    z-index: 4;
    width: 48px;
    height: 48px;
    text-align: center;
    box-shadow: 0 2px 5px 0 rgba(0, 0, 0, .15);
    border: 0;
    cursor: pointer;
}

.slick-arrow:focus {
    outline: 0;
}

.slick-arrow svg {
    width: 12px;
    height: 100%;
    color: rgba(0, 0, 0, .7);
}

.slick-prev {
    left: 0px;
}

.slick-next {
    right: 0px;
}

footer {
    height: 220px;
    background: rgb(255, 255, 255);
    background: linear-gradient(180deg, rgba(255, 255, 255, 1) 5%, rgba(158, 158, 158, 1) 45%, rgba(0, 0, 0, 1) 100%);
}
</style>
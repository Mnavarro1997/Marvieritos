<template>
  <div class="home" >
        <div class="productito" v-if="product" style="display: flex;">
          <img class="imgenProductito" :src="product.urlImg" alt="">
          <div class="datosProductito">
            <h1>{{product.name}}</h1><br>
            <h2>{{product.price}}€</h2><br>
            <div class="descripcionProductito">
                {{product.description}}
            </div>
            <div class="comprar">
                <router-link :to="{ name: 'Cart', params: { id: product.id} }">
                <b-button class="boton">
                  <h1>Comprar</h1>
                </b-button>
                </router-link>
            </div>
          </div>
        </div>
      <div class="recommendations" style="padding-top: 50px;">
          <p style="color: red;">R</p>
          <p style="color: rgb(55, 185, 16);">e</p>
          <p style="color: rgb(175, 0, 175);">c</p>
          <p style="color: rgb(0, 250, 175);">o</p>
          <p style="color: rgb(255, 126, 40);">m</p>
          <p style="color: rgb(227, 86, 255);">m</p>
          <p style="color: rgb(224, 221, 18);">e</p>
          <p style="color: red;">n</p>
          <p style="color: rgb(55, 185, 16);">d</p>
          <p style="color: rgb(175, 0, 175);">a</p>
          <p style="color: rgb(0, 250, 175);">t</p>
          <p style="color: rgb(255, 126, 40);">i</p>
          <p style="color: rgb(227, 86, 255);">o</p>
          <p style="color: rgb(224, 221, 18);">n</p>
          <p style="color: red;">s</p>
      </div>
      <div class="Carousel" style="background-color: white; padding-top: 20px;">
          <div class="slick-list" id="slick-list">
              <button class="slick-arrow slick-prev" id="button-prev" data-button="button-prev" onclick="app.processingButton(event)">
                  <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-left" class="svg-inline--fa fa-chevron-left fa-w-10" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512"><path fill="currentColor" d="M34.52 239.03L228.87 44.69c9.37-9.37 24.57-9.37 33.94 0l22.67 22.67c9.36 9.36 9.37 24.52.04 33.9L131.49 256l154.02 154.75c9.34 9.38 9.32 24.54-.04 33.9l-22.67 22.67c-9.37 9.37-24.57 9.37-33.94 0L34.52 272.97c-9.37-9.37-9.37-24.57 0-33.94z"></path></svg>
              </button>
              <div class="slick-track" id="track">
                  <div class="slick">
                      <div>
                          <a href="/">
                              <h4><small>League of Legends</small>Cup</h4>
                              <h3><small>12€</small></h3>
                              <picture>
                                  <img src="../images/LeagueOfLegends/cup.jpg" alt="Image">
                              </picture>
                          </a>
                      </div>
                  </div>
                  <div class="slick">
                      <div>
                          <a href="/">
                              <h4><small>League of Legends</small>Cosplay costume</h4>
                              <h3><small>90€</small></h3>
                              <picture>
                                  <img src="../images/LeagueOfLegends/syndracosplay.jpg" alt="Image">
                              </picture>
                          </a>
                      </div>
                  </div>
                  <div class="slick">
                      <div>
                          <a href="/">
                              <h4><small>League of Legends</small>Picture</h4>
                              <h3><small>18€</small></h3>
                              <picture>
                                  <img src="../images/LeagueOfLegends/poster.jpg" alt="Image">
                              </picture>
                          </a>
                      </div>
                  </div>
                  <div class="slick">
                      <div>
                          <a href="/">
                              <h4><small>League of Legends</small>Tshirt</h4>
                              <h3><small>16€</small></h3>
                              <picture>
                                  <img src="../images/LeagueOfLegends/camiseta.jpg" alt="Image">
                              </picture>
                          </a>
                      </div>
                  </div>
                  <div class="slick">
                      <div>
                          <a href="/">
                              <h4><small>League of Legends</small>Key chain</h4>
                              <h3><small>9€</small></h3>
                              <picture>
                                  <img src="../images/LeagueOfLegends/rivenkeychain.jpg" alt="Image">
                              </picture>
                          </a>
                      </div>
                  </div>
                  <div class="slick">
                      <div>
                          <a href="/">
                              <h4><small>League of Legends</small>Phone case</h4>
                              <h3><small>10€</small></h3>
                              <picture>
                                  <img src="../images/LeagueOfLegends/phonecase.jpg" alt="Image">
                              </picture>
                          </a>
                      </div>
                  </div>
              </div>
              <button class="slick-arrow slick-next" id="button-next" data-button="button-next" onclick="app.processingButton(event)">
                  <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-right" class="svg-inline--fa fa-chevron-right fa-w-10" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512"><path fill="currentColor" d="M285.476 272.971L91.132 467.314c-9.373 9.373-24.569 9.373-33.941 0l-22.667-22.667c-9.357-9.357-9.375-24.522-.04-33.901L188.505 256 34.484 101.255c-9.335-9.379-9.317-24.544.04-33.901l22.667-22.667c9.373-9.373 24.569-9.373 33.941 0L285.475 239.03c9.373 9.372 9.373 24.568.001 33.941z"></path></svg>
              </button>
          </div>
      </div>
    </div>
</template>

<script>
export default {
    props: ['id'],
    data(){
        return{
            product: null
        }
    },
    mounted(){
        fetch("https://localhost:44330/api/Products/" + this.id)
        .then(res => res.json())
        .then(data => this.product = data)
    }
}
</script>



<style>
.rowListProducts {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  width: 100%;
  margin-top: 20px;
}

.columnaListProducts {
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  flex-basis: 100%;
  flex: 1;
}

.productito{
  margin: 0 auto;
  padding-top: 50px;
  box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.2);
  border-radius: 5px;
  height: 500px;
  width: 60%;
}

.imgenProductito{
    box-shadow: 4px 4px 4px 2px rgba(0, 0, 0, 0.2);
    border-radius: 5px;
    height: 400px;
    margin-left: 20px;
}

.descripcionProductito{
    width: 80%;
    margin: 0 auto;
    margin-bottom: 60px;
}


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
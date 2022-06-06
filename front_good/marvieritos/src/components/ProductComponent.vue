<template>
<div class="product"  style= "background-color: grey"> 
    <div>
      <span style="color: white; font-size: 30px">
        <b> Productos</b>
      </span>
      <template>
        <div class="cuerpo" style="margin-top: 20px;">
          <div class="productoYvideo">
              <div class="producto">
                  <div class="wrapper">
                      <div>
                          <div class="divImagen" ng-repeat="a in modules">
                              <img class="imgProducto imgPro" src="../images/LeagueOfLegends/figuraA.jpg" />
                              <div class="overlay">
                                  <div class="carrusel" style="display: flex">
                                      <img class="imgProductoHover" src="../images/LeagueOfLegends/figuraA.jpg" />
                                      <img class="imgProductoHover" src="../images/LeagueOfLegends/figuraB.jpg" />
                                      <img class="imgProductoHover" src="../images/LeagueOfLegends/figuraC.jpg" />
                                  </div>
                              </div>
                          </div>
                      </div>
                      <div>
                          <div class="nombreFigura">
                              <h2>Personaje</h2>
                              <h3>Katarina</h3>
                              <h2>Precio</h2>
                              <h3>80€</h3>
                          </div>
                      </div>
                  </div>
                  <div class="infoProduct">
                      soy la info :v
                  </div>
                  <div class="linkYComprar">
                      <div class="link">
                          <div class="ope">
                              <h3>Relacionado:</h3>
                          </div>
                          <div class="wrapperLinks">
                              <p class="pOpening">
                                  <a class="efectoLinea" target="_blank" href="https://www.youtube.com/watch?v=Lb3Q5WwogFg&ab_channel=Emmasmackedraylikeahoe">
                                      - Videojuego -<br />
                                      Instalar desde la página oficial
                                  </a>
                              </p>
                          </div>
                      </div>
                      <div class="comprar">
                          <img id="demo2" class="img coin" src="../images/coin.gif" alt="">
                          <div class="button">
                              <input class="boton" id="demo" type="button" value="Add to cart" onclick="clickando();this.disabled=true; this.value='Successful !';">
                          </div>
                          <img id="demo3" class="img maaaario" src="../images/mariojumppng.png" alt="">
                      </div>
                  </div>
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
      </template>
    </div>
  </div>
</template>

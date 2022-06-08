<template>
  <div class="home"> 
    <h1>♥ Novedades ♥</h1>
    <!--

    <article v-if="isGuideVisible(guide)" :key="index" class="post-item post-guide"
              :class="[guide.categories.toString().replace(/,/g, ' ')]">
      <header>
        <h1 v-text="guide.title.rendered" />
      </header>
    </article>

    -->


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
    <div>
      <div class="row">
        <div class="column"
          v-for="category in categories"
          :key="category.id">
          <div class="categoria">
            <router-link :to="{ name: 'Category', params: { id: category.id } }">
              <b-button>
                <!--
                <img class="imgenCateroria" v-bind:src="'../images/' + category.id.toString() + '.jpg'">
                -->
                <img class="imgenCategoria" :src="category.description" alt="">
              </b-button>
            </router-link>
          </div>
        </div>
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
.novedades{
  display: flex;
  margin: 0 auto;
  margin-top: 80px;
  align-items: center;
  justify-content: center;
  width: 60%;
  height: 150px;
}

.novedad{
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

.column {
  float: left;
  width: 50%;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

</style>
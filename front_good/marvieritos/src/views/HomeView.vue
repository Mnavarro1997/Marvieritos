<template>
  <div class="home"> 
    <h1>Novedades</h1>
    <div class="novedades">
      <div v-for="category in categories" :key="category.id">
          <div class="novedad">
            <router-link :to="{ name: 'Category', params: { id: category.id } }">
              <b-button>
                <img class="imgenNovedad" src="../images/LeagueOfLegends/cup.jpg" alt="">
                <h2>{{category.name}}</h2>
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
                <img class="imgenCategoria" src="../images/1.jpg" alt="">
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
      .then((data) => (this.categories = data));
  },
  data() {
    return {
      categories: [],
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

.novedad h2{
  color: black;
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
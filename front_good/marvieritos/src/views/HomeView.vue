<template>
  <div class="home"> 
    <div class="novedades">
      
    </div>
    <div>
      <h2>Listado de categorías</h2>
      <div class="listaCategorias"
        v-for="category in categories"
        :key="category.id">
        <div class="categoria">
          <router-link :to="{ name: 'Category', params: { id: category.id } }">
            <b-button>
              <h2>{{ category.name }}</h2>
            </b-button>
          </router-link>
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
.listaCategorias{
  margin: 0 auto;
  width: 20%;
}

.categoria{
  height: 30px;
  margin-top: 15px;
}

.categoria h2{
  color: black;
}
</style>
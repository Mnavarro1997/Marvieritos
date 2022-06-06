<template>
  <div class="home">
      hola <br/>
      <li v-for="product in products" :key="product.categoryId">
        <b>{{product.name}}</b>
      </li>
         
      hola2
  </div>
</template>

<script>

export default {
  created() {
    this.getCategoryById(this.$route.params.id);
  },
  beforeRouteUpdate(to) {
    this.getCategoryById(to.params.id);
  },
  data() {
    return {
      categories: [],
    };
  },
  methods: {
    getCategoryById(categoryId) {
      fetch('https://localhost:44330/api/Products/category/' + categoryId)
        .then((result) => result.json())
        .then((data) => (this.products = data));
    }
  },
};
</script>
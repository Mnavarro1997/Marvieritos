<template>
  <div class="home"  style= "background-color: grey"> 
    <div>
      <span style="color: white; font-size: 30px">
        <b> Productos</b>
      </span>
        <div>
          <section>
            <ul>
              <li
                v-for="category in categories"
                :key="category.id">
                <p>
                  <b>{{ category.name }}</b>
                </p>
                <div style="display: flex">
                  <router-link :to="{ name: 'Category', params: { id: category.id } }">
                    <b-button>
                      <b>Detalles</b>
                    </b-button>
                  </router-link>
                </div>
              </li>
            </ul>
          </section>
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

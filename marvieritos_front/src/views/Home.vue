<template>
  <div class="home"  style= "background-color: grey"> 
    <div>
      <span style="color: white; font-size: 30px">
        <b> Productos</b>
      </span>
      <template>
        <div>
          <section class="wrapper">
            <ul class="products">
              <li
                style="
                  border: white 2px solid;
                  width: 300px;
                  display: inline-grid;
                  margin: 15px;
                "
                v-for="product in products"
                :key="product.id"
                class="products__product"
              >
                <img class="product-image" :src="product.mainImage" alt width="100%" />
                <p class="product-title" style="margin-top: 40px; font-size: 22px; font-family: Verdana;color: white">
                  <b>{{ product.name }}</b>
                </p>
                <p>
                  <em style="color: white;font-family: arial; font-size: 15px">{{ product.price }}€</em>
                </p>
                <div style="display: flex">
                  <router-link
                    :to="{ name: 'Details', params: { id: product.id } }"
                    style="text-decoration: none; width: 40%"
                  >
                    <b-button
                      style="
                        width: 100%;
                        background-color: salmon;
                        color: white;
                        margin-left: 15%;
                      "
                    >
                      <b>Detalles</b>
                    </b-button>
                  </router-link>
                  <b-button
                    @click="añadirCarrito(product.id, product.name, product.price)"
                    style="
                      width: 40%;
                      margin-left: 13%;
                      background-color: purple;
                      color: white;
                    "
                  >
                    <b>Añadir</b>
                  </b-button>
                </div>
              </li>
            </ul>
          </section>
        </div>
      </template>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'

import api_url from "../utils/api";

export default {
  name: "index",

  components: {},
  created() {
    fetch(api_url("/products"))
      .then((result) => result.json())
      .then((data) => (this.products = data));
  },
  data() {
    return {
      products: [],
    };
  },
  methods: {
    añadirCarrito(productId, productName, productPrice) {
      fetch(api_url("/cart/"), {
        method: "POST",
        body: JSON.stringify({
          productId: productId,
          productName: productName,
          quantity: 1,
          productPrice: productPrice,
        }),
        headers: {
          "Content-Type": "application/json",
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
      });
    },
  },
};
</script>

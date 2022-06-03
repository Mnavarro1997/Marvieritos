<template>
  <div class="products">
    <img alt="Vue logo" src="../assets/logo.png">
    <Product msg="Productos de nuestra página: "/>
    
  </div>
  </template>
<script>
import Product from '@/components/Product.vue';
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'


export default {
  name: "ProductView",

  components: { Product },
  created() {
    fetch("https://localhost:44330/api/Products")
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
      fetch("https://localhost:44330/api/Cart"), {
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
      };
    },
  },
};

</script>

<template>
  <div class="cart">
    <div class="contenidoCart">

        <b>Gracias por su compra</b>


    </div>
  </div>
</template>
<style>
.contenidoCart{
 height: 500px;
}
</style>
<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'


export default {

  components: {},
  created() {
    fetch("https://localhost:44330/api​/Carts")
      .then((result) => result.json())
      .then((data) => (this.products = data));
  },
  data() {
    return {
      products: [],
    };
  },
  methods: {
    upgradeQuantity(id, quantity, name, price) {
      fetch('https://localhost:44330/api​/Carts/' + id), {
        method: "PUT",
        body: JSON.stringify({
          id: id,
          name: name,
          quantity: quantity + 1,
          price: price,
        }),
        headers: {
          "Content-Type": "application/json",
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
      };
      fetch("https://localhost:44330/api​/Carts")
        .then((result) => result.json())
        .then((data) => (this.products = data));
    },
    degradeQuantity(id, quantity, name, price) {
      if (quantity > 1) {
        fetch("https://localhost:44330/api​/Carts/"+ id), {
          method: "PUT",
          body: JSON.stringify({
          id: id,
          name: name,
          quantity: quantity - 1,
          price: price,
          }),
          headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
          },
        };
        fetch("https://localhost:44330/api​/Carts")
          .then((result) => result.json())
          .then((data) => (this.products = data));
      } else {
        fetch('https://localhost:44330/api​/Carts/' + id), {
          method: "DELETE",
          body: JSON.stringify({
          id: id,
          name: name,
          quantity: quantity,
          price: price,
          }),
          headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
          },
        };
        fetch("https://localhost:44330/api​/Carts")
          .then((result) => result.json())
          .then((data) => (this.products = data));
      }
    },
    removeProduct(id, quantity, name, price) {
      fetch('https://localhost:44330/api​/Carts/'+ id), {
        method: "DELETE",
        body: JSON.stringify({
        id: id,
        name: name,
        quantity: quantity - 1,
        price: price,
        }),
        headers: {
          "Content-Type": "application/json",
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
      };
      fetch("https://localhost:44330/api​/Carts")
        .then((result) => result.json())
        .then((data) => (this.products = data));
    },
    totalProduct(price, quantity) {
      return parseFloat(price) * parseFloat(quantity);
    },
    submitOrder() {
      for (let i = 0; i < this.products.length; i++) {
        fetch("https://localhost:44330/api​/Order"), {
          method: "POST",
          body: JSON.stringify({
            id: this.products[i].id,
            name: this.products[i].name,
            quantity: this.products[i].quantity,
            price: this.products[i].price,
            totalProduct:
              this.products[i].quantity * this.products[i].price,
          }),
          headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
          },
        };
      }
      fetch("https://localhost:44330/api​/Order"), {
        method: "POST",
        body: JSON.stringify({
          totalOrder: this.totalCart,
        }),
        headers: {
          "Content-Type": "application/json",
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
      };
      for(let i = 0; i <= this.products.length+1; i++){
        fetch("https://localhost:44330/api​/Cart" + i), {
          method: "DELETE",
          body: JSON.stringify({}),
          headers: {
            "Content-Type": "application/json",
          },
        };
      }
    },
  },
  computed: {
    totalCart: function () {
      let sum = 0;
      for (let i = 0; i < this.products.length; i++) {
        sum +=
          parseFloat(this.products[i].productPrice) *
          parseFloat(this.products[i].quantity);
      }

      return sum;
    },
  },
};
</script>
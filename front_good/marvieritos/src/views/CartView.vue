<template>
    <div class="contenidoCart">
      <div>
      <h1>Gracias por su compra</h1>
      </div>
      <div>
<img src="../images/coin.gif" alt="" style="height: 60px;">
      </div>
      <div>
<img src="../images/mariojumppng.png" alt="" style="height: 150px;">
      </div>
    
    

    </div>
</template>
<style>
.contenidoCart{
 height: 569px;
 text-align: center;
}

@media only screen and (max-width: 600px) {
body{
    width: 100%;
}

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
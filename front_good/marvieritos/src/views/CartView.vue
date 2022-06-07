<template>
  <div class="cart">
    <div>
      <span style="color: black; background-color: grey;font-size: 30px">
        <b>Carrito</b>
      </span>
      <template>
        <div>
          <section class="wrapper">
            <ul
              style="
                display: inline-grid;
                justify-content: space-between;
                align-items: center;
                margin-top: 70px;
              "
            >
              <li
                v-for="product in products"
                :key="product.id"
                style="
                  border: black 3px solid;
                  width: 1090px;
                  display: flex;
                  justify-content: space-between;
                  align-items: center;
                  padding-top: 15px;
                  margin-bottom: 40px;
                "
              >
                <b-button
                  @click="
                    removeProduct(
                      product.id,
                      product.quantity,
                      product.productId,
                      product.productName,
                      product.productPrice
                    )
                  "
                  style="
                    width: 100px;
                    background-color: white;
                    color: black;
                    font-size: 20px;
                    margin-top: -15px;
                    margin-right: 80px;
                  "
                >
                  <b>Eliminar Producto</b>
                </b-button>
                <p>{{ product.productName }}</p>
                <p style="padding: 0px 200px">{{ product.productPrice }} €</p>
                <p style="padding-right: 100px">{{ product.quantity }}</p>
                <b-button
                  @click="
                    upgradeQuantity(
                      product.id,
                      product.quantity,
                      product.productId,
                      product.productName,
                      product.productPrice
                    )
                  "
                  style="
                    margin-right: 10px;
                    width: 40px;
                    background-color: aqua;
                    color: black;
                    margin-top: -15px;
                  "
                >
                  <b>+</b>
                </b-button>
                <b-button
                  @click="
                    degradeQuantity(
                      product.id,
                      product.quantity,
                      product.productId,
                      product.productName,
                      product.productPrice
                    )
                  "
                  style="
                    margin-right: 15px;
                    width: 40px;
                    background-color: indianred;
                    color: black;
                    margin-top: -15px;
                  "
                >
                  <b>-</b>
                </b-button>
                <div style="margin-right: 5px;">
                  <p>{{totalProduct(product.quantity, product.productPrice)}} €</p>
                </div>
              </li>
            </ul>
          </section>
        </div>
        <div
          style="border: black 3px solid; width: 100px; align-items: center; padding-top: 15px; margin-left: 1400px;"
        >
          <p>Total: {{totalCart}} €</p>
        </div>
        <router-link :to="{ name: 'Orders' }" style="text-decoration: none; width: 45%">
          <b-button
            @click="submitOrder()"
            style="
            background-color: #FFE042;
            color: black;
            margin-top: 5px;
            width: 300px;
            height: 50px;
          "
          >
            <b>Checkout</b>
          </b-button>
        </router-link>
      </template>
    </div>
  </div>
</template>

<script>
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
    upgradeQuantity(id, quantity, productId, productName, productPrice) {
      fetch('https://localhost:44330/api​/Carts/' + id), {
        method: "PUT",
        body: JSON.stringify({
          productId: productId,
          productName: productName,
          quantity: quantity + 1,
          productPrice: productPrice,
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
    degradeQuantity(id, quantity, productId, productName, productPrice) {
      if (quantity > 1) {
        fetch('https://localhost:44330/api​/Carts/' + id), {
          method: "PUT",
          body: JSON.stringify({
            productId: productId,
            productName: productName,
            quantity: quantity - 1,
            productPrice: productPrice,
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
            productId: productId,
            productName: productName,
            quantity: quantity,
            productPrice: productPrice,
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
    removeProduct(id, quantity, productId, productName, productPrice) {
      fetch('https://localhost:44330/api​/Carts/' + id), {
        method: "DELETE",
        body: JSON.stringify({
          productId: productId,
          productName: productName,
          quantity: quantity,
          productPrice: productPrice,
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
    totalProduct(productPrice, quantity) {
      return parseFloat(productPrice) * parseFloat(quantity);
    },
    submitOrder() {
      for (let i = 0; i < this.products.length; i++) {
        fetch("https://localhost:44330/api​/Carts"), {
          method: "POST",
          body: JSON.stringify({
            productId: this.products[i].id,
            productName: this.products[i].productName,
            quantity: this.products[i].quantity,
            productPrice: this.products[i].productPrice,
            totalProduct:
              this.products[i].quantity * this.products[i].productPrice,
          }),
          headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
          },
        };
      }
      fetch("https://localhost:44330/api​/Carts"), {
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
        fetch("https://localhost:44330/api​/Carts/" + i), {
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
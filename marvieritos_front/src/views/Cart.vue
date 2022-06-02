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
import cartsServices from '../services/cartsServices';


export default{
  data(){
    return{
      cart: null
    }
  },
  mounted(){
    this.getCart();
    this.addToCart();
    this.removeFromCart();
    this.updateCart();
  },
  methods:{
    getCart(){
      cartsServices.getCart().then(response => {
        this.cart = response.data;
      })
    },
    add(){
      productService.add(this.product).then(response => {
        this.cart = response.data;
      })
    },
    deleteCarts(){
      productService.deleteCarts().then(response => {
        this.cart = response.data;
      });
    },
    updateCart(){
      productService.updateCart(this.product).then(response => {
        this.cart = response.data;
        })
      }
  }
}

</script>
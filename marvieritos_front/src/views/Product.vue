<template>
    <div class="checkout">
        <div>
        <template>
            <div style="background-color:grey">
            <section class="wrapper">
                <p>Pedido completado</p>
                <router-link
                        :to="{ name: 'Home' }"
                        style="text-decoration:none; width: 5%"
                    >
                <b-button style="width: 450px; background-color: #FFE042; color: black;">
                <b>Ecommerce</b>
                </b-button>
                </router-link>
            </section>
            </div>
        </template>
        </div>
    </div>  
</template>
<script>
import productService from '../services/productsServices';

 export default{
     data(){
         return{
             products: null
         }
     },
     mounted(){
         this.getProducts();
         this.getProductById();
         this.getProductByCategories(id);
         this.addProduct(product);
         this.updateProduct(product);
         this.deleteProduct(id);

     },
     methods:{
            getProducts(){
                productService.getProducts().then(response => {
                    this.products = response.data;
                })
            },
            getProductById(){
                productService.getProductById(id).then(response => {
                    this.product = response.data;
                })
            },
            getProductByCategories(id){
                productService.getProductByCategories(id).then(response => {
                    this.products = response.data;
                })
            },
            addProduct(product){
                productService.addProduct(product).then(response => {
                    this.products = response.data;
                })
            },
            updateProduct(product){
                productService.updateProduct(product).then(response => {
                    this.products = response.data;
                })
            },
            deleteProduct(id){
                productService.deleteProduct(id).then(response => {
                    this.products = response.data;
                })
            }

     },
     components:{
         Productos
     }
 }   

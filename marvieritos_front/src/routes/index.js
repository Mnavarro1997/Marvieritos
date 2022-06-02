import  Vue from 'vue'
import  VueRouter from 'vue-router'
import  Home from '../views/Home.vue'
import  Cart from '../views/Cart.vue'
import  Product from '../views/Product.vue'
Vue.use(VueRouter);
const routes =[
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/cart',
        name: 'Cart',
        component: Cart
    },
    {
        path: '/product',
        name: 'Product',
        component: Product
    },
    {
        path: '/categories',
        name: 'Categories',
        component: Categories
    }
]
const router = new VueRouter({
    mode: 'history',
    routes
})
export default router
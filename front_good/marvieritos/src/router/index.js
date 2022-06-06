import ProductView from '../views/ProductView.vue'
import HomeView from '../views/HomeView.vue'
import CartView from '../views/CartView.vue'
import CategoryView from '../views/CategoryView.vue'
import { createRouter, createWebHashHistory } from 'vue-router'


const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeView
  },
  {
    path: '/cart',
    name: 'Cart',
    component: CartView
  },
  {
    path: '/product',
    name: 'Product',
    component: ProductView
  },
  {
    path: '/category',
    name: 'Category',
    component: CategoryView
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router

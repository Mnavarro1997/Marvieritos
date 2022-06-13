import ProductView from '../views/ProductView.vue'
import HomeView from '../views/HomeView.vue'
import CartView from '../views/CartView.vue'
import CategoryView from '../views/CategoryView.vue'
import UserView from '../views/UserView.vue'
import RegistroView from '../views/RegistroView.vue'
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
    path: '/users',
    name: 'User',
    component: UserView
  },
  {
    path: '/registro',
    name: 'Registro',
    component: RegistroView
  },
  {
    path: '/product/:id', 
    name: 'Product',
    component: ProductView,
    props: true
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

import { api } from "./base"

export default{
    async getCart(){
        return await api().get('Cart')
    },
    async addToCart(product){
        return await api().post('Cart', product)
    },
    async removeFromCart(product){
        return await api().delete('Cart/' + product.id)
    },
    async updateCart(product){  // product is an object with id and quantity
        return await api().put('Cart/' + product.id, product)
    }
}
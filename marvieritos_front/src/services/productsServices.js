import { api } from "./base"
export default{
    async getProducts(){
        return await api().get('Products')
    },
    async getProductById(id){
        return await api().get('Products/' + id)
    },
    async getProductsByCategories(id, categories){
        return await api().get('Products/' + id + '/' + categories)
    },
    async addProduct(product){
        return await api().post('Products', product)
    },
    async updateProduct(product){
        return await api().put('Products/' + product.id, product)
    },
    async deleteProduct(id){
        return await api().delete('Products/' + id)
    }




}
// Compare this snippet from Marvieritos\marvieritos_front\src\services\productsServices.js:

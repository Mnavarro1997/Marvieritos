import { api } from "./base"
export default{
    async getCategories(){
        return await api().get('Categories')
    },
    async getCategory(id){
        return await api().get('Categories/' + id)
    },
    async getProductsByCategories(id, categories){
        return await api().get('Products/' + id + '/' + categories)
    },
    async addCategorries(categories){
        return await api().post('Categories', categories)
    },
    async updateCategories(categories){
        return await api().put('Categories', categories)
    },
    async deleteCategories(id){
        return await api().delete('Categories/' + id)
    }
}
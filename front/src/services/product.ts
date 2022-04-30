import { http } from './config'

export default {
    listProducts:(page) => {
        return http.get('getProducts/'+page)
    }
}
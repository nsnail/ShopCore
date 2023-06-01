/**
 *  取号服务
 *  @module @/api/biz/used.number
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除取号
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/used.number/bulk.delete`,
        name: `批量删除取号`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建取号
 */
create :{
    url: `${config.API_URL}/api/biz/used.number/create`,
        name: `创建取号`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除取号
 */
delete :{
    url: `${config.API_URL}/api/biz/used.number/delete`,
        name: `删除取号`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询取号
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/used.number/paged.query`,
        name: `分页查询取号`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询取号
 */
query :{
    url: `${config.API_URL}/api/biz/used.number/query`,
        name: `查询取号`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新取号
 */
update :{
    url: `${config.API_URL}/api/biz/used.number/update`,
        name: `更新取号`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
/**
 *  投资服务
 *  @module @/api/biz/investment
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除投资
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/investment/bulk.delete`,
        name: `批量删除投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建投资
 */
create :{
    url: `${config.API_URL}/api/biz/investment/create`,
        name: `创建投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除投资
 */
delete :{
    url: `${config.API_URL}/api/biz/investment/delete`,
        name: `删除投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询投资
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/investment/paged.query`,
        name: `分页查询投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询投资
 */
query :{
    url: `${config.API_URL}/api/biz/investment/query`,
        name: `查询投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新投资
 */
update :{
    url: `${config.API_URL}/api/biz/investment/update`,
        name: `更新投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
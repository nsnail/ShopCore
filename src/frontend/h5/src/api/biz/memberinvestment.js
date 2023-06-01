/**
 *  会员投资服务
 *  @module @/api/biz/member.investment
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除会员投资
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/member.investment/bulk.delete`,
        name: `批量删除会员投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建会员投资
 */
create :{
    url: `${config.API_URL}/api/biz/member.investment/create`,
        name: `创建会员投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除会员投资
 */
delete :{
    url: `${config.API_URL}/api/biz/member.investment/delete`,
        name: `删除会员投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询会员投资
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/member.investment/paged.query`,
        name: `分页查询会员投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询会员投资
 */
query :{
    url: `${config.API_URL}/api/biz/member.investment/query`,
        name: `查询会员投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新会员投资
 */
update :{
    url: `${config.API_URL}/api/biz/member.investment/update`,
        name: `更新会员投资`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
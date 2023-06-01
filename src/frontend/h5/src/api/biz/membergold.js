/**
 *  会员金币服务
 *  @module @/api/biz/member.gold
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除会员金币
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/member.gold/bulk.delete`,
        name: `批量删除会员金币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建会员金币
 */
create :{
    url: `${config.API_URL}/api/biz/member.gold/create`,
        name: `创建会员金币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除会员金币
 */
delete :{
    url: `${config.API_URL}/api/biz/member.gold/delete`,
        name: `删除会员金币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询会员金币
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/member.gold/paged.query`,
        name: `分页查询会员金币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询会员金币
 */
query :{
    url: `${config.API_URL}/api/biz/member.gold/query`,
        name: `查询会员金币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新会员金币
 */
update :{
    url: `${config.API_URL}/api/biz/member.gold/update`,
        name: `更新会员金币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
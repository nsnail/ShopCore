/**
 *  会员变更服务
 *  @module @/api/biz/member.change
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除会员变更
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/member.change/bulk.delete`,
        name: `批量删除会员变更`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建会员变更
 */
create :{
    url: `${config.API_URL}/api/biz/member.change/create`,
        name: `创建会员变更`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除会员变更
 */
delete :{
    url: `${config.API_URL}/api/biz/member.change/delete`,
        name: `删除会员变更`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询会员变更
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/member.change/paged.query`,
        name: `分页查询会员变更`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询会员变更
 */
query :{
    url: `${config.API_URL}/api/biz/member.change/query`,
        name: `查询会员变更`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新会员变更
 */
update :{
    url: `${config.API_URL}/api/biz/member.change/update`,
        name: `更新会员变更`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
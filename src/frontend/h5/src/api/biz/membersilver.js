/**
 *  会员银币服务
 *  @module @/api/biz/member.silver
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除会员银币
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/member.silver/bulk.delete`,
        name: `批量删除会员银币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建会员银币
 */
create :{
    url: `${config.API_URL}/api/biz/member.silver/create`,
        name: `创建会员银币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除会员银币
 */
delete :{
    url: `${config.API_URL}/api/biz/member.silver/delete`,
        name: `删除会员银币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询会员银币
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/member.silver/paged.query`,
        name: `分页查询会员银币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询会员银币
 */
query :{
    url: `${config.API_URL}/api/biz/member.silver/query`,
        name: `查询会员银币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新会员银币
 */
update :{
    url: `${config.API_URL}/api/biz/member.silver/update`,
        name: `更新会员银币`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
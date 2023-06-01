/**
 *  会员固化信息服务
 *  @module @/api/biz/member.fixed
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除会员固化信息
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/member.fixed/bulk.delete`,
        name: `批量删除会员固化信息`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建会员固化信息
 */
create :{
    url: `${config.API_URL}/api/biz/member.fixed/create`,
        name: `创建会员固化信息`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除会员固化信息
 */
delete :{
    url: `${config.API_URL}/api/biz/member.fixed/delete`,
        name: `删除会员固化信息`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询会员固化信息
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/member.fixed/paged.query`,
        name: `分页查询会员固化信息`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询会员固化信息
 */
query :{
    url: `${config.API_URL}/api/biz/member.fixed/query`,
        name: `查询会员固化信息`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新会员固化信息
 */
update :{
    url: `${config.API_URL}/api/biz/member.fixed/update`,
        name: `更新会员固化信息`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
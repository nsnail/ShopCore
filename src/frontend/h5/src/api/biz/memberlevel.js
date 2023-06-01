/**
 *  会员等级服务
 *  @module @/api/biz/member.level
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除会员等级
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/member.level/bulk.delete`,
        name: `批量删除会员等级`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建会员等级
 */
create :{
    url: `${config.API_URL}/api/biz/member.level/create`,
        name: `创建会员等级`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除会员等级
 */
delete :{
    url: `${config.API_URL}/api/biz/member.level/delete`,
        name: `删除会员等级`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询会员等级
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/member.level/paged.query`,
        name: `分页查询会员等级`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询会员等级
 */
query :{
    url: `${config.API_URL}/api/biz/member.level/query`,
        name: `查询会员等级`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新会员等级
 */
update :{
    url: `${config.API_URL}/api/biz/member.level/update`,
        name: `更新会员等级`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
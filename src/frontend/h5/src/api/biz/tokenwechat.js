/**
 *  微信令牌服务
 *  @module @/api/biz/token.wechat
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除微信令牌
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/token.wechat/bulk.delete`,
        name: `批量删除微信令牌`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建微信令牌
 */
create :{
    url: `${config.API_URL}/api/biz/token.wechat/create`,
        name: `创建微信令牌`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除微信令牌
 */
delete :{
    url: `${config.API_URL}/api/biz/token.wechat/delete`,
        name: `删除微信令牌`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询微信令牌
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/token.wechat/paged.query`,
        name: `分页查询微信令牌`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询微信令牌
 */
query :{
    url: `${config.API_URL}/api/biz/token.wechat/query`,
        name: `查询微信令牌`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新微信令牌
 */
update :{
    url: `${config.API_URL}/api/biz/token.wechat/update`,
        name: `更新微信令牌`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
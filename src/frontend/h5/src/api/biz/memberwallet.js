/**
 *  会员钱包服务
 *  @module @/api/biz/member.wallet
 */

import config from "@/config"
import http from "@/utils/request"

export default {

    /**
 * 批量删除会员钱包
 */
bulkDelete :{
    url: `${config.API_URL}/api/biz/member.wallet/bulk.delete`,
        name: `批量删除会员钱包`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 创建会员钱包
 */
create :{
    url: `${config.API_URL}/api/biz/member.wallet/create`,
        name: `创建会员钱包`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 删除会员钱包
 */
delete :{
    url: `${config.API_URL}/api/biz/member.wallet/delete`,
        name: `删除会员钱包`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 分页查询会员钱包
 */
pagedQuery :{
    url: `${config.API_URL}/api/biz/member.wallet/paged.query`,
        name: `分页查询会员钱包`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 查询会员钱包
 */
query :{
    url: `${config.API_URL}/api/biz/member.wallet/query`,
        name: `查询会员钱包`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

/**
 * 更新会员钱包
 */
update :{
    url: `${config.API_URL}/api/biz/member.wallet/update`,
        name: `更新会员钱包`,
        post:async function(data, config={}) {
        return await http.post(this.url,data, config)
    }
},

}
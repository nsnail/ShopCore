<script setup>
import {getCurrentInstance, ref} from "vue";
import InfinityScroll from "@/components/InfinityScroll.vue";

let page = 1
const products = ref([])
const categories = ref([{id: 0, categoryName: '所有商品'}])
const loading = ref(false);
const _this = getCurrentInstance().proxy

if (_this.$route.query.cId) {
    categories.value.unshift({id: _this.$route.query.cId, categoryName: _this.$route.query.cName})
}
let categoryId = ref(categories.value[0].id)
loadProducts()
LoadCategories()

async function onRefresh() {
    await reloadProducts()
    loading.value = false;
}

async function reloadProducts() {
    products.value = []
    page = 1
    await loadProducts()
}


async function loadProducts() {
    let res = await _this.$API['biz/product'].pagedQuery.post({
        pageSize: 10,
        page: page,
        filter: {
            categoryId: categoryId.value
        }
    })
    if (res.data.rows) {
        products.value = products.value.concat(res.data.rows)
    }
}

async function LoadCategories() {
    let res = await _this.$API['biz/productcategory'].query.post()
    categories.value = categories.value.concat(res.data)
}

async function scrollBottom(callback) {
    page++
    await loadProducts()
    callback()
}

async function tabChange() {
    await reloadProducts()
}


</script>

<template>
    <div class="bg-gray-50">
        <van-search class="w-full" placeholder="请输入搜索关键词"/>
        <van-tabs v-model:active="categoryId" sticky swipeable @change="tabChange">
            <van-tab v-for="(category,i) in categories" :key="i" :name="category.id" :title="category.categoryName">
                <van-pull-refresh v-model="loading" @refresh="onRefresh">
                    <div class="grid grid-cols-2 gap-2 p-1">
                        <a v-for="(product,i) in products" :key="i" :href="`/product?id=${product.id}`"
                           class="block bg-white rounded-lg p-1"
                           target="_blank">
                            <van-image :src="product.imageUrl" class="w-full" lazy-load>
                            </van-image>
                            <p class="text-sm van-ellipsis">{{ product.name }}</p>
                            <p class="text-right text-red-600">&yen;{{ product.price / 100 }}</p>
                        </a>
                    </div>
                </van-pull-refresh>
            </van-tab>
        </van-tabs>


        <infinity-scroll @scrollBottom="scrollBottom"></infinity-scroll>
    </div>
</template>
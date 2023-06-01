<script setup>
import {RouterView} from 'vue-router'
</script>

<template>
    <header></header>
    <main>
        <RouterView/>
    </main>
    <footer>
        <van-tabbar route>
            <van-tabbar-item icon="home-o" to="/">首页</van-tabbar-item>
            <van-tabbar-item icon="apps-o" to="/category">分类</van-tabbar-item>
            <van-tabbar-item icon="user-o" to="/member">个人中心</van-tabbar-item>
        </van-tabbar>

    </footer>
</template>
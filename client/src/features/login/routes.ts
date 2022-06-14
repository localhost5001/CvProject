import {  RouteRecordRaw } from 'vue-router'

export const routes: RouteRecordRaw[] = [
    { path: '/login', component: import('./views/index.vue') },
]

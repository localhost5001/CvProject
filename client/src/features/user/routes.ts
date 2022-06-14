import {  RouteRecordRaw } from 'vue-router'

export const routes: RouteRecordRaw[] = [
    { path: '/user/:id', component: import('./views/index.vue') },
]

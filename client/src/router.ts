import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'

import { routes as loginRoutes } from '@/features/login/routes'
import { routes as userRoutes } from '@/features/user/routes'
import { routes as homeRoutes } from '@/features/home/routes'

declare module 'vue-router' {
    interface RouteMeta {
        layout?: 'EmptyLayout' | 'DefaultLayout'
    }
}

const routes: RouteRecordRaw[] = [
    ...loginRoutes,
    ...userRoutes,
    ...homeRoutes,
]

export const router = createRouter({
    history: createWebHistory(),
    routes: routes
})
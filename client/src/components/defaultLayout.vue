<script setup lang="ts">
import { useRouter } from 'vue-router';
import { authApi } from '@/common/api'

const router = useRouter()

const onLogoutClick = async () => {
    await authApi.logout()
    router.push('/login')
}

</script>

<template>
    <v-layout>
        <v-app-bar title="CV Project">
            <template v-slot:append>
                <v-btn @click="onLogoutClick" icon="logout"></v-btn>
            </template>
        </v-app-bar>
        <v-main class="grey lighten-3">
            <slot></slot>
        </v-main>
    </v-layout>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { authApi } from '@/common/api'

const router = useRouter()

const userName = ref('')
const password = ref('')

const onLoginClick = async () => {
    await authApi.login({
        userName: userName.value,
        password: password.value,
    })
    router.push('/')
}

</script>

<template>
    <v-container class="d-flex justify-center align-center" style="height: 100vh;">
         <v-card plain width="30vw">
            <v-card-text class="text-center text-h5">
                Login
            </v-card-text>
            <v-card-text>
                <v-text-field 
                    v-model="userName"
                    label="User name"
                    variant="outlined"
                />

                <v-text-field
                    v-model="password"
                    label="Password"
                    type="password"
                    variant="outlined"
                />

                <v-btn block variant="contained-flat" color="primary" @click="onLoginClick">
                    Login
                </v-btn>
                <v-btn block variant="plain">
                    Forgot your password?
                </v-btn>
            </v-card-text>
        </v-card>
    </v-container>
</template>

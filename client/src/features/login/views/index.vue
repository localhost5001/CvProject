<script setup lang="ts">

</script>

<template>
    <v-container class="d-flex justify-center align-center" style="height: 100vh;">
         <v-card plain width="30vw">
            <v-card-text class="text-center text-h5">
                Login
            </v-card-text>
            <v-card-text>
                <v-text-field 
                    hint="User Name"
                    label="User name"
                    variant="outlined"
                />

                <v-text-field 
                    hint="Password"
                    label="Password"
                    type="password"
                    variant="outlined"
                />

                <v-btn block variant="contained-flat" color="primary">
                    Login
                </v-btn>
                <v-btn block variant="plain">
                    Forgot your password?
                </v-btn>
            </v-card-text>
        </v-card>
    </v-container>
</template>

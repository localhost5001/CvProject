<template>
    <v-layout>
        <v-app-bar title="CV Project">
            <template v-slot:append>
                <v-btn icon="person"></v-btn>
            </template>
        </v-app-bar>
        <v-main class="grey lighten-3">
            <slot></slot>
        </v-main>
    </v-layout>
</template>

<template>
    <v-layout>
        <v-app-bar title="CV Project">
            <template v-slot:append>
                <v-btn icon="person"></v-btn>
            </template>
        </v-app-bar>
        <v-main>
            <slot></slot>
        </v-main>
    </v-layout>
</template>

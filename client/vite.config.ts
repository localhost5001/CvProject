import { defineConfig } from 'vite'
import {
  Vuetify3Resolver
} from 'unplugin-vue-components/resolvers'
import Components from 'unplugin-vue-components/vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    vue(), 
    Components({ resolvers: [Vuetify3Resolver()] })
  ],
  resolve: {
    alias: [
      { find: '@', replacement: '/src' }
    ]
  }
})

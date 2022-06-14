import { createApp } from 'vue'

import { vuetify } from './vuetify'
import { router } from './router'

import App from './App.vue'

const app = createApp(App)

app.use(vuetify)
app.use(router)

app.mount('#app')

import { createApp } from 'vue'

import { vuetify } from './vuetify'
import { router } from './router'
import { globalComponents } from './globalComponents'

import App from './App.vue'

const app = createApp(App)

app.use(globalComponents)
app.use(vuetify)
app.use(router)

app.mount('#app')

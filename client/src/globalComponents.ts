import { Plugin } from 'vue'

import defaultLayout from '@/components/defaultLayout.vue'
import emptyLayout from '@/components/emptyLayout.vue'

export const globalComponents: Plugin = {
    install: (app) => {
        app
            .component('DefaultLayout', defaultLayout)
            .component('EmptyLayout', emptyLayout)
    }
}

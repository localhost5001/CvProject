<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const layoutName = computed(() => {
  if (!route.meta?.layout || route.meta.layout === 'DefaultLayout') {
    return 'DefaultLayout'
  }

  return route.meta.layout
})
</script>

<template>
  <component :is="layoutName">
    <router-view></router-view>
  </component>
</template>

<script setup>
const props = defineProps(['snackBarText'])
</script>

<template>
  <v-snackbar timeout="4000" color="red-darken-4">
    <v-icon>mdi-alert-circle</v-icon> {{ props.snackBarText }}
  </v-snackbar>
</template>

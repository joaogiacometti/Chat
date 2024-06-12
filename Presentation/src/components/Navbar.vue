<script setup>
import { ref } from 'vue'

const drawer = ref(false)
</script>

<template>
  <v-app-bar>
    <template v-slot:prepend>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    </template>

    <v-app-bar-title>Chat</v-app-bar-title>
  </v-app-bar>

  <v-navigation-drawer v-model="drawer" temporary>
    <v-list>
      <v-list-item title="Chats" prepend-icon="mdi-chat" to="/chats" />

      <v-list-item title="Login" prepend-icon="mdi-login" to="/login" />

      <v-list-item title="Register" prepend-icon="mdi-account-plus" to="/register" />
    </v-list>
  </v-navigation-drawer>
</template>

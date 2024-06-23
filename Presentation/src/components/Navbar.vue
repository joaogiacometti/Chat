<script setup>
import { ref } from 'vue'
import { useUserStore } from '@/stores/user'

const userStore = useUserStore()

const drawer = ref(false)
</script>

<template>
  <v-app-bar>
    <template v-slot:prepend>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    </template>

    <v-app-bar-title>Chat</v-app-bar-title>

    <div class="mr-5">
      <p>{{ userStore.email }}</p>
    </div>
  </v-app-bar>

  <v-navigation-drawer v-model="drawer" temporary>
    <v-list>
      <v-list-item title="Chats" prepend-icon="mdi-chat" to="/chats" />

      <div v-if="userStore.auht">
        <v-list-item title="Profile" prepend-icon="mdi-account" to="/profile" />

        <v-list-item title="Sign Out" prepend-icon="mdi-logout" @click="userStore.signOut" />
      </div>
      <div v-else>
        <v-list-item title="Login" prepend-icon="mdi-login" to="/login" />

        <v-list-item title="Register" prepend-icon="mdi-account-plus" to="/register" />
      </div>
    </v-list>
  </v-navigation-drawer>
</template>

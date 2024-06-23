<script setup>
import { ref } from 'vue'
import { required } from '@/utils/validatiosRules'
import { useUserStore } from '@/stores/user'
import router from '@/router/index'
import ErrorSnackbar from '@/components/ErrorSnackbar.vue'

const email = ref('')
const password = ref('')
const formRef = ref(null)
const userStore = useUserStore()
const snackBarText = ref('')
const errorSnack = ref(false)

const login = async () => {
  const validation = await formRef.value.validate()

  if (validation.valid) {
    var result = await userStore.login(email.value, password.value)

    if (result.status === 200) {
      userStore.signIn()
      router.push({ name: 'Home' })
    } else {
      snackBarText.value = result
      errorSnack.value = true
    }
  }
}
</script>

<template>
  <div class="d-flex justify-center align-center" style="height: 100vh">
    <v-card class="mx-auto text-center" width="400">
      <template v-slot:title>
        <span class="font-weight-black">Login</span>
      </template>

      <v-card-text class="bg-surface-light pt-4">
        <v-form @submit.prevent="login" ref="formRef">
          <v-container>
            <v-row class="d-flex justify-center">
              <v-col cols="8">
                <v-text-field
                  v-model="email"
                  type="email"
                  :counter="100"
                  label="Email"
                  :rules="required"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row class="d-flex justify-center">
              <v-col cols="8">
                <v-text-field
                  v-model="password"
                  type="password"
                  :counter="100"
                  label="Password"
                  :rules="required"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row class="d-flex justify-center mt-5">
              <v-btn type="submit">Login</v-btn>
            </v-row>
          </v-container>
        </v-form>
      </v-card-text>
      <ErrorSnackbar v-model="errorSnack" :snackBarText="snackBarText"></ErrorSnackbar>
    </v-card>
  </div>
</template>

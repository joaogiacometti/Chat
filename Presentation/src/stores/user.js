import { defineStore } from 'pinia'
import instance from '@/services/api'
import { ref } from 'vue'

export const useUserStore = defineStore('user', () => {
  const email = ref(localStorage.getItem('email') || null)
  const auth = ref(!!email.value)

  async function login(email, password) {
    try {
      return await instance({
        method: 'POST',
        url: '/login?useCookies=true',
        data: {
          email: email,
          password: password
        }
      })
    } catch (error) {
      var code = error.response.status

      if (code === 401) {
        return 'Invalid login'
      }
    }
  }

  async function getInfo() {
    try {
      return await instance({
        method: 'GET',
        url: '/manage/info'
      })
    } catch (error) {
      var code = error.response.status

      if (code === 401) {
        return 'Invalid token, try to login again'
      }
    }
  }

  async function signOut() {
    try {
      await instance({
        method: 'GET',
        url: '/api/User/SignOut'
      })
      email.value = null
      auth.value = false
      localStorage.removeItem('email')
    } catch (error) {
      return error
    }
  }

  async function signIn() {
    try {
      let infoResult = await getInfo()
      if (infoResult.data && infoResult.data.email) {
        email.value = infoResult.data.email
        auth.value = !!email.value
        localStorage.setItem('email', email.value)
      }
    } catch (error) {
      console.error('Failed to sign in:', error)
    }
  }

  return { login, getInfo, signOut, signIn, email, auth }
})

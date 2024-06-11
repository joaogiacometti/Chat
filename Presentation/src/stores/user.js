import { defineStore } from 'pinia'
import instance from '@/services/api'

export const useUserStore = defineStore('user', () => {
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

  return { login }
})

import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Home',
      component: () => import('@/views/HomeView.vue')
    },
    {
      path: '/profile',
      name: 'Profile',
      component: () => import('@/views/ProfileView.vue')
    },
    {
      path: '/chats',
      name: 'Chats',
      component: () => import('@/views/ChatView.vue')
    },
    {
      path: '/register',
      name: 'Register',
      component: () => import('@/views/RegisterView.vue')
    },
    {
      path: '/login',
      name: 'Login',
      component: () => import('@/views/LoginView.vue')
    }
  ]
})

export default router

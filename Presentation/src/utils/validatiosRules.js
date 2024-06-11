export const required = [
  (v) => {
    if (v) return true

    return 'This field is required'
  }
]

export const emailRules = [
  (v) => !!v || 'Email is required',
  (v) => /.+@.+\..+/.test(v) || 'Email must be valid'
]

export const passwordRules = [
  (v) => !!v || 'Password is required',
  (v) => v.length >= 6 || 'Password must be at least 6 characters long',
  (v) => /[A-Z]/.test(v) || 'Password must contain at least one uppercase letter',
  (v) => /[a-z]/.test(v) || 'Password must contain at least one lowercase letter',
  (v) => /[0-9]/.test(v) || 'Password must contain at least one number',
  (v) => /[\W_]/.test(v) || 'Password must contain at least one special character'
]

import { mande } from 'mande'

import { LoginPayload } from '@/common/models/loginPayload'

const authApiClient = mande('https://localhost:7155/api/auth', {
    credentials: 'include'
})

export const login = (paylaod: LoginPayload) => {
    return authApiClient.post<void>('login', paylaod)
}

export const logout = () => {
    return authApiClient.post<void>('logout')
}

export const testAuth = () => {
    return authApiClient.get<void>('test')
}

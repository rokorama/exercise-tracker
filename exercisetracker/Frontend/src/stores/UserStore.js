import {defineStore} from "pinia";
import {computed, ref} from "vue";
import axios from "axios";

export const useUserStore = defineStore('userStore', () => {
    const user = async () => {
        try {
            const response = await axios.get('/api/auth/user', {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + window.$cookies.get('jwt')
                }
            });
            return response.data;
        } catch (error) {
            console.error("Error fetching userId:", error);
            return null;
        }
    };
    const username = ref(user.username);
    const userId = ref(user.id);
    const userRole = ref(user.role)
        
    
    return {username, userId, userRole }
})
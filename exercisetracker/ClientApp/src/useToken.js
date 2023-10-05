import { useState} from 'react';

export default function useToken() {
    const getToken = () => {
        return JSON.parse(localStorage.getItem('token'));
    }
    const [token, setToken] = useState(getToken());
    
    const saveToken = userToken => {
        localStorage.setItem('token', JSON.stringify(userToken.data));
        setToken(userToken.token)
    }
    
    return {
        setToken: saveToken,
        token
    }
}
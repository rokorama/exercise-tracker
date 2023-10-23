import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import mkcert from "vite-plugin-mkcert";

// https://vitejs.dev/config/
export default defineConfig({
  server: {
    https: true,
    port: 44420,
    strictPort: true,
    proxy: {
        '/api': {
          target: 'https://localhost:7007',
          changeOrigin: true,
          secure: false,
          rewrite: (path) => path.replace(/^\/api/, '/api')
        }
    }
  },
  plugins: [vue(), mkcert()],
})

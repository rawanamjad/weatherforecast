module.exports = {
  devServer: {
    proxy: {
      '/api/weather': {
        target: 'https://localhost:7001',
        changeOrigin: true
      },
      '/api/forecast': {
        target: 'https://localhost:7001',
        changeOrigin: true
      }
    }
  }
}
// module.exports = {
//   devServer: {
//     proxy: {
//       "/api/weather": {
//         target: 'https://localhost:7001',
//         pathRewrite: { '^/api/weather': '' },
//       },
//       "/api/identity": {
//         target: process.env.VUE_APP_DEVSERVER_IDENTITY_API_PROXY,
//         pathRewrite: { '^/api/identity': '' },
//       },
//     },
//   },
// };

module.exports = {
  devServer: {
    proxy: {
      '/api/weather': {
        target: 'https://localhost:7001',
        changeOrigin: true
      }
    }
  }
}
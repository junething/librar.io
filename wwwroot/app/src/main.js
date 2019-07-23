import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

Vue.config.productionTip = false

// 0. If using a module system, call Vue.use(VueRouter)

// 1. Define route components.
// These can be imported from other files
const Foo = { template: '<div>foo</div>' }
const Bar = { template: '<div>bar</div>' }
import ContentPage from './pages/ContentPage.vue'
import PublishPage from './pages/PublishPage.vue'
import HomePage from './pages/HomePage.vue'
import CreateAccount from './pages/CreateAccount.vue'
import Login from './pages/Login.vue'
// 2. Define some routes
// Each route should map to a component. The "component" can
// either be an actual component constructor created via
// Vue.extend(), or just a component options object.
// We'll talk about nested routes later.
const routes = [
  { path: '/', component: HomePage },
  { path: '/bar', component: Bar },
  { path: '/publish', component: PublishPage },
  { path: '/signup', component: CreateAccount },
  { path: '/login', component: Login },
  { path: '/i/*', component: ContentPage },
  
]

// 3. Create the router instance and pass the `routes` option
// You can pass in additional options here, but let's
// keep it simple for now.
const router = new VueRouter({
  mode: 'history',
  routes
})

// 4. Create and mount the root instance.
// Make sure to inject the router with the router option to make the
// whole app router-aware.
// Now the app has started!

window.app = new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

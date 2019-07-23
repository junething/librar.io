<template>
<div>
<!--  Displayname: <input v-model="signupForm.displayname" type="text" placeholder="John Jonhson"><br>-->
  Username: u/<input v-model="loginForm.cred" name="username" type="text"  placeholder="realJohnJohnson"><br>
  Password: <input  v-model="loginForm.password" name="password" type="password" placeholder="something secure please"><br>
  <button type="button" @click="login()">Login</button>
</div>
</template>

<script>
import cookie from '../scripts/cookies.js'
import cookies from '../scripts/cookies.js';
export default {
  name: 'Login',
  components: {
  },
  data () {
    return {
      loginForm: {
        cred: '',
        password: '',
      }
    }
  },
  methods: {
    login: function () {
      console.log(JSON.stringify(this.loginForm));
      var self = this;
        fetch('https://localhost:5001/api/u/login', {
          method: 'POST',
          body: JSON.stringify(self.loginForm),
          headers: {
            'Content-Type': 'application/json',
          },  
        }).then(function(response) {
          return response.text();
        }).then(function(json) {
          console.log(JSON.stringify(json));
          cookies.setCookie("authToken", JSON.stringify(json), 5);
        });
    }
  },
  mounted : function () {
   
  },
  computed: {
    
  },
}
</script>

<style>

</style>

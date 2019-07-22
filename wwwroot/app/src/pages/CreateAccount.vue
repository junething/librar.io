<template>
<div>
  Displayname: <input :model="displayname" type="text" placeholder="John Jonhson"><br>
  Username: u/<input name="username" type="text"  placeholder="realJohnJohnson"><br>
  Email: <input name="email" type="text"  placeholder="john@johnson.me"><br>
  Password: <input  name="password" type="password" placeholder="something secure please"><br>
</div>
</template>

<script>
export default {
  name: 'CreateAccount',
  components: {
  },
  data () {
    return {
      signupForm: {
        displayname: '',
        username: '',
        email: '',
        password: '',
      }
    }
  },
  methods: {
    
  },
  mounted : function () {
   
  },
  computed: {
    
  },
}
</script>

<style>

</style>

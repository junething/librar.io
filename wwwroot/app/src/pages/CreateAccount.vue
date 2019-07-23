<template>
<div>
<!--  Displayname: <input v-model="signupForm.displayname" type="text" placeholder="John Jonhson"><br>-->
  Username: u/<input v-model="signupForm.username" name="username" type="text"  placeholder="realJohnJohnson"><br>
  Email: <input v-model="signupForm.email" name="email" type="text"  placeholder="john@johnson.me"><br>
  Password: <input  v-model="signupForm.password" name="password" type="password" placeholder="something secure please"><br>
  <button type="button" @click="signup()">Signup</button>
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
     //   displayname: '',
        username: '',
        email: '',
        password: '',
      }
    }
  },
  methods: {
    signup: function () {
      console.log(JSON.stringify(this.signupForm));
      var self = this;
        fetch('https://localhost:5001/api/u/signup', {
          method: 'POST',
          body: JSON.stringify(self.signupForm),
//          mode: "no-cors",
          headers: {
            'Content-Type': 'application/json',
          },  
        })
	.then(function(response) {
		//console.log(response.text());
		return response.text();
	})
	.then(function(myJson) {
    console.log(myJson);
		//console.log(myJson);
		console.log(JSON.stringify(myJson));
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

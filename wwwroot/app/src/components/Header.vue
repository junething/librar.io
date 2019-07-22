<template>
<header> <div class="logo">librar.io</div> <div class="search"><div><input id="search" /><button><i class="fas fa-search"></i></button></div></div> <div class = "right">u/jarrah</div></header>
</template>

<script>
export default {
	name: 'MainHeader',
	data: function () {
		return {
			
		}
	},
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
header * {
	box-sizing: border-box;
}
header {
	box-sizing: border-box;
	background: tomato;
	text-align: left;
	height: 3em;
}
header > .right {
	float: right;
}
.logo {
	float: left;
	top: 10px;
	left: 10px;
	font-size: 2rem;
	line-height: 2.5rem;
	padding: 0.5rem;
	padding-left: 2rem;
	height: 100%;
	font-weight: 400;
}
.search {
	margin-left: 20%;
	height: 100%;
	float: left;
	width: 40%;
}
.search input {
	padding: 15px;
	border-radius: 0px 0px 0px 0px;
	border: 0;
	width: 90%;
	height: 100%;
}
.search button {
	border-radius: 0px 0px 0px 0px;
	border: 0;
	border-left: 0px;
	width: 2rem;
	height: 100%;
	background-color: white;
}
.search button:hover {
	color: white;
	background-color: #3a9b3a;
}
.search > div {
	height: 2em;
	margin-top: 0.5em;
}
</style>

<template>
	<div>
		<main-header></main-header>
		<router-view></router-view>
	</div>
</template>
<script>
import MainHeader from './components/Header.vue'
export default {
	name: 'App',
	components: {
	MainHeader,
	}
}
</script>

<style>
	html {
	font-family: Roboto, Arial, sans-serif;
	}
	html > * {
		box-sizing:  border-box;
	}
	body {
	padding: 0; 
	margin: 0;
	}
</style>

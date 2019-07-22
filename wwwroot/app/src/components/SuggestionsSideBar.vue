<template>
  <aside class="aside aside-2">
	<div v-for="(Item, index) in Items" class="Item-preview" :key="index">
	<img class="Item-thumbnail" src="aliens.jpg">
	<div class="Item-info">
		<h3> {{ Item.title }} </h3>
		<p> {{ Item.creator}} </p>
		<p> {{ Item.views }} | 2 years ago</p>
	</div></div>
	</aside>
</template>

<script>
export default {
	name: 'SuggestionsSidebar',
	props: ['source', 'id'],
	data: function () {
		return {
			Items: [
				{
					title: 'Learn JavaScript',
					creator: 'js queen',
					views: '60k'
				},
				{
					title: 'How to Dab',
					creator: 'ya boi',
					views: '300k'
				},
				{
					title: 'Learn C#',
					creator: '2sharp4u',
					views: '30k'
				},
			],
			message: ""
		}
	},
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.aside-1 {

	background: gold;
}

.aside-2 {
	margin-top: 1em;
	margin-left: 1em;
	padding: 0;
	margin-right: 2em;
}
.aside-2 > h3 {
	margin-top: 10px;
	margin-left: 10px;
	margin-bottom: 10px;
	text-align: left;
	border-bottom: 2px, solid, gray;
}
.aside-2 > h3 ::before {
	background-color: black;
	height: 2px;
	width: 100%;
}
.aside-2 > .video-preview {
	background: white;
	display: flex;
	margin-bottom: 10px;
}
.aside-2 > .video-preview > * {
	flex: 1 100%;
}
.aside-2 > .video-preview > .video-info > h3 {
	top: 0;
	padding-left: 10px;
	padding-top: 5px;
	margin: 0;
	text-align: left;
	font-family: Roboto, Arial, sans-serif;
	font-size: 1rem;
	font-weight: 1000;
	line-height: 1.5rem;
}
.aside-2 > .video-preview > .video-info > p {
	padding: 0;
	margin: 0;
	margin-left: 10px;
	text-align: left;
	align-self: left;
	font-family: Roboto, Arial, sans-serif;
	font-size: 1rem;
	font-weight: 500;
	line-height: 1rem;
	color: grey;
}
.aside-2 > .video-preview > img {
	position: relative;
}
</style>

Vue.component('content-box', {
	props: ['source', 'id'],
	template:'<div class="Item content-box-wrapper" v-html="iframe"></div>',
	computed: {
		iframe: function () {
			switch (this.source) {
				case "youtube":
					return '<iframe class="youtube" src="https://www.youtube.com/embed/'
					+ this.id
					+ '?modestbranding=1&rel=0" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen>'
					+ '</iframe>';
				case "vimeo":
					return '<iframe class="vimeo" src="https://player.vimeo.com/Item/'
					+ this.id
					+ '?title=0&byline=0&portrait=0"'
					+ 'width="640" height="360" frameborder="0" allow="autoplay; fullscreen" allowfullscreen></iframe>';
				case "spotify":
					return '<iframe class="spotify" src="https://open.spotify.com/embed/track/'
					+ this.id
					+ '"'
						+ 'width="300" height="380" frameborder="0" allowtransparency="true" allow="encrypted-media"></iframe>';
			/*	case "soundcloud":
					return '<iframe class="soundcloud" width="100%" height="166" scrolling="no" frameborder="no" allow="autoplay"'
					+ 'src="https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/650864687&color=%23ff5500'
					+ '&auto_play=false&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true"></iframe>'; */
				case "soundcloud":
					return '<iframe width="100%" height="300" scrolling="no" frameborder="no" allow="autoplay"'
					+ 'src="https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/'
					+ this.id
					+ '&color=%23ff5500&auto_play=false'
					+ '&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true&visual=true"></iframe>'
				case "peertube":
					return '<iframe width="560" height="315" sandbox="allow-same-origin allow-scripts"'
					+' src="https://open.tube/Items/embed/'
					+ this.id
					+ '" frameborder="0" allowfullscreen></iframe>'
				case 'dailymotion':
					return '<iframe frameborder="0" width="480" height="270" src="https://www.dailymotion.com/embed/Item/'
					+ this.id
					+ '" allowfullscreen allow="autoplay"></iframe>';
			}
		}
	}
  })
Vue.component('next-up', {
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
	template: `<aside class="aside aside-2">
	<div v-for="Item in Items" class="Item-preview">
	<img class="Item-thumbnail" src="aliens.jpg">
	<div class="Item-info">
		<h3> {{ Item.title }} </h3>
		<p> {{ Item.creator}} </p>
		<p> {{ Item.views }} | 2 years ago</p>
	</div></div>
	</aside>`
})
<template>
  <iframe :class="source" :src="src" frameborder="0" allowtransparency="true" allow="autoplay encrypted-media" sandbox="allow-same-origin allow-scripts" allowfullscreen></iframe>
</template>

<script>
export default {
  name: 'ItemDisplay',
  props: ['source', 'item'],
  computed: {
		src: function () {
			var self = this;
			var selected;
			console.log(this.source);
			try {
			var url = this.item.sources[this.source].url;
			} catch {
				return "";
			}
			//alert("asddas");
			switch (this.source) {
				case "YouTube":
					return 'https://www.youtube.com/embed/' + url + '?modestbranding=1&rel=0';
				case "Vimeo":
					return 'https://player.vimeo.com/Item/' + url + '?title=0&byline=0&portrait=0'
				case "Spotify":
					return 'https://open.spotify.com/embed/track/' + url;
			/*	case "soundcloud":
					return '<iframe class="soundcloud" width="100%" height="166" scrolling="no" frameborder="no" allow="autoplay"'
					+ 'src="https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/650864687&color=%23ff5500'
					+ '&auto_play=false&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true"></iframe>'; */
				case "Soundcloud":
					return 'https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/' + url + '&color=%23ff5500&auto_play=false'
					+ '&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true&visual=true'
				case "PeerTube":
					return 'https://peertube.video/videos/embed/' + url;
				case 'Dailymotion':
					return 'https://www.dailymotion.com/embed/Item/' + url;
				default:
					return url;
			}
		}
	}
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
</style>

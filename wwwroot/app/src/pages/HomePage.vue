<template>
  
</template>

<script>
import ItemDisplay from '../components/ItemDisplay.vue'
import SuggestionsSidebar from '../components/SuggestionsSidebar.vue'

export default {
  name: 'ContentPage',
  components: {
    ItemDisplay,
    SuggestionsSidebar
  },
  data () {
    return {
		tabs: ['YouTube', 'Vimeo', 'PeerTube', 'Spotify', 'SoundCloud', 'DailyMotion'],
    selected: 'youtube',
    ItemID: "f",
    sourceColors: {
      "youtube": "FF0000",
      "vimeo": "20B9EB",
      "spotify": "1AB953",
      "soundcloud": "ff5500",
      "peertube": "F1680D",
      'dailymotion': '00C7ED',
    },
    sourceIcons: {
      'youtube': '<i class="fab fa-youtube"></i>',
      'vimeo': '<i class="fab fa-vimeo-v"></i>',
      'spotify': '<i class="fab fa-spotify"></i>',
      'soundcloud': '<i class="fab fa-soundcloud"></i>',
      'peertube': '<i class="fas fa-play"></i>',
      'dailymotion': '<span style="font-size: 1.4em; font-weight: 700;">d</span>',
    
    },
    Item: {
      title: '-',
      creator: '-',
      sources: '-',
    }
    }
  },
  methods: {
    selectSource: function (source) {
      this.selected = source.toLowerCase();
      location.hash = source.toLowerCase();
    },
    styleSourceTab: function (source) {
      if(source === this.selected) {
        return "background-color: #" + this.sourceColors[source] + " !important;";
      } else {
        return "color: #" + this.sourceColors[source] + " !important;";
      }
    },
    setItem: function (data) {
      console.log(data);
      console.log(this.Item);
      this.Item = data;
      console.log(JSON.stringify (this.Item));
    }
  },
  mounted : function () {
    this.selected = location.hash.substring(1) || this.selected;
    this.ItemID = location.pathname.substring(3);
    //alert(this.ItemID);
    console.log("tes");
    var self = this;
    /*$.ajax({
      url: "/api/v/" + self.ItemID,
      crossDomain: "true",
      async: true,
      success: function(data){
        
        self.setItem(data);
      },
      
    });*/
    console.log("fasd");
  },
  computed: {
    sourceNamesReversed: function () {
      return this.tabs.reverse();
    },
    currentBackgroundSourceBrandColor: function () {
      return "background-color: #" + this.sourceColors[this.selected] + ";";
    }
  },
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
.wrapper {
display: flex;  
flex-flow: row wrap;
font-weight: bold;
text-align: center;
}
.wrapper > * {
flex: 1 100%;
}
.main {
	margin-top: 1em;
	margin-left: 2em;
	margin-right: 0;
	width: 70%;
}
.main > .wrap {
  width:100%;
  padding-top:56.25%;
  position: relative;
}
.Item > iframe{
  position:absolute;width:100%;height:100%;top:0;left:0;
}
content-source > div {
	float: right;
}
.main > .wrap {
	text-align: left;
}
.main > div > content-title {
	font-family: Roboto, Arial, sans-serif;
	font-size: 1rem;
	font-weight: 1000;
	margin: 10px;
	
}
.header {
background: tomato;

text-align: left;
}
.header > div {
	top: 10px;
	left: 10px;
	font-size: 2rem;
	line-height: 2rem;
	padding: 0.5rem;
	padding-left: 2rem;
	height: 100%;
	font-weight: 400;
}
.footer {
background: lightgreen;
}

@media all and (min-width: 600px) {
.aside { flex: 1 0 0; }
}

@media all and (min-width: 800px) {
.main    { flex: 2 0px; }
.aside-1 { order: 1; } 
.main    { order: 2; }
.aside-2 { order: 3; }
.footer  { order: 4; }
}

</style>

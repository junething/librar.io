<template>
  <div class="wrapper">
			<main-header></main-header>
			<div class="main" id="main">
					<div v-if="contentLoaded">
					<div class= "aspect-ratio">		
						<item-display :source="selected" :item="item"></item-display>
					</div>
					<div class="color-bar" :style="currentBackgroundSourceBrandColor"></div>
					<span class="tabs">
						<button v-for="source in sourceNamesReversed" :key="source" @click="selectSource(source)" :style="styleSourceTab(source)" :class="['tab-btn', { active: selected === source }, source]">
							 <span v-html=sourceInfo[source].icon></span>
							 <span v-if="showSourceNames">{{ source }}</span>
						</button>
						<button class="tab-btn" @click="showSourceNames = !showSourceNames">
							<i v-if="!showSourceNames" class="fas fa-chevron-left"></i>
							<i v-if="showSourceNames" class="fas fa-chevron-right"></i>
						</button>
					</span>
					<div class="title">{{ item.title }}</div>
					</div>
			</div>  
			<suggestions-sidebar></suggestions-sidebar>
			<footer class="footer">Footer</footer>
		</div>
</template>

<script>
import ItemDisplay from '../components/ItemDisplay.vue'
import SuggestionsSidebar from '../components/SuggestionsSidebar.vue'
import MainHeader from '../components/Header.vue'
import info from '../scripts/general_info.js'
export default {
  name: 'ContentPage',
  components: {
    ItemDisplay,
	SuggestionsSidebar,
	MainHeader
  },
  data () {
    return {
		selected: 'YouTube',
		contentLoaded: false,
		itemID: "f",
		sourceInfo: info.sourceInfo,
		showSourceNames: false,
		item: {
			"sources":
				{ "YouTube":
					{
						"whoCanAccess":["everyone"],
						"url":"afds"
					},
					"":
					{
						"whoCanAccess":["everyone"],
						"url":"afds"
					}
				},
				"id":"N0yFIwBfzGsV",
				"title":"blah",
				"creator":"Bob"
		},
    }
  },
  methods: {
    selectSource: function (source) {
      this.selected = source;
      location.hash = source;
    },
    styleSourceTab: function (source) {
		source = source;
		if(!this.sourceInfo[source])
			return 'color: grey';
      if(source === this.selected) {
        return "background-color: #" + this.sourceInfo[source].color + " !important;";
      } else {
        return "color: #" + this.sourceInfo[source].color + " !important;";
      }
    },
    setVideo: function (data) {
      var self = this;
	  this.item = data;
	  window.item = this.item;
	/*  Object.keys(this.item.sources).forEach(function(key) {
			//console.log(key);
  			self.item.sources[key] = self.item.sources[key];
		})*/
		this.contentLoaded = true;
    }
  },
  beforeMount: function () {
	  var self = this;

	  Object.keys(self.sourceInfo).forEach(function(key) {
			//console.log(key);
  			self.sourceInfo[key] = self.sourceInfo[key];
		});
		window.sourceInfo = self.sourceInfo;
  },
  mounted : function () {
	  var self = this;

	  window.i = this.item;
    this.selected = location.hash.substring(1) || this.selected;
    this.itemID = location.pathname.substring(3);
    //alert(this.itemID);
    console.log("Fetching item: " + this.itemID);
	
	fetch('https://localhost:5001/api/i/' + self.itemID)
	.then(function(response) {
		//console.log(response.text());
		return response.json();
	})
	.then(function(myJson) {
		//console.log(myJson);
		console.log(JSON.stringify(myJson));
		self.setVideo(myJson);
	});
  },
  computed: {
    sourceNamesReversed: function () {
		var sources = [];
		Object.keys(this.item.sources).forEach(function(key) {
  			sources.push(key);
		})
      return sources.reverse();
    },
    currentBackgroundSourceBrandColor: function () {
		console.log("} " + this.selected)
      return "background-color: #" + this.sourceInfo[this.selected].color + ";";
    }
  },
}
</script>

<style>
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
.aspect-ratio {
  position: relative;
  width: 100%;
  height: 0;
  padding-bottom: 51%;
}
.aspect-ratio iframe {
  position: absolute;
  width: 100%;
  height: 100%;
  left: 0; top: 0;
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
.main div.title {
	text-align: left;
	font-size: 1.4rem;
	font-weight: 400;
	line-height: 2.4rem;
	float: left;
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
.color-bar {
	width: 100%;
	height: 3px;
}
.active {
	opacity: 1 !important;
	box-shadow: none !important;
}
.tabs > .label {
	height: 30px;
	line-height: 30px;
	float: right;
	color: #111;
	font-weight: 900;
}
.tab-btn {
	line-height: 30px;
	height: 30px;
	text-align: center;
	/*box-shadow:inset 0px 0px 0px 3px white;*/
	width: auto;
	border: 0;
	opacity: 0.9;
	color: #111;
	font-size: 0.9em;
	font-weight: 700;
	float: right;
	background: #fff;
	cursor: pointer;
	margin-bottom: 1rem;
	outline: none;
  }
</style>

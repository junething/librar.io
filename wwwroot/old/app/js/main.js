window.onload = function () {
	const NotFound = { template: '<p>Page not found</p>' }
const Home = { template: '<p>home page</p>' }
const About = { template: '<p>about page</p>' }

const routes = {
  '/': Home,
  '/about': About
}
window.app = new Vue({
  el: '#app',
	data: {
		tabs: ['YouTube', 'Vimeo', 'PeerTube', 'Spotify', 'SoundCloud', 'DailyMotion'],
    selected: location.hash,
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
  beforeMount(){
    this.selected = location.hash.substring(1);
    this.ItemID = location.pathname.substring(3);
    //alert(this.ItemID);
    console.log("tes");
    var self = this;
    $.ajax({
      url: "/api/v/" + self.ItemID,
      crossDomain: "true",
      async: true,
      success: function(data){
        
        self.setItem(data);
      },
      
    });
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
  /*data: {
    currentRoute: window.location.pathname
  },
  computed: {
    ViewComponent () {
      return routes[this.currentRoute] || NotFound
    }
  },
  render (h) { return h(this.ViewComponent) }*/
})
}
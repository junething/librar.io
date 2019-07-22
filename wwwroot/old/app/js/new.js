window.onload = function () {
	window.form = new Vue({
		el: '#form',
		data: {
			form: {
				title: "",
				creator: "",
				sources: [],
			}
		},
		methods: {
			addSource: function () {
				this.form.sources.push({});
			},
		}
	});
}
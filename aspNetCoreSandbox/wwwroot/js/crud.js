function ax() {
    axios.get('/api/task/all', {})
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        })
        .finally(function () {
            console.log("Finally");
        });
}

var app = new Vue({
    data: {
        items: []
    },
    methods: {
        refresh: function() {
            var ctx = this;
            axios.get('/api/crud/all', {})
                .then(function (response) {
                    ctx.items = response.data;
                })
                .catch(function (error) {
                    ctx.items = [];
                });
        }
    }
});

app.$mount('#app');

// Test data
app.items.push({ id: 1, text: 'First placeholder'});
app.items.push({ id: 2, text: 'Second placeholder'});

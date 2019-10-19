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
        items: [],
        createForm: {
            text: null
        },
        updateForm: {
            id: null,
            text: null
        },
        deleteForm: {
            id: null,
            text: null
        },
        allowUpdate: false
    },
    watch: {
        updateForm: function (val) {
            this.fullName = val + ' ' + this.lastName
        }
    },
    methods: {
        create: function() {
            console.log('Create');
            var ctx = this;
            axios.post('/api/crud/save', ctx.createForm)
                .then(function (response) {
                    ctx.createForm.text = null;
                    ctx.refresh();
                })
                .catch(function (error) {

                });
        },
        refresh: function() {
            console.log('Refresh');
            var ctx = this;
            axios.get('/api/crud/all', {})
                .then(function (response) {
                    ctx.items = [];
                    for(var i = 0; i < response.data.length; i++) {
                        ctx.items.push(response.data[i]);   
                    }
                })
                .catch(function (error) {
                    console.error(error);
                });
        },
        update: function() {
            console.log('Update');
            var ctx = this;
            ctx.updateForm.id = Number(ctx.updateForm.id);
            axios.post('/api/crud/save', ctx.updateForm)
                .then(function (response) {
                    ctx.updateForm.id = null;
                    ctx.updateForm.text = null;
                    ctx.refresh();
                })
                .catch(function (error) {
                    console.error(error);
                });
        },
        del: function() {
            console.log('Delete');
            var ctx = this;
            ctx.deleteForm.id = Number(ctx.deleteForm.id);
            axios.post('/api/crud/delete', ctx.deleteForm)
                .then(function (response) {
                    ctx.deleteForm.id = null;
                    ctx.refresh();
                })
                .catch(function (error) {
                    console.error(error);
                });
        },
        fillUpdate: function() {
            var ctx = this;
            for(var i = 0; i < ctx.items.length; i++) {
                if (ctx.items[i].id == ctx.updateForm.id) {
                    ctx.updateForm.text = ctx.items[i].text; 
                    ctx.allowUpdate = true;
                    return;
                }
            }
            ctx.updateForm.text = null;
            ctx.allowUpdate = false;
        }
    },
    mounted: function() {
        this.refresh();
    }
});

app.$mount('#app');

// Test data
// app.items.push({ id: 1, text: 'First placeholder'});
// app.items.push({ id: 2, text: 'Second placeholder'});

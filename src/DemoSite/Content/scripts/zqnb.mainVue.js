define(['vue'], function (Vue) {

    //// 注册
    //Vue.component('nb-demo-button', {
    //    props: ['text'],
    //    template: '<div>DEMO: {{text}}</div>'
    //});

    Vue.component('nb-demo-child', {
        props: ['text'],
        template: '<div>DEMO Child: {{text}}</div>'
    });

    var vm = new Vue({
        el: '#app',
        data: {
            layout: {

            }
        }
    });

    return {
        vm: vm
    };
});
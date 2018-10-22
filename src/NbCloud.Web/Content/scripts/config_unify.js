(function () {
    "use strict";
    require(['app_const'], function (app_const) {
        
        //console.log("enter config_unify => ");
        //console.log(app_const);
        var rootPath = app_const.rootPath;
        var contentPath = app_const.contentPath;
        var basicPath = app_const.basicPath;
        var unifyPath = app_const.unifyPath;

        require.config({
            baseUrl: rootPath,
            waitSeconds: 2000,
            paths: {
                'jquery': unifyPath + '/assets/plugins/jquery/jquery.min'
                , 'jquery-migrate': unifyPath + '/assets/plugins/jquery/jquery-migrate.min'
                , 'bootstrap': unifyPath + '/assets/plugins/bootstrap/js/bootstrap.min'
                , 'backstretch': unifyPath + '/assets/plugins/backstretch/jquery.backstretch.min'
                , 'app': unifyPath + '/assets/js/app'
                , 'toastr': basicPath + '/toastr/toastr.min'
                , 'qrcode': basicPath + '/qrcode/jquery.qrcode.min'
                , 'canvasConvert': basicPath + '/qrcode/jquery.canvasConvert'
                , 'zqnb': contentPath + '/scripts/zqnb'
                , 'nbLog': contentPath + '/scripts/zqnb.log'
            },
            shim: {
                'bootstrap': {
                    deps: ['jquery']
                },
                'backstretch': {
                    deps: ['jquery']
                },
                'app': {
                    deps: ['jquery'],
                    exports: 'App'
                },
                'qrcode': {
                    deps: ['jquery']
                },
                'canvasConvert': {
                    deps: ['qrcode']
                }
            }
        });

        ////init app
        //require(['jquery', 'app'], function ($, App) {
        //    $(document).ready(function () {
        //        App.init();
        //    });
        //});

    });
    
})();
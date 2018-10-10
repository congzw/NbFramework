(function () {
    "use strict";
    require(['app_const'], function (app_const) {

        //console.log("enter basic_config => ");
        //console.log(app_const);
        var rootPath = app_const.rootPath;
        var contentPath = app_const.contentPath;
        //var acePath = app_const.acePath;
        var basicPath = app_const.basicPath;

        require.config({
            baseUrl: rootPath,
            waitSeconds: 2000,
            paths: {
                'jquery': basicPath + '/jquery/jquery-2.2.4.min'
                , 'bootstrap': basicPath + '/bootstrap/js/bootstrap.min'
                , 'backstretch': basicPath + '/jquery/jquery.backstretch.min'
                , 'toastr': basicPath + '/toastr/toastr.min'
                , 'zqnb': contentPath + '/scripts/zqnb'
                , 'nbLog': contentPath + '/scripts/zqnb.log'
            },
            shim: {
                'bootstrap': {
                    deps: ['jquery']
                }
            }
        });
    });
})();
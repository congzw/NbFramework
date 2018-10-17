(function () {
    "use strict";
    require(['app_const'], function (app_const) {

        console.log("enter ace_main => config require js");
        //console.log(app_const);
        var rootPath = app_const.rootPath;
        var contentPath = app_const.contentPath;
        var acePath = app_const.acePath;

        require.config({
            baseUrl: rootPath,
            waitSeconds: 2000,
            paths: {
                'jquery': acePath + '/components/jquery/dist/jquery.min'
                , 'bootstrap': acePath + '/components/bootstrap/dist/js/bootstrap.min'
                , 'ace': acePath + '/assets/js/ace'
                , 'ace-elements': acePath + '/assets/js/ace-elements'
                , 'ace-extra': acePath + '/assets/js/ace-extra'
                , 'ace_main': contentPath + '/scripts/ace_main'
                , 'ace_nav': contentPath + '/scripts/ace_nav'
            },
            shim: {
                'bootstrap': {
                    deps: ['jquery']
                },
                'ace': {
                    deps: ['jquery', 'bootstrap']
                },
                'ace-elements': {
                    deps: ['ace']
                }
            }
        });
    });
})();
require.config({
    paths: {
        'jquery': '/Content/libs/jquery/jquery-2.1.0',
        'toastr': '/Content/libs/toastr/toastr',
        'backstretch': '/Content/libs/jquery/jquery.backstretch.min',
        'angular': '/Content/libs/angular/angular',
        'ngRoute': '/Content/libs/angular/angular-route',
        'bootstrap': '/Content/scripts/bootstrap',
        'zqnb': '/Content/scripts/zqnb',
        'nbLog': '/Content/scripts/zqnb.log',
        'mainApp': '/Content/scripts/mainApp'
    },
    shim: {
        backstretch: {
            deps: ["jquery"]
        },
        angular: {
            exports: "angular"
            //,deps: ["jquery"]
        },
        ngRoute: {
            deps: ["angular"]
        }
    }
});
define({
    load: function (name, req, onload, config) {
        var split = name.split('/');
        var area = split[0];
        var componnetParts = split.slice(1);
        var component = componnetParts.join('/');
        //append '.js' by check necessary  => todo

        var fixName = '/areas/' + area + '/content/scripts/' + component + '.js';
        //console.log(area);
        //console.log(componnetParts);
        //console.log(component);
        //console.log(name);
        //console.log(fixName);
        req([fixName], function (value) {
            onload(value);
        });
    }
});
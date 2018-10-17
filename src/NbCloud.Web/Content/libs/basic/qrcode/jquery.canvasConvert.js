(function ($) {
    "use strict";

    //create by congzw
    ////how to use 1: 
    //jQuery("#qrcodeCanvas canvas").appendCanvasToImage("#img");

    ////how to use 2: 
    //var convert = jQuery.canvasConvert;
    //var myCanvas = $('#qrcodeCanvas canvas').get(0);
    //var img = convert.canvasToImage(myCanvas);
    //jQuery('#img').append(img);

    $.canvasConvert = function () {

        var convertImageToCanvas = function (image) {
            // 创建canvas DOM元素，并设置其宽高和图片一样   
            var canvas = document.createElement("canvas");
            canvas.width = image.width;
            canvas.height = image.height;
            // 坐标(0,0) 表示从此处开始绘制，相当于偏移。  
            canvas.getContext("2d").drawImage(image, 0, 0);
            return canvas;
        },
            convertCanvasToImage = function (canvas) {
                //新Image对象，可以理解为DOM  
                var image = new Image();
                // canvas.toDataURL 返回的是一串Base64编码的URL
                // 指定格式 PNG  
                image.src = canvas.toDataURL("image/png");
                return image;
            };

        return {
            // 把image 转换为 canvas对象  
            imageToCanvas: convertImageToCanvas,
            //从 canvas 提取图片 image
            canvasToImage: convertCanvasToImage
        };
    }();

    $.fn.appendCanvasToImage = function(imgDomId) {

        //$(selector).each(function(index,element))

        return this.each(function (index, element) {
            var image = new Image();
            image.src = element.toDataURL("image/png");
            $(image).appendTo($(imgDomId));
        });
    };
})(jQuery);

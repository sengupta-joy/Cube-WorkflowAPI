(function ($) {
    $.fn.jqGrid = function (options) {

        var settings = $.extend({
            color: "#556677",
            done:null
        }, options);




        return this.each(function () {
            $(this).text("hello world");
            alert(1);

            if ($.isFunction(settings.done)) {
                settings.done.call(this);
            }
        });
        
    }
}(jQuery));
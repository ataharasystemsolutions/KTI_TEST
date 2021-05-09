$(function () {
    $("#loaderbodyx").addClass('hide');


    $(document).bind('ajaxStart', function () {
        $("#loaderbodyx").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbodyx").addClass('hide');
    });
});

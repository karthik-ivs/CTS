$(document).ready(function () {

    console.log("jQuery Loaded Successfully");

    $("table img").dblclick(function () {

        $(this).animate(
            {
                width: "300px"
            },
            500
        );
    });

});
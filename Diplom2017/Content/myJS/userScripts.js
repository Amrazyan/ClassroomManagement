$(document).ready(function () {


    $("#sendAnswer").click(function () {

        var userId = 2; //////////////////////////////CHANGE TO REAL USER ID

        var radioButtons = $("#questions input:radio[name='radio']");

        var right = $("#questions input:radio[name='radio'][value = '1']");
        var rightIndex = radioButtons.index(right);

        var selected = $("input[type='radio'][name='radio']:checked");
        var selectedIndex = radioButtons.index(selected);


        var date = { "userAnswer": selected.val(), "userId": userId, "rightIndex": rightIndex, "selectedIndex": selectedIndex };

        $.ajax({
            url: '/UserPage/Answers',
            type: "POST",

            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(date),

            success: function (data) {
                $('#questions').html(data);
            },
            error: function () {
                alert("ERROR");
            }
        });
    });

    $("#read").click(function () {

        $.ajax({
            url: '/UserPage/ReadJson',
            type: "POST",

            contentType: "application/json",
            dataType: "html",

            success: function (data) {
                $('#questions').html(data);
            },
            error: function () {
                alert("ERROR");
            }
        });
    });
})
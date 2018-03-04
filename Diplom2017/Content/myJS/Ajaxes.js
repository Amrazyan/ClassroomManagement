
$(document).ready(function () {

    $('#lect').change(function () {
        alert(this.value);
        $.ajax({
            url: '/Admin/_updtTheme',
            type: "POST",

            data: JSON.stringify({ 'index': this.value }),

            contentType: "application/json",
            dataType: "html",

            success: function (data) {
                $('#thme').html(data);
            },
            error: function () {
                alert("ERROR");
            }
        });
    });

    $('#theme').change(function () {
        alert(this.value);
        $.ajax({
            url: '/Admin/UpdteQuestions',
            type: "POST",

            data: JSON.stringify({ 'index': this.value }),

            contentType: "application/json",
            dataType: "html",

            success: function (data) {
                $('#por').html(data);
            },
            error: function () {
                alert("ERROR");
            }
        });
    });
    
    

});

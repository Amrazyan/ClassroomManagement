
$(document).ready(function () {

    $('#lect').change(function () {
       
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

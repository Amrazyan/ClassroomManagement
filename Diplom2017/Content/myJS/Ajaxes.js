
$(document).ready(function () {

     //Updating Themes
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
    //Updating questions
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
    
   function Myfunc () {

                $.ajax({
                    url: '/Admin/OnlineUsers',
                    type: "GET",
                  // data: JSON.stringify({ 'name': 'From user2' }),
                    contentType: "application/json",
                    dataType: "html",

                    success: function (data) {
                         $('.pad').append(data);
                    },
                    error: function () {
                        alert("ERROR");
                    }
                });
    };
    setInterval( Myfunc, 3000);

});

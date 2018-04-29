
var a = document.getElementById("quest");
var b = document.getElementById("por");
a.addEventListener("click", openn);

function openn() {
    b.style.width = "400px";
    a.style.webkitTransform = 'rotate(180deg)';
    a.style.transition = '0.2s';
    a.removeEventListener("click", openn);
    a.addEventListener("click", clos)
}
function clos() {
    b.style.width = "0px";
    a.style.webkitTransform = 'rotate(0deg)';
    a.removeEventListener("click", clos);
    a.addEventListener("click", openn);
}




$(document).ready(function () {

    

    
    $("#answerHtml").click(function () {

        $.ajax({
            url: '/Admin/answerHtml',
            type: "POST",

            contentType: "application/json",
            dataType: "json",

            success: function (data) {

                $("#root").html("");

                data.forEach(function (item) {
                    $("#root").append(item);
                }) /////////////////////////////////////////////////////////////////////////////
            },
            error: function () {
                alert("ERROR");
            }
        });

    });

    $("#chartButton").click(function () {

        $.ajax({
            url: '/Admin/Chart',
            type: "POST",

            contentType: "application/json",
            dataType: "json",

            success: function (data) {
                showHigh(data);
            },
            error: function () {
                alert("ERROR");
            }
        });
    });

    count = 0;

    function showHigh(arr) {

        var divName = "charts" + count;
        count++;
        var chartId = document.getElementById(divName);

        var smartNames = JSON.parse(arr[0]);
        var badNames = JSON.parse(arr[1]);
        var alwaysSmartNames = JSON.parse(arr[2]);

        // Build the chart
        Highcharts.setOptions({
            colors: ['green', 'red', 'orange']
        });

        Highcharts.chart(chartId, {
            chart: {
                plotShadow: false,
                type: 'pie'
            },
            title: {
                text: ''
            },
            tooltip: {
                pointFormat: '{data.name}'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: false
                    },

                }
            },
            series: [{
                data: [{
                    name: smartNames,
                    y: smartNames.length

                },
                {
                    name: badNames,
                    y: badNames.length
                },
                {
                    name: alwaysSmartNames,
                    y: alwaysSmartNames.length,
                    sliced: true,
                    selected: true
                }]

            }]
        })
    };

});






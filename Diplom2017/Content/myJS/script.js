



var a = document.getElementById("quest");
var b = document.getElementById("por");
a.addEventListener("click", openn);

function openn() {
    b.style.width = "400px";
    a.style.webkitTransform = 'rotate(180deg)';
    a.style.transition = '0.2s';
    a.removeEventListener("click", openn);
    a.addEventListener("click",clos)
}
function clos() {
    b.style.width = "0px";
    a.style.webkitTransform = 'rotate(0deg)';
    a.removeEventListener("click", clos);
    a.addEventListener("click", openn);
}


Highcharts.chart('container', {
    chart: {
        type: 'areaspline'
    },
    title: {
        text: 'Ուսանողի առաջընթաց'
    },
    legend: {

    },
    xAxis: {
        categories: [
            'Երկուշաբթի',
            'Երեքշաբթի',
            'Չորեքշաբթի',
            'Հինգշաբթի',
            'Ուրբաթ',
            'Շաբաթ',
            'Կիրակի'
        ],

    },
    yAxis: {
        title: {
            text: 'Տոկոս'
        }
    },
    tooltip: {
        shared: true,
        valueSuffix: ' Percent'
    },
    credits: {
        enabled: false
    },
    plotOptions: {
        areaspline: {
            fillOpacity: 0.2
        }
    },
    colors: ["#88c1f0"],
    series: [{
        name: 'Տիգրան Կոշեցյան',
        data: [40, 35, 75, 100, 35]
    }]
});
Highcharts.chart('container1', {
    chart: {
        type: 'areaspline'
    },
    title: {
        text: 'Ուսանողի առաջընթաց'
    },
    legend: {

    },
    xAxis: {
        categories: [
            'Երկուշաբթի',
            'Երեքշաբթի',
            'Չորեքշաբթի',
            'Հինգշաբթի',
            'Ուրբաթ',
            'Շաբաթ',
            'Կիրակի'
        ],

    },
    yAxis: {
        title: {
            text: 'Տոկոս'
        }
    },
    tooltip: {
        shared: true,
        valueSuffix: ' Percent'
    },
    credits: {
        enabled: false
    },
    plotOptions: {
        areaspline: {
            fillOpacity: 0.2
        }
    },
    colors: ["#88c1f0"],
    series: [{
        name: 'Հայկ Ալթունյան',
        data: [40, 60, 80, 85, 75]
    }]
});
Highcharts.chart('container2', {
    chart: {
        type: 'areaspline'
    },
    title: {
        text: 'Ուսանողի առաջընթաց'
    },
    legend: {

    },
    xAxis: {
        categories: [
            'Երկուշաբթի',
            'Երեքշաբթի',
            'Չորեքշաբթի',
            'Հինգշաբթի',
            'Ուրբաթ',
            'Շաբաթ',
            'Կիրակի'
        ],

    },
    yAxis: {
        title: {
            text: 'Տոկոս'
        }
    },
    tooltip: {
        shared: true,
        valueSuffix: ' Percent'
    },
    credits: {
        enabled: false
    },
    plotOptions: {
        areaspline: {
            fillOpacity: 0.2
        }
    },
    colors: ["#88c1f0"],
    series: [{
        name: 'Արման Հովհաննիսյան',
        data: [40, 100, 62, 85, 75]
    }]
});



// Load google charts
window.onload = function () {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);
    drawChart();
}
// Draw the chart and set the chart values
function drawChart() {
    var data = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
        ['', 0],
        ['Բացակա', 2],
        ['', 0],
        ['Ներկա', 8],

    ]);

    var options = { 'title': '', 'width': 575, 'height': 270 };
    var a = new google.visualization.PieChart(document.getElementById('piechart'));
    a.draw(data, options);
    var b = new google.visualization.PieChart(document.getElementById('piechart1'));
    b.draw(data, options);

}
/////

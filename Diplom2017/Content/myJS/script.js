function openLNav() {
    document.getElementById("leftNav").style.width = "500px";
    //closeNav();
}
function closeLNav() {
    document.getElementById("leftNav").style.width = "0px";
}
function openNav() {
    document.getElementById("rightNav").style.width = "200px";
    // closeLNav();
}
function closeNav() {
    document.getElementById("rightNav").style.width = "0px";
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

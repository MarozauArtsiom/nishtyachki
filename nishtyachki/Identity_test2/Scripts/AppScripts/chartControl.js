﻿myApp.controller("chartControl", function ($scope, chartData) {

    var randomScalingFactor = function () { return Math.round(Math.random() * 100) };
    
    $scope.drawtop = function (id) {
        window.onload = function () {
            var ctx = document.getElementById(id).getContext("2d");
            chartData.topusers(10).success(function (data) {

                var topData = {
                    labels: data.labels,
                    datasets: [
                        {
                            fillColor: "rgba(151,187,205,0.5)",
                            strokeColor: "rgba(151,187,205,0.8)",
                            highlightFill: "rgba(151,187,205,0.75)",
                            highlightStroke: "rgba(151,187,205,1)",
                            data: data.numbers
                        }]
                };

                window.myBar = new Chart(ctx).Bar(topData, {
                    responsive: true
                });
            })
            
        }
    }

});
$(function() {

	/*apex-chart*/
    var dates = [15, 49, 35, 78, 29, 36,78, 90, 45, 83, 67, 29, 36,78, 90, 45, 83, 67, 29, 36,78, 90, 45, 83, 67, 29, 36,78, 90, 45, 83, 67];
	var options = {
		chart: {
			height: 230,
			stacked: false,
			type: 'area',
			zoom: {
				enabled: true
			}
		},
		plotOptions: {
			line: {
			  curve: 'smooth',

			}
		},
		dataLabels: {
			enabled: false
		},
		series: [{
			name: 'Main Project',
			data: dates
		}],
		colors: ['#cd1313'],
		markers: {
			size: 0,
			style: 'full',
		},

    }
	var chart = new ApexCharts(
		document.querySelector("#chart"),
		options
	);
	chart.render();
	/*apex-chart*/

	/*apex-chart*/
	var options = {
		chart: {
			height: 300,
			type: 'bar',
			stacked: true,
		},
		plotOptions: {
			bar: {
				horizontal: true,
			},

		},
		stroke: {
			width: 1,
			colors: ['#fff']
		},
		series: [{
			name: 'Users',
			data: [35, 45, 32, 45, 30, 53, 36]
		},{
			name: 'Page Views',
			data: [45, 56, 22, 38, 60, 59, 44]
		},{
			name: 'New Users',
			data: [36, 21, 15, 12, 15, 20, 30]
		}],
		xaxis: {
			categories: [2013, 2014, 2015, 2016, 2017, 2018, 2019],
			labels: {
				formatter: function(val) {
					return val + ""
				}
			}
		},
		yaxis: {
			title: {
				text: undefined
			},

		},
		tooltip: {
			y: {
				formatter: function(val) {
				return val + ""
			}
			}
		},
		fill: {
			opacity: 1

		},
		colors: ['#cd1313' ,'#8c8eef' ,'#b7b9ec'],
		legend: {
			position: 'top',
			horizontalAlign: 'center',
			offsetX: 10
		}
	}
	var chart = new ApexCharts(
		document.querySelector("#stacked-bar"),
		options
	);
    chart.render();
	/*apex-chart*/
	
	var myCanvas = document.getElementById("chartjs12");
	myCanvas.height="233";

	var myCanvasContext = myCanvas.getContext("2d");
	var gradientStroke1 = myCanvasContext.createLinearGradient(0, 0, 0, 380);
	gradientStroke1.addColorStop(0, '#0099ff');
	gradientStroke1.addColorStop(1, '#0099ff');

	var myChart = new Chart(myCanvas, {
		type: 'bar',
		data: {
			labels: ["Dominica", "Singapore", "Maldives", "Bahrain", "Monaco"],
			datasets: [{
				label: 'Name',
				data: [16, 14, 12, 14, 16, 15, 12, 14,18,10],
				backgroundColor: gradientStroke1,
				hoverBackgroundColor: gradientStroke1,
				hoverBorderWidth: 2,
				hoverBorderColor: 'gradientStroke1'
			}
		  ]
		},
		options: {
			responsive: true,
			maintainAspectRatio: false,
			tooltips: {
				mode: 'index',
				titleFontSize: 12,
				titleFontColor: '#8e9cad',
				bodyFontColor: '#8e9cad',
				backgroundColor: '#fff',
				cornerRadius: 3,
				intersect: false,
			},
			legend: {
				display: false,
				labels: {
					usePointStyle: true,
				},
			},
			scales: {
				xAxes: [{
					 barPercentage: 0.2,
					ticks: {
						fontColor: "#8e9cad",

					 },
					display: true,
					gridLines: {
						display: false,
						drawBorder: false
					},
					scaleLabel: {
						display: false,
						labelString: 'Month',
						fontColor: '#8e9cad'
					}
				}],
				yAxes: [{
					ticks: {
						fontColor: "transparent",
					 },
					display: true,
					gridLines: {
						display: false,
						drawBorder: false
					},
					scaleLabel: {
						display: false,
						labelString: 'sales',
						fontColor: 'transparent'
					}
				}]
			},
			title: {
				display: false,
				text: 'Normal Legend'
			}
		}
	});
	/* Chartjs (#total-customers) closed */
	
});

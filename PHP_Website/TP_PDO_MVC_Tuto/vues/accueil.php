<script>
window.onload = function() {

var chart = new CanvasJS.Chart("chartContainer", {
	theme: "light2", // "light1", "light2", "dark1", "dark2"
	exportEnabled: true,
	animationEnabled: true,
	title: {
		text: "Desktop Browser Market Share in 2016"
	},
	data: [{
		type: "pie",
		startAngle: 25,
		toolTipContent: "<b>{label}</b>: {y}%",
		showInLegend: "true",
		legendText: "{label}",
		indexLabelFontSize: 16,
		indexLabel: "{label} - {y}%",
		dataPoints: [
			{ y: 51.08, label: "Chrome" },
			{ y: 27.34, label: "Internet Explorer" },
			{ y: 10.62, label: "Firefox" },
			{ y: 5.02, label: "Microsoft Edge" },
			{ y: 4.07, label: "Safari" },
			{ y: 1.22, label: "Opera" },
			{ y: 0.44, label: "Others" }
		]
	}]
});
chart.render();

}
</script>

<main role="main">
  <!-- Main jumbotron for a primary marketing message or call to action -->
  <div class="jumbotron container">
    <div class="container">
      <h1 class="display-3">Bienvenue !</h1>
      <p>Bienvenue sur le site de BiblioWeb.</p>
      <p><a class="btn btn-primary btn-lg" href="#" role="button">Learn more &raquo;</a></p>
    </div>
  </div>

  <div class="container">
    <!-- Example row of columns -->

  </div> <!-- /container -->
  <div class="container">
    <div class="row">
      <div class="col-md-8" style="height: 600px">
        <div class="card border-primary mb-3" style="height: 600px">
          <div class="card-header">Statistiques des livres</div>
          <div class="card-body">
            <h4 class="card-title"></h4>
            <div class="card-text" id="chartContainer"></div>
          </div>
        </div>
      </div>
      <div class="col-md-4" style="height: 600px">
        <div class="card border-primary mb-3" style="height: 600px">
          <div class="card-header">Statistiques générales</div>
          <div class="card-body">
            <h4 class="card-title"></h4>
            <p class="card-text"></p>
          </div>
        </div>
      </div>
    </div>
  </div>

</main>
<script src="https://cdn.canvasjs.com/canvasjs.min.js"></script>
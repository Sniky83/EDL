<link href="//netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<link href="style.css" rel="stylesheet" id="bootstrap-css">
<!doctype html>
<html lang="fr">
	<div class="container">
		<div class="row">
			<div class="col-sm-3 col-md-3">
				<div class="panel-group" id="accordion">
					<div class="panel panel-default">
						<div class="panel-heading">
							<h4 class="panel-title">
								<a data-toggle="collapse" data-parent="#accordion" href="#collapseOne"><span class="glyphicon glyphicon-folder-close">
								</span>Rubrique d'aide</a>
							</h4>
						</div>
						<div id="collapseOne" class="panel-collapse collapse in">
							<div class="panel-body">
								<table class="table">
									<tr>
										<td>
											<span class="glyphicon glyphicon-home"></span><a href="./index.php">Page de Présentation</a>
										</td>
									</tr>
									<tr>
										<td>
											<a href="./index.php?rubrique=1">Ecran d'Accueil</a>
										</td>
									</tr>
									<tr>
										<td>
											<a href="./index.php?rubrique=2">Configuration Réseau</a>
										</td>
									</tr>
									<tr>
										<td>
											<a href="./index.php?rubrique=3">Gestion des Capteurs</a>
										</td>
									</tr>
									<tr>
										<td>
											<a href="./index.php?rubrique=4">Configuration de l'Enregistreur</a>
										</td>
									</tr>
									<tr>
										<td>
											<a href="./index.php?rubrique=5">Mesurer</a>
										</td>
									</tr>
								</table>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-sm-9 col-md-9">
				<?php
					if(isset($_GET["rubrique"]) && !empty($_GET["rubrique"]))
					{
						switch ($_GET["rubrique"])
						{
							case 1:
								include("inc/aideEcrAccueil.php");
							break;
							case 2:
								include("inc/aideConfRes.php");
							break;
							case 3:
								include("inc/aideGestCapt.php");
							break;
							case 4:
								include("inc/aideConfEnr.php");
							break;
							case 5:
								include("inc/aideMesurer.php");
							break;
						}
					}
					else
					{
						include("inc/presentation.php");
					}
				?>
			</div>
		</div>
	</div>
</html>
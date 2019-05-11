<link href="//netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<link href="style.css" rel="stylesheet" id="bootstrap-css">
<!------ Include the above in your HEAD tag ---------->
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
											<span class="glyphicon glyphicon-home"></span><a href="./index.php">Page de présentation</a>
										</td>
									</tr>
									<tr>
										<td>
											<a href="./index.php?rubrique=1">Ecran d'accueil</a>
										</td>
									</tr>
									<tr>
										<td>
											<a href="./index.php?rubrique=2">Gestion des capteurs</a>
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
								include("inc/aideGestCapt.php");
							break;
						}
					}
					else
					{
						include("inc/acceuil.php");
					}
				?>
			</div>
		</div>
	</div>
</html>
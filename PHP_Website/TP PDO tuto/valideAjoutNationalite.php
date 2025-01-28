<?php
include "header.php";
include "connexionPdo.php";
$libelle = $_POST['libelle']; // Récupère le libellé du formulaire - $_POST récupère les infos saisies dans le formulaire

//Requête de l'instance PDO - le paramètre :libelle sera remplacé à l'exécution par sa valeur 
$req = $monPdo->prepare("insert into nationalite(libelle) values(:libelle)"); // Préparation/analyse

$req->bindParam(':libelle', $libelle); // On donne au paramètre :libelle la valeur $libelle
$nb = $req->execute(); // Récupère le nombre de lignes affectées par la requête içi 1 insert donc si 0 = erreur


echo '<div class="container mt-5">';
// Créer rapidement la div ci-dessous div.row>div.col + enter
echo '<div class="row">
    <div class="col mt-5">';
if ($nb == 1) {
    echo '<div class="alert alert-success" role="alert">
        La nationalité a bien été ajouté
        </div> ';
} else {
    echo '<div class="alert alert-danger" role="alert">
        La nationalité n\'a pas été ajouté !
        </div> ';
}
?>
    </div>
</div>
<a href="listeNationalites.php" class="btn btn-primary">Revenir à la liste des nationalités</a>
</div>


<?php include "footer.php";
?>
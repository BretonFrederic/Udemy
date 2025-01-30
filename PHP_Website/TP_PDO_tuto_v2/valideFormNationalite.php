<?php
include "header.php";
include "connexionPdo.php";
$action = $_GET['action'];
$num = $_POST['num'];
$libelle = $_POST['libelle'];

if ($action == "Modifier") {
    $req = $monPdo->prepare("update nationalite set libelle = :libelle where num = :num");
    $req->bindParam(':num', $num);
    $req->bindParam(':libelle', $libelle);
} else {
    $req = $monPdo->prepare("insert into nationalite(libelle) values(:libelle)");
    $req->bindParam(':libelle', $libelle);
}
$nb = $req->execute();

$message = $action == "Modifier" ? "modifiée" : "ajoutée";

echo '<div class="container mt-5">';
// Créer rapidement la div ci-dessous div.row>div.col + enter
echo '<div class="row">
    <div class="col mt-5">';
if ($nb == 1) {
    echo '<div class="alert alert-success" role="alert">
        La nationalité a bien été '. $message . '</div> ';
} else {
    echo '<div class="alert alert-danger" role="alert">
        La nationalité n\'a pas été '. $message.' </div> ';
}
?>
</div>
</div>
<a href="listeNationalites.php" class="btn btn-primary">Revenir à la liste des nationalités</a>
</div>


<?php include "footer.php";
?>
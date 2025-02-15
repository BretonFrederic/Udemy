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
    $_SESSION['message']=["success"=>"La nationalité a bien été ".$message];
} else {
    $_SESSION['message']=["success"=>"La nationalité a bien été ".$message];
}

header('location: listeNationalites.php');
exit();

?>
</div>
</div>
<a href="listeNationalites.php" class="btn btn-primary">Revenir à la liste des nationalités</a>
</div>


<?php include "footer.php";
?>
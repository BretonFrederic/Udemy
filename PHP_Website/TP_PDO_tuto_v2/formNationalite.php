<?php
include "header.php";
include "connexionPdo.php";
$action = $_GET['action']; // Soit Ajouter soit Modifier
if ($action == "Modifier") {
    $num = $_GET['num'];
    $req = $monPdo->prepare("select * from nationalite where num= :num");
    $req->setFetchMode(PDO::FETCH_OBJ);
    $req->bindParam(':num', $num);
    $req->execute();
    $laNationalite = $req->fetch();
}

// Controler et afficher avec l'outil inspecter le contenu d'un valeur php dans le <body>
// var_dump($laNationalite);

?>
<div class="container mt-5">
    <h2 class="pt-3 text-center"><?php echo $action ?> une nationalité</h2>
    <!--class="col-md-6 offset-md-3" colonne de 6/12 quand screen >= md à partir de la 3ème colonne de droite -->
    <form action="valideFormNationalite.php?action=<?php echo $action ?>" method="post" class="col-md-6 offset-md-3 border border-primary p-3 rounded">
        <div class="form-group">
            <label for="libelle">Libellé</label>
            <input type="text" class="form-control" id='libelle' placeholder="Saisir le libellé" name="libelle" value="<?php if ($action == "Modifier"){echo $laNationalite->libelle;} ?>">
        </div>
        <input type="hidden" id="num" name="num" value="<?php if ($action == "Modifier"){echo $laNationalite->num;} ?>">
        <div class="row">
            <!-- btn-block pour prendre toute la largeur de la div parent -->
            <div class="col"><a href="listeNationalites.php" class="btn btn-warning btn-block">Revenir à la liste</a></div>
            <div class="col"><button type="submit" class="btn btn-success btn-block"><?php echo $action ?></button></div>
        </div>
    </form>
</div>

<?php include "footer.php";
?>
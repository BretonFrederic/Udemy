<?php
include "header.php";
include "connexionPdo.php"; // Connexion à la base de donnée
$num=$_GET['num']; // Récupère num
$req = $monPdo->prepare("select * from nationalite where num= :num"); // requête sur un paramètre :num
$req->setFetchMode(PDO::FETCH_OBJ);
$req->bindParam(':num', $num); // Attribut au paramètre :num la variable du get num
$req->execute(); // on execute
$laNationalite = $req->fetch(); // pas de fetchAll mais un simple fetch on récupère une seule nationalité

// Controler et afficher avec l'outil inspecter le contenu d'un valeur php dans le <body>
// var_dump($laNationalite);

?>
<div class="container mt-5">
    <h2 class="pt-3 text-center">Modifier une nationalité</h2>
<!--class="col-md-6 offset-md-3" colonne de 6/12 quand screen >= md à partir de la 3ème colonne de droite -->
    <form action="valideModifNationalite.php" method="post" class="col-md-6 offset-md-3 border border-primary p-3 rounded">
        <div class="form-group">
            <label for="libelle">Libellé</label>
            <input type="text" class="form-control" id='libelle' placeholder="Saisir le libellé" name="libelle" value="<?php echo $laNationalite->libelle; ?>">
        </div>
        <input type = "hidden" id="num" name="num" value="<?php echo $laNationalite->num; ?>">
        <div class="row">
<!-- btn-block pour prendre toute la largeur de la div parent -->
            <div class="col"><a href="listeNationalites.php" class="btn btn-warning btn-block">Revenir à la liste</a></div>
            <div class="col"><button type="submit" class="btn btn-success btn-block">Modifier</button></div>
        </div>
    </form>
</div>

<?php include "footer.php";
?>
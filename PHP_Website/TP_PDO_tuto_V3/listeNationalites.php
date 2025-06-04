<?php
include "header.php";
include "connexionPdo.php";

// Requête de l'instance PDO
// Liste des nationalités
//Construction de la requête
$texteReq = "select n.num, n.libelle as 'libNation', c.libelle as 'libContinent' from nationalite n, continent c where n.numContinent=c.num";
if(!empty($_GET)){
    if($_GET['libelle'] != ""){ $texteReq.= " and n.libelle like '%" .$_GET['libelle']."%'";}
    if($_GET['continent'] != "") { $texteReq.= " and c.num =" .$_GET['continent'];}
}
$texteReq.= " order by n.libelle";
$req = $monPdo->prepare($texteReq); // Préparation/analyse
$req->setFetchMode(PDO::FETCH_OBJ); // Récupère un type FETCH_OBJ liste d'objets
$req->execute(); // Appel à la méthode execute()
$lesNationalites = $req->fetchAll(); // Stocke tous ce qui a été récupérer dans $lesNationalites

// Liste des continents
$reqContinent = $monPdo->prepare("select * from continent");
$reqContinent->setFetchMode(PDO::FETCH_OBJ);
$reqContinent->execute();
$lesContinents=$reqContinent->fetchAll();

if(!empty($_SESSION['message'])){
    $mesMessages = $_SESSION['message'];
    foreach($mesMessages as $key=>$message){
        echo'<div class="container pt-5">
                <div class="alert alert-'.$key.' alert-dismissible fade show" role="alert">'.$message.'
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            </div>';
    }
    $_SESSION['message']=[];
}

?>

<div class="container mt-5">
    <div class="row pt-3">

        <div class="col-9">
            <h2>Liste des nationalités</h2>
        </div>
        <div class="col-3">
            <a href="formNationalite.php?action=Ajouter" class='btn btn-success'><i class="fas fa-plus-circle"></i> Créer une nationalité</a>
        </div>
    </div>


    <form action="" method="get" class="border border-primary rounded p-3 mt-3 mb-3">
        <div class="row">
            <div class="col">
                <input type="text" class="form-control" id='libelle' placeholder="Saisir le libellé" name="libelle" value="">
            </div>
            <div class="col">
                <select name="continent" class="form-control">
                    <?php
                    foreach($lesContinents as $continent){
                        $selection=$continent->num == $laNationalite->numContinent ? 'selected' : '';
                        echo "<option value='$continent->num' $selection>$continent->libelle</option>";
                    }
                    ?>
                </select>
            </div>
            <div class="col">
                <button type="submit" class="btn btn-success btn-block">Rechercher</button>
            </div>
        </div>
    </form>

    <table class="table table-hover table-striped">
        <thead>
            <tr class="d-flex">
                <th scope="col" class="col-md-2">Numéro</th>
                <th scope="col" class="col-md-5">Libellé</th>
                <th scope="col" class="col-md-3">Continent</th>
                <th scope="col" class="col-md-2">Actions</th>
            </tr>
        </thead>
        <tbody>
            <?php
            foreach ($lesNationalites as $nationalite) {
                echo "<tr class='d-flex'>";
                echo "<td class='col-md-2'>$nationalite->num</td>";
                echo "<td class='col-md-5'>$nationalite->libNation</td>";
                echo "<td class='col-md-3'>$nationalite->libContinent</td>";

                // Avec ? on passe en paramètre num=$nationalite->num qui compose l'url
                echo "<td class='col-md-2'>
                    <a href='formNationalite.php?action=Modifier&num=$nationalite->num' class='btn btn-primary'><i class='fas fa-pen'></i></a>
                    <a href='#modalSuppression' data-toggle='modal' data-message='Voulez-vous supprimer cette nationalité ?' data-suppression='supprimerNationalite.php?num=$nationalite->num' class='btn btn-danger'><i class='fas fa-trash-alt'></i></a>
                </td>";
                echo "</tr>";
            }

// supprimerNationalite.php?num=$nationalite->num

            ?>
        </tbody>
    </table>
</div>

<?php include "footer.php";
?>
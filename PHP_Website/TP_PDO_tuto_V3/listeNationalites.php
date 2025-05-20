<?php
include "header.php";
include "connexionPdo.php";

//Requête de l'instance PDO
$req = $monPdo->prepare("select n.num, n.libelle as 'libNation', c.libelle as 'libContinent' from nationalite n, continent c where n.numContinent=c.num order by n.libelle"); // Préparation/analyse
$req->setFetchMode(PDO::FETCH_OBJ); // Récupère un type FETCH_OBJ liste d'objets
$req->execute(); // Appel à la méthode execute()
$lesNationalites = $req->fetchAll(); // Stocke tous ce qui a été récupérer dans $lesNationalites

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
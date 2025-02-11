<?php
include "header.php";
include "connexionPdo.php";

//Requête de l'instance PDO
$req = $monPdo->prepare("select * from nationalite"); // Préparation/analyse
$req->setFetchMode(PDO::FETCH_OBJ); // Récupère un type FETCH_OBJ liste d'objets
$req->execute(); // Appel à la méthode execute()
$lesNationalites = $req->fetchAll(); // Stocke tous ce qui a été récupérer dans $lesNationalites
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
                <th scope="col" class="col-md-8">Libellé</th>
                <th scope="col" class="col-md-2">Action</th>
            </tr>
        </thead>
        <tbody>
            <?php
            foreach ($lesNationalites as $nationalite) {
                echo "<tr class='d-flex'>";
                echo "<td class='col-md-2'>$nationalite->num</td>";
                echo "<td class='col-md-8'>$nationalite->libelle</td>";

                // Avec ? on passe en paramètre num=$nationalite->num qui compose l'url
                echo "<td class='col-md-2'>
                    <a href='formNationalite.php?action=Modifier&num=$nationalite->num' class='btn btn-primary'><i class='fas fa-pen'></i></a>
                    <a href='supprimerNationalite.php?num=$nationalite->num' class='btn btn-danger'><i class='fas fa-trash-alt'></i></a>
                </td>";
                echo "</tr>";
            }
            ?>
        </tbody>
    </table>
</div>
<div class="modal">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">confirmation de suppression</h5>
      </div>
      <div class="modal-body">
        <p>Voulez-vous supprimer cette nationalité ?</p>
      </div>
      <div class="modal-footer">
        <!-- Spécifier quel num avec JS -->
        <a href="supprimerNationalite.php?num=" class="btn btn-primary">Supprimer</a>
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Ne pas supprimer</button>
      </div>
    </div>
  </div>
</div>
<?php include "footer.php";
?>
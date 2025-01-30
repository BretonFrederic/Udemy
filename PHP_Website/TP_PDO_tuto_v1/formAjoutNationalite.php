<?php
include "header.php";
?>
<div class="container mt-5">
    <h2 class="pt-3 text-center">Ajouter une nationalité</h2>
<!--class="col-md-6 offset-md-3" colonne de 6/12 quand screen >= md à partir de la 3ème colonne de droite -->
    <form action="valideAjoutNationalite.php" method="post" class="col-md-6 offset-md-3 border border-primary p-3 rounded">
        <div class="form-group">
            <label for="libelle">Libellé</label>
            <input type="text" class="form-control" id='libelle' placeholder="Saisir le libellé" name="libelle">
        </div>
        <div class="row">
<!-- btn-block pour prendre toute la largeur de la div parent -->
            <div class="col"><a href="listeNationalites.php" class="btn btn-warning btn-block">Revenir à la liste</a></div>
            <div class="col"><button type="submit" class="btn btn-success btn-block">Ajouter</button></div>
        </div>
    </form>
</div>

<?php include "footer.php";
?>
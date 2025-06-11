<div class="container mt-5">
    <h2 class="pt-3 text-center"><?php echo $mode ?> un continent</h2>
    <!--class="col-md-6 offset-md-3" colonne de 6/12 quand screen >= md à partir de la 3ème colonne de droite -->
    <form action="index.php?uc=continents&action=valideForm method="post" class="col-md-6 offset-md-3 border border-primary p-3 rounded">
        <div class="form-group">
            <label for="libelle">Libellé</label>
            <input type="text" class="form-control" id='libelle' placeholder="Saisir le libellé" name="libelle" value="<?php if ($mode == "Modifier"){echo $continent->getLibelle();} ?>">
        </div>
        <input type="hidden" id="num" name="num" value="<?php if ($mode == "Modifier"){echo $continent->getNum();} ?>">
        <div class="row">
            <!-- btn-block pour prendre toute la largeur de la div parent -->
            <div class="col"><a href="index.php?uc=continents&action=list" class="btn btn-warning btn-block">Revenir à la liste</a></div>
            <div class="col"><button type="submit" class="btn btn-success btn-block"><?php echo $mode ?></button></div>
        </div>
    </form>
</div>
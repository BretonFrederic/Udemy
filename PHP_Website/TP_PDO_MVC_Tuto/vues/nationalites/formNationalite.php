<div class="container mt-5">
    <h2 class="pt-3 text-center"><?php echo $action ?> une nationalité</h2>
    <!--class="col-md-6 offset-md-3" colonne de 6/12 quand screen >= md à partir de la 3ème colonne de droite -->
    <form action="valideFormNationalite.php?action=<?php echo $action ?>" method="post" class="col-md-6 offset-md-3 border border-primary p-3 rounded">
        <div class="form-group">
            <label for="libelle">Libellé</label>
            <input type="text" class="form-control" id='libelle' placeholder="Saisir le libellé" name="libelle" value="<?php if ($action == "Modifier"){echo $laNationalite->libelle;} ?>">
        </div>
        <div class="form-group">
            <label for="continent">Libellé</label>
            <select name="continent" class="form-control">
                <?php
                foreach($lesContinents as $continent){
                    $selection=$continent->num == $laNationalite->numContinent ? 'selected' : '';
                    echo "<option value='$continent->num' $selection>$continent->libelle</option>";
                }
                ?>
            </select>
        </div>
        <input type="hidden" id="num" name="num" value="<?php if ($action == "Modifier"){echo $laNationalite->getNum();} ?>">
        <div class="row">
            <!-- btn-block pour prendre toute la largeur de la div parent -->
            <div class="col"><a href="listeNationalites.php" class="btn btn-warning btn-block">Revenir à la liste</a></div>
            <div class="col"><button type="submit" class="btn btn-success btn-block">Ajouter</button></div>
        </div>
    </form>
</div>
<div class="container mt-5">
    <h2 class="pt-3 text-center"><?php echo $mode ?> un auteur</h2>
    <!--class="col-md-6 offset-md-3" colonne de 6/12 quand screen >= md à partir de la 3ème colonne de droite -->
    <form action="index.php?uc=auteurs&action=validerForm"<?php echo $action ?>" method="post" class="col-md-6 offset-md-3 border border-primary p-3 rounded">
        <div class="form-group">
            <label for="nom">Nom</label>
            <input type="text" class="form-control" id='nom' placeholder="Saisir un nom" name="nom" value="<?php if ($mode == "Modifier"){echo $unAuteur->getNom();} ?>">
        </div>
        <div class="form-group">
            <label for="prenom">Prénom</label>
            <input type="text" class="form-control" id='prenom' placeholder="Saisir un prénom" name="prenom" value="<?php if ($mode == "Modifier"){echo $unAuteur->getPrenom();} ?>">
        </div>
        <div class="form-group">
            <label for="nationalite">Nationalité</label>
            <select name="nationalite" class="form-control">
                <?php
                foreach($lesNationalites as $nationalite){
                    if($mode == "Modifier"){
                        $selection = $nationalite->numero == $unAuteur->getNationalite()->getNum() ? 'selected' : '';
                    }
                    echo "<option value='".$nationalite->numero."'".$selection.">".$nationalite->libNation."</option>";
                }
                ?>
            </select>
        </div>
        <input type="hidden" id="num" name="num" value="<?php if ($mode == "Modifier"){echo $unAuteur->getNum();} ?>">
        <div class="row">
            <!-- btn-block pour prendre toute la largeur de la div parent -->
            <div class="col"><a href="index.php?uc=auteurs&action=list" class="btn btn-warning btn-block">Revenir à la liste</a></div>
            <div class="col"><button type="submit" class="btn btn-success btn-block"><?php echo $mode ?></button></div>
        </div>
    </form>
</div>
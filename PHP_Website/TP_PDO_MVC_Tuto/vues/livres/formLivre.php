<div class="container mt-5">
    <h2 class="pt-3 text-center"><?php echo $mode ?> un livre</h2>
    <!--class="col-md-6 offset-md-3" colonne de 6/12 quand screen >= md à partir de la 3ème colonne de droite -->
    <form action="index.php?uc=livres&action=validerForm"<?php echo $action ?> method="post" class="col-md-6 offset-md-3 border border-primary p-3 rounded">
        <div class="form-group">
            <div class="row">
                <div class="col-4">
                    <label for="isbn">ISBN</label>
                    <input type="text" class="form-control" id='isbn' placeholder="X-XXX-XXXXX-X" name="isbn" value="<?php if ($mode == "Modifier"){echo $unLivre->getIsbn();} ?>">
                </div>
                <div class="col-8">
                    <label for="titre">Titre</label>
                    <input type="text" class="form-control" id='titre' placeholder="Saisir un titre" name="titre" value="<?php if ($mode == "Modifier"){echo $unLivre->getTitre();} ?>">
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-2">
                    <label for="prix">Prix</label>
                    <input type="number" class="form-control" id='prix' placeholder="€" name="prix" value="<?php if ($mode == "Modifier"){echo $unLivre->getprix();} ?>">
                </div>
                <div class="col-4">
                    <label for="editeur">Editeur</label>
                    <input type="text" class="form-control" id='editeur' placeholder="Saisir éditeur" name="editeur" value="<?php if ($mode == "Modifier"){echo $unLivre->getEditeur();} ?>">
                </div>
                <div class="col-2">
                    <label for="annee">Année</label>
                    <input type="number" class="form-control" id='annee' placeholder="Année" name="annee" value="<?php if ($mode == "Modifier"){echo $unLivre->getAnnee();} ?>">
                </div>
                <div class="col-4">
                    <label for="langue">Langue</label>
                    <input type="text" class="form-control" id='langue' placeholder="Saisir une langue" name="langue" value="<?php if ($mode == "Modifier"){echo $unLivre->getLangue();} ?>">
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col">
                    <label for="auteur">Auteur</label>
                    <select name="auteur" class="form-control">
                        <?php
                        foreach($lesAuteurs as $auteur){
                            if($mode == "Modifier"){
                                $selection = $auteur->numero == $unLivre->getAuteur()->getNum() ? 'selected' : '';
                            }
                            echo "<option value='".$auteur->numero."'".$selection.">".$auteur->prenom." ".$auteur->nom."</option>";
                        }
                        ?>
                    </select>
                </div>
                <div class="col">
                    <label for="genre">Genre</label>
                    <select name="genre" class="form-control">
                        <?php
                        foreach($lesGenres as $genre){
                            if($mode == "Modifier"){
                                $selection = $genre->getnum() == $unLivre->getGenre()->getNum() ? 'selected' : '';
                            }
                            echo "<option value='".$genre->getNum()."'".$selection.">".$genre->getLibelle()."</option>";
                        }
                        ?>
                    </select>
                </div>
            </div>
        </div>
        <input type="hidden" id="num" name="num" value="<?php if ($mode == "Modifier"){echo $unLivre->getNum();} ?>">
        <div class="row">
            <!-- btn-block pour prendre toute la largeur de la div parent -->
            <div class="col"><a href="index.php?uc=livres&action=list" class="btn btn-warning btn-block">Revenir à la liste</a></div>
            <div class="col"><button type="submit" class="btn btn-success btn-block"><?php echo $mode ?></button></div>
        </div>
    </form>
</div>

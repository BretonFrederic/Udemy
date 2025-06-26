<div class="container mt-5">
    <div class="row pt-3">

        <div class="col-9">
            <h2>Liste des livres</h2>
        </div>
        <div class="col-3">
            <a href="index.php?uc=livres&action=add" class='btn btn-success'><i class="fas fa-plus-circle"></i> Créer un livre</a>
        </div>
    </div>

    <form id="formrecherche" action="index.php?uc=livres&action=list" method="post" class="border border-primary rounded p-3 mt-3 mb-3">
        <div class="row">
            <div class="col">
                <input type="text" class="form-control" id='titre' placeholder="Titre du livre" name="titre" value="<?php echo $titre;?>">
            </div>
            <div class="col">
                <select name="auteur" class="form-control">
                    <?php
                    echo "<option value='Tous'>Toutes les auteurs</option>";

                    foreach($lesAuteurs as $auteur){
                        $selection = $auteur->numero == $auteurSel ? 'selected' : '';
                        echo "<option value='".$auteur->numero."'". $selection.">".$auteur->nom." ".$auteur->prenom."</option>";
                    }
                    ?>
                </select>
            </div>
            <div class="col">
                <select name="genre" class="form-control">
                    <?php
                    echo "<option value='Tous'>Toutes les genres</option>";

                    foreach($lesGenres as $genre){
                        $selection = $genre->getnum() == $genreSel ? 'selected' : '';
                        echo "<option value='".$genre->getNum()."'". $selection.">".$genre->getLibelle()."</option>";
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
                <th scope="col" class="col-md-1">ISBN</th>
                <th scope="col" class="col-md-2">Titre</th>
                <th scope="col" class="col-md-1">Prix</th>
                <th scope="col" class="col-md-1">Editeur</th>
                <th scope="col" class="col-md-1">Année</th>
                <th scope="col" class="col-md-1">Langue</th>
                <th scope="col" class="col-md-2">Auteur</th>
                <th scope="col" class="col-md-1">Genre</th>
                <th scope="col" class="col-md-2">Actions</th>
            </tr>
        </thead>
        <tbody>
            <?php
            foreach ($lesLivres as $livre) {
                echo "<tr class='d-flex'>";
                echo "<td class='col-md-1'>$livre->isbn</td>";
                echo "<td class='col-md-2'>$livre->titre</td>";
                echo "<td class='col-md-1'>$livre->prix</td>";
                echo "<td class='col-md-1'>$livre->editeur</td>";
                echo "<td class='col-md-1'>$livre->annee</td>";
                echo "<td class='col-md-1'>$livre->langue</td>";
                echo "<td class='col-md-2'>$livre->nomAuteur</td>";
                echo "<td class='col-md-1'>$livre->genre</td>";
                echo "<td class='col-md-2'>
                    <a href='index.php?uc=livres&action=update&num=".$livre->numeroLivre."' class='btn btn-primary'><i class='fas fa-pen'></i></a>
                    <a href='#modalSuppression' data-toggle='modal' data-message='Voulez-vous supprimer cet livre ?' data-suppression='index.php?uc=livres&action=delete&num=".$livre->numeroLivre."' class='btn btn-danger'><i class='fas fa-trash-alt'></i></a>
                </td>";
                echo "</tr>";
            }

            ?>
        </tbody>
    </table>
</div>
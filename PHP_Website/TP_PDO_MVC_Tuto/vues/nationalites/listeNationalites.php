<div class="container mt-5">
    <div class="row pt-3">

        <div class="col-9">
            <h2>Liste des nationalités</h2>
        </div>
        <div class="col-3">
            <a href="index.php?uc=nationalites&action=add" class='btn btn-success'><i class="fas fa-plus-circle"></i> Créer une nationalité</a>
        </div>
    </div>

    <form id="formrecherche" action="index.php?uc=nationalites&action=list" method="post" class="border border-primary rounded p-3 mt-3 mb-3">
        <div class="row">
            <div class="col">
                <input type="text" class="form-control" id='libelle' placeholder="Saisir le libellé" name="libelle" value="<?php echo $libelle;?>">
            </div>
            <div class="col">
                <select name="continent" class="form-control">
                    <?php
                    echo "<option value='Tous'>Tous les continents</option>";
                    // Modèle Continent setFetchMode(PDO::FETCH_CLASS) utilisation des getters et setters
                    foreach($lesContinents as $continent){
                        $selection = $continent->getNum() == $continentSel ? 'selected' : '';
                        echo "<option value='".$continent->getNum()."'". $selection.">".$continent->getLibelle()."</option>";
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
                // Modèle Nationalite setFetchMode(PDO::FETCH_OBJ) utilisation des noms de champs database
                echo "<tr class='d-flex'>";
                echo "<td class='col-md-2'>$nationalite->numero</td>";
                echo "<td class='col-md-5'>$nationalite->libNation</td>";
                echo "<td class='col-md-3'>$nationalite->libContinent</td>";

                // Avec ? on passe en paramètre num=$nationalite->num qui compose l'url
                echo "<td class='col-md-2'>
                    <a href='index.php?uc=nationalites&action=Modifier&num=$nationalite->numero' class='btn btn-primary'><i class='fas fa-pen'></i></a>
                    <a href='#modalSuppression' data-toggle='modal' data-message='Voulez-vous supprimer cette nationalité ?' data-suppression='supprimerNationalite.php?num=$nationalite->numero' class='btn btn-danger'><i class='fas fa-trash-alt'></i></a>
                </td>";
                echo "</tr>";
            }

// supprimerNationalite.php?num=$nationalite->num

            ?>
        </tbody>
    </table>
</div>
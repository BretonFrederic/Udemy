<?php
$action = $_GET['action'];
switch($action){
    case 'list':
        $titre = "";
        $auteurSel = "Tous";
        $genreSel = "Tous";
        if(!empty($_POST['titre']) || !empty($_POST['auteur']) || !empty($_POST['genre'])){
            $titre = $_POST['titre'];
            $auteurSel = $_POST['auteur'];
            $genreSel = $_POST['genre'];
        }
        $lesLivres = Livre::findAll($titre, $auteurSel, $genreSel);
        $lesAuteurs = Auteur::findAll();
        $lesGenres = Genre::findAll();
        include('vues/livres/listeLivres.php');
        break;
}
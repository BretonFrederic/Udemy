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
    case 'add':
        $mode = "Ajouter";
        $lesGenres = Genre::findAll();
        $lesAuteurs = Auteur::findAll();
        include("vues/livres/formLivre.php");
        break;
    case 'update':
        $mode = "Modifier";
        $lesGenres = Genre::findAll();
        $lesAuteurs = Auteur::findAll();
        $unLivre = Livre::findById($_GET['num']);
        include("vues/livres/formLivre.php");
        break;
    case 'delete':
        $unLivre = Livre::findById($_GET['num']);
        $nb = Livre::delete($unLivre);
        if($nb == 1){
            $_SESSION['message']=["success"=>"L'auteur a bien été supprimé"];
        }else{
            $_SESSION['message']=["danger"=>"L'auteur n'a pas été supprimé"];
        }
        header('location: index.php?uc=livres&action=list');
        exit();
        break;
    case 'validerForm':
        $livre = new Livre();
        $auteur = Auteur::findById($_POST['auteur']);
        $genre = Genre::findById($_POST['genre']);
        $livre->setIsbn($_POST['isbn']);
        $livre->setTitre($_POST['titre']);
        $livre->setPrix($_POST['prix']);
        $livre->setEditeur($_POST['editeur']);
        $livre->setAnnee($_POST['annee']);
        $livre->setLangue($_POST['langue']);
        $livre->setAuteur($auteur);
        $livre->setGenre($genre);
        if(empty($_POST['num'])){
            $nb = Livre::add($livre);
            $message = "ajouté";
        }
        else{
            $livre->setNum($_POST['num']);
            $nb = Livre::update($livre);
            $message = "modifié";
        }
        if($nb == 1){
            $_SESSION["message"] = ["success"=>"Le livre a bien été $message"];
        }
        else{
            $_SESSION['message']=["danger"=>"Le livre n'a pas été $message"];
        }
        header('location: index.php?uc=livres&action=list');
        exit();
        break;
}
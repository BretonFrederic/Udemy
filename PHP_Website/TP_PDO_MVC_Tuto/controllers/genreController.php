<?php
$action = $_GET['action'];
switch($action){
    case 'list':
        $lesGenres = Genre::findAll();
        include('vues/genres/listeGenres.php');
        break;
    case 'add':
        $mode = "Ajouter";
        include('vues/genres/formGenre.php');
        break;
    case 'update':
        $mode = "Modifier";
        $genre = Genre::findById($_GET['num']);
        include('vues/genres/formGenre.php');
        break;
    case 'delete':
        $genre = Genre::findById($_GET['num']);
        $nb = Genre::delete($genre);
        if($nb == 1){
            $_SESSION['message']=["success"=>"Le genre a bien été supprimé"];
        }else{
            $_SESSION['message']=["danger"=>"Le genre n'a pas été supprimé"];
        }
        header('location: index.php?uc=genres&action=list');
        exit();
        break;
    case 'validerForm':
        $genre = new Genre();
        if(empty($_POST['num'])){// cas d'une création
            $genre->setLibelle($_POST['libelle']);
            $nb = Genre::add($genre);
            $message = "ajouté";
        }else{// cas modification
            $genre->setNum($_POST['num']);
            $genre->setLibelle($_POST['libelle']);
            $nb = Genre::update($genre);
            $message = "modifié";
        }

        if($nb == 1){
            $_SESSION['message']=["success"=>"Le genre a bien été $message"];
        }else{
            $_SESSION['message']=["danger"=>"Le genre a bien été $message"];
        }
        header('location: index.php?uc=genres&action=list');
        exit();
        break;
}
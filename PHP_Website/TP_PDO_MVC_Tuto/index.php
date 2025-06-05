<?php session_start(); ?>
<?php include "vues/header.php";

$uc = empty($_GET['UC']) ? "accueil" : $_GET['UC'];

switch($uc){
    case 'accueil':
        include('vues/accueil.php');
        break;
    case 'continents':
        break;
}

include "vues/footer.php"; ?>
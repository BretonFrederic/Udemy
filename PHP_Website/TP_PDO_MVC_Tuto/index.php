<?php ob_start();
session_start();
include("modeles/Continent.php");
include("modeles/Nationalite.php");
include("modeles/monPdo.php");
include("vues/header.php");
include("vues/messagesFlash.php");

$uc = empty($_GET['uc']) ? "accueil" : $_GET['uc'];

switch($uc){
    case 'accueil':
        include('vues/accueil.php');
        break;
    case 'continents':
        include('controllers/continentController.php');
        break;
    case 'nationalites':
        include('controllers/nationaliteController.php');
        break;
}

include "vues/footer.php"; ?>
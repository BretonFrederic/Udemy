<?php
  $hostnom = 'host=localhost';
  $usernom = 'root';
  $password = '';
  $bdd = 'biblio';

  try{
    // Creation d'une instance de PDO et tentative de connexion
    $monPdo = new PDO("mysql:$hostnom;dbname=$bdd;charset=utf8", $usernom, $password);
    // Cette ligne ci dessous est utilisé pour afficher des messages d'erreur en mode développement.
    // RETIRER EN PRDUCTION
    $monPdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
  } catch(PDOException $e){
    echo $e->getMessage();
    $monPdo = null;
  }
?>
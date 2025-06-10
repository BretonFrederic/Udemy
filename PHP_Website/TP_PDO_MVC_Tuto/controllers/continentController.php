<?php
$action = $_GET['action'];
switch($action){
    case 'list':
        $lesContinents = Continent::findAll();
        include('vues/listeContinents.php');
        break;
    case 'add':
        # code...
        break;
    case 'update':
        # code...
        break;
    case 'delete':
        # code...
        break;
}
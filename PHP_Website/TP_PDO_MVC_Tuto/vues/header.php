<!doctype html>
<html lang="en">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="Mark Otto, Jacob Thornton, and Bootstrap contributors">
  <meta name="generator" content="Jekyll v3.8.5">
  <title>Jumbotron Template · Bootstrap</title>

  <link rel="canonical" href="https://getbootstrap.com/docs/4.2/examples/jumbotron/">
  <link rel="stylesheet" href="jumbotron.css">


  <!-- Bootstrap core CSS -->
  <link rel="stylesheet" href="https://bootswatch.com/4/cerulean/bootstrap.css">

  <link rel="stylesheet" href="../css/liensDecoration.css">

  <!--fontawesome.com -->
  <script src="https://kit.fontawesome.com/e0ab3a2c1c.js" crossorigin="anonymous"></script>

  <style>
    .bd-placeholder-img {
      font-size: 1.125rem;
      text-anchor: middle;
    }

    @media (min-width: 768px) {
      .bd-placeholder-img-lg {
        font-size: 3.5rem;
      }
    }
  </style>
  <!-- Custom styles for this template -->
  <link href="jumbotron.css" rel="stylesheet">
</head>

<body>
  <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-primary">
    <a class="navbar-brand" href="index.php">Ma bibliothèque</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarsExampleDefault">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="dropdown01" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Gestion des genres</a>
          <div class="dropdown-menu" aria-labelledby="dropdown01">
            <a class="dropdown-item" href="index.php?uc=genres&action=list">Liste des genres</a>
            <a class="dropdown-item" href="index.php?uc=genres&action=add">Ajouter un genre</a>
          </div>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="dropdown01" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa-solid fa-person"></i> Gestion des auteurs</a>
          <div class="dropdown-menu" aria-labelledby="dropdown01">
            <a class="dropdown-item" href="index.php?uc=auteurs&action=list">Liste des auteurs</a>
            <a class="dropdown-item" href="index.php?uc=auteurs&action=add">Ajouter un auteur</a>
          </div>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="dropdown01" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa-regular fa-flag"></i> Gestion des nationalités</a>
          <div class="dropdown-menu" aria-labelledby="dropdown01">
            <a class="dropdown-item" href="index.php?uc=nationalites&action=list">Liste des nationalités</a>
            <a class="dropdown-item" href="index.php?uc=nationalites&action=add">Ajouter une nationalité</a>
          </div>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="dropdown01" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa-solid fa-earth-africa"></i> Gestion des continents</a>
          <div class="dropdown-menu" aria-labelledby="dropdown01">
            <a class="dropdown-item" href="index.php?uc=continents&action=list">Liste des continents</a>
            <a class="dropdown-item" href="index.php?uc=continents&action=add">Ajouter un continent</a>
          </div>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="dropdown01" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa-solid fa-book-open"></i> Gestion des livres</a>
          <div class="dropdown-menu" aria-labelledby="dropdown01">
            <a class="dropdown-item" href="index.php?uc=livres&action=list">Liste des livres</a>
            <a class="dropdown-item" href="index.php?uc=livres&action=add">Ajouter un livre</a>
          </div>
        </li>
      </ul>
    </div>
  </nav>
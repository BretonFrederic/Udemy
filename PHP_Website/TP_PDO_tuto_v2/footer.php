<footer class="container">
  <p>&copy; TP 3 Rolland 2018-2019</p>
</footer>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.6/dist/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.2.1/dist/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
<script type="text/javascript">

  $("a[data-suppression]").click(function(){
    var lien = $(this).attr("data-suppression"); // Récupérer le lien qui prend en paramètre le num de nationalité du bouton icone poubelle
    $("#btnSuppr").attr("href", lien); // Ecrire ce lien en href sur le bouton "supprimer" de la modal boite de dialogue
  });

</script>
</body>
</html>
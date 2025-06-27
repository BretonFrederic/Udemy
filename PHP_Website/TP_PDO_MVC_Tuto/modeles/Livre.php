<?php
class Livre{

    /**
     * Numero du livre (clé primaire)
     *
     * @var [int]
     */
    private $num;

    /**
     * Identifiant international du livre
     *
     * @var [string]
     */
    private $isbn;

    /**
     * Titre du livre
     *
     * @var [string]
     */
    private $titre;

    /**
     * Prix du livre
     *
     * @var [int]
     */
    private $prix;

    /**
     * Nom de l'éditeur du livre
     *
     * @var [string]
     */
    private $editeur;

    /**
     * Année du livre
     *
     * @var [int]
     */
    private $annee;

    /**
     * Langue du livre
     *
     * @var [string]
     */
    private $langue;

    /**
     * Numéro de l'auteur (clé étrangère)
     *
     * @var [int]
     */
    private $numAuteur;

    /**
     * Numéro du genre littéraire (clé étrangère)
     *
     * @var [int]
     */
    private $numGenre;

    /**
     * Accesseur numero du livre
     *
     * @return  [int]
     */ 
    public function getNum()
    {
        return $this->num;
    }

    /**
     * Mutateur le numero du livre
     *
     * @param  [int]  $num  Numero du livre
     *
     * @return  self
     */ 
    public function setNum(int $num)
    {
        $this->num = $num;

        return $this;
    }

    /**
     * Accesseur identifiant international du livre
     *
     * @return  [string]
     */ 
    public function getIsbn()
    {
        return $this->isbn;
    }

    /**
     * Mutateur identifiant international du livre
     *
     * @param  [string]  $isbn  Identifiant international du livre
     *
     * @return  self
     */ 
    public function setIsbn(string $isbn) :self
    {
        $this->isbn = $isbn;

        return $this;
    }

    /**
     * Accesseur du titre du livre
     *
     * @return  [string]
     */ 
    public function getTitre()
    {
        return $this->titre;
    }

    /**
     * Mutateur du titre du livre
     *
     * @param  [string]  $titre  Titre du livre
     *
     * @return  self
     */ 
    public function setTitre(string $titre) :self
    {
        $this->titre = $titre;

        return $this;
    }

    /**
     * Accesseur prix du livre
     *
     * @return  [int]
     */ 
    public function getPrix()
    {
        return $this->prix;
    }

    /**
     * mutateur du prix du livre
     *
     * @param  [int]  $prix  Prix du livre
     *
     * @return  self
     */ 
    public function setPrix(int $prix) :self
    {
        $this->prix = $prix;

        return $this;
    }

    /**
     * Accesseur du nom de l'éditeur du livre
     *
     * @return  [string]
     */ 
    public function getEditeur()
    {
        return $this->editeur;
    }

    /**
     * Mutateur du nom de l'éditeur du livre
     *
     * @param  [string]  $editeur  Nom de l'éditeur du livre
     *
     * @return  self
     */ 
    public function setEditeur(string $editeur) :self
    {
        $this->editeur = $editeur;

        return $this;
    }

    /**
     * Accesseur de l'année du livre
     *
     * @return  [int]
     */ 
    public function getAnnee()
    {
        return $this->annee;
    }

    /**
     * Mutateur de l'année du livre
     *
     * @param  [int]  $annee  Année du livre
     *
     * @return  self
     */ 
    public function setAnnee(int $annee) :self
    {
        $this->annee = $annee;

        return $this;
    }

    /**
     * Accesseur de la langue du livre
     *
     * @return  [string]
     */ 
    public function getLangue()
    {
        return $this->langue;
    }

    /**
     * Mutateur de la langue du livre
     *
     * @param  [string]  $langue  Langue du livre
     *
     * @return  self
     */ 
    public function setLangue(string $langue) :self
    {
        $this->langue = $langue;

        return $this;
    }

    /**
     * Accesseur de l'objet auteur associé
     *
     * @return  Auteur
     */ 
    public function getAuteur() :Auteur
    {
        return Auteur::findById($this->numAuteur);
    }

    /**
     * Mutateur de numAuteur
     *
     * @param  [Auteur]  $auteur objet auteur
     *
     * @return  self
     */ 
    public function setAuteur(Auteur $auteur) :self
    {
        $this->numAuteur = $auteur->getNum();

        return $this;
    }

    /**
     * Accesseur de l'objet genre associé
     *
     * @return Genre
     */
    public function getGenre() :Genre
    {
        return Genre::findById($this->numGenre);
    }

    /**
     * Mutateur de numGenre
     *
     * @param Genre $genre
     * @return self
     */
    public function setGenre(Genre $genre) :self
    {
        $this->numGenre = $genre->getNum();
        return $this;
    }

    public static function findAll(?string $titre="", ?string $auteur="Tous", ?string $genre="Tous") :array
    {
        // Préparation de la requête
        $texteReq = "select l.num as 'numeroLivre', l.isbn, l.titre, l.prix, l.editeur, l.annee, l.langue, concat(a.nom, ' ', a.prenom) as 'nomAuteur', g.libelle as 'genre' from livre l, auteur a, genre g where l.numAuteur = a.num and l.numGenre = g.num";
        if($titre != ""){
            $texteReq .= " and l.titre like '%" .$titre."%'";
        }
        if($auteur != "Tous"){
            $texteReq .= " and a.num = " .$auteur;
        }
        if($genre != "Tous"){
            $texteReq .= " and g.num =" .$genre;
        }
        $texteReq .= " order by l.titre";

        $req = MonPdo::getInstance()->prepare($texteReq);
        $req->setFetchMode(PDO::FETCH_OBJ);
        $req->execute();
        $lesResultats = $req->fetchAll();
        return $lesResultats;
    }

    public static function findById(int $id) :Livre
    {
        $req = MonPdo::getInstance()->prepare("select * from livre where num = :id");
        $req->setFetchMode(PDO::FETCH_CLASS | PDO::FETCH_PROPS_LATE, 'livre');
        $req->bidParam("id", $id);
        $req->execute();
        $leResultat = $req->fetch();
        return $leResultat;
    }
}
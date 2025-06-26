<?php
class Auteur{

    /**
     * Numero de auteur
     *
     * @var [int]
     */
    private $num;

    /**
     * Nom de l'auteur
     *
     * @var [string]
     */
    private $nom;

    /**
     * Prénom de l'auteur
     *
     * @var [string]
     */
    private $prenom;

    /**
     * numNationalite (clé étrangère) relié à num de la nationalité
     *
     * @var [int]
     */
    private $numNationalite;

    /**
     * Accesseur de la valeur num
     */
    public function getNum()
    {
        return $this->num;
    }

    /**
     * Mutateur le numero de auteur
     *
     * @param  [int]  $num  Numero de auteur
     *
     * @return  self
     */ 
    public function setNum(int $num)
    {
        $this->num = $num;

        return $this;
    }

    /**
     * Accesseur de la valeur nom
     * 
     * @return string
     */
    public function getNom() : string
    {
        return $this->nom;
    }

    /**
     * Mutateur de la valeur nom
     * 
     * @param string $nom
     * @return self
     */

    public function setNom(string $nom) : self
    {
        $this->nom = $nom;
        return $this;
    }

        /**
     * Accesseur de la valeur prenom
     * 
     * @return string
     */
    public function getPrenom() : string
    {
        return $this->prenom;
    }

    /**
     * Mutateur de la valeur prenom
     * 
     * @param string $prenom
     * @return self
     */

    public function setPrenom(string $prenom) : self
    {
        $this->prenom = $prenom;
        return $this;
    }

    /**
     * Renvoie l'objet nationalite associé
     *
     * @return Nationalite
     */
    public function getNationalite() :Nationalite
    {
        return Nationalite::findById($this->numNationalite);
    }

    /**
     * Mutateur de numNationalite
     *
     * @return  self
     */ 
    public function setNationalite(Nationalite $nationalite) : self
    {
        $this->numNationalite = $nationalite->getNum();
        return $this;
    }

    /**
     * retourne l'ensemble des auteurs
     *
     * @return array Auteur[] d'objet auteur
     */
    public static function findAll(?string $nom = "", ?string $prenom = "", ?string $nationalite = "Toutes") : array
    {
        // Préparation de la requête
        $texteReq = "select a.num as 'numero', a.nom, a.prenom, n.libelle from auteur a, nationalite n where a.numNationalite = n.num";
        if($nom != ""){ 
            $texteReq .= " and a.nom like '%" .$nom."%'";
        }
        if($prenom != ""){ 
            $texteReq .= " and a.prenom like '%" .$prenom."%'";
        }
        if($nationalite != "Toutes") { 
            $texteReq .= " and n.num =" .$nationalite;
        }
        $texteReq .= " order by a.nom";

        $req = MonPdo::getInstance()->prepare($texteReq);
        $req->setFetchMode(PDO::FETCH_OBJ);
        $req->execute();
        $lesResultats = $req->fetchAll();
        return $lesResultats;
    }

    /**
     * Trouve un auteur par son num
     *
     * @param integer $id numéro de auteur
     * @return Auteur objet auteur trouvé
     */
    public static function findById(int $id) :Auteur 
    {
        $req = MonPdo::getInstance()->prepare("Select * from auteur where num = :id");
        $req->setFetchMode(PDO::FETCH_CLASS|PDO::FETCH_PROPS_LATE, 'Auteur');
        $req->bindParam(':id', $id);
        $req->execute();
        $leResultat = $req->fetch();
        return $leResultat;
    }

    /**
     * Permet d'ajouter une auteur
     *
     * @param Auteur $auteur nationalite à ajouter
     * @return integer resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function add(Auteur $auteur) :int
    {
        $req = MonPdo::getInstance()->prepare("insert into auteur(nom,prenom,numNationalite) values(:nom, :prenom, :numNationalite)");
        $nom = $auteur->getNom();
        $prenom = $auteur->getPrenom();
        $num = $auteur->numNationalite;
        $req->bindParam(':nom', $nom);
        $req->bindParam(':prenom', $prenom);
        $req->bindParam(':numNationalite', $num);
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Permet de modifier un auteur
     *
     * @param Auteur $auteur auteur à modifier
     * @return integer resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function update(Auteur $auteur) :int
    {
        $req = MonPdo::getInstance()->prepare("update auteur set nom = :nom, prenom = :prenom, numNationalite = :numNationalite where num = :id");
        $num = $auteur->getNum();
        $nom = $auteur->getNom();
        $prenom = $auteur->getPrenom();
        $numC = $auteur->numNationalite;
        $req->bindParam(':id', $num);
        $req->bindParam(':nom', $nom);
        $req->bindParam(':prenom', $prenom);
        $req->bindParam(':numNationalite', $numC);
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Permet de supprimer un auteur
     *
     * @param Auteur $auteur à supprimer
     * @return integer  resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function delete(Auteur $auteur) :int
    {
        $req = MonPdo::getInstance()->prepare("delete from auteur where num = :id");
        $num = $auteur->getNum();
        $req->bindParam(':id', $num);
        $nb = $req->execute();
        return $nb;
    }
}
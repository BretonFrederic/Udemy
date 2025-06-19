<?php
class Genre{

    /**
     * Numero du genre
     *
     * @var [int]
     */
    private $num;

    /**
     * Libelle du genre
     *
     * @var [string]
     */
    private $libelle;



    /**
     * Accesseur de la valeur num
     */
    public function getNum()
    {
        return $this->num;
    }

    /**
     * Accesseur de la valeur libelle
     * 
     * @return string
     */
    public function getLibelle() :string
    {
        return $this->libelle;
    }

    /**
     * Mutateur de la valeur libelle
     * 
     * @param string $libelle
     * @return self
     */

    public function setLibelle(string $libelle) :self
    {
        $this->libelle = $libelle;
        return $this;
    }

    /**
     * retourne l'ensemble des genres
     *
     * @return array Genre[] d'objet genre
     */
    public static function findAll() :array
    {
        $req = MonPdo::getInstance()->prepare("select * from genre");
        // FETCH_PROPS_LATE pour passer par le constructeur pour construire l'objet.
        $req->setFetchMode(PDO::FETCH_CLASS|PDO::FETCH_PROPS_LATE, 'Genre');
        $req->execute();
        $lesResultats = $req->fetchAll();
        return $lesResultats;
    }

    /**
     * Trouve un genre par son num
     *
     * @param integer $id numéro du genre
     * @return Genre objet genre trouvé
     */
    public static function findById(int $id) :Genre 
    {
        $req = MonPdo::getInstance()->prepare("Select * from genre where num = :id");
        $req->setFetchMode(PDO::FETCH_CLASS|PDO::FETCH_PROPS_LATE, 'Genre');
        $req->bindParam(':id', $id);
        $req->execute();
        $leResultat = $req->fetch();
        return $leResultat;
    }

    /**
     * Permet d'ajouter un genre
     *
     * @param Genre $genre genre à ajouter
     * @return integer resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function add(Genre $genre) :int
    {
        $req = MonPdo::getInstance()->prepare("insert into genre(libelle) values(:libelle)");
        $libelle = $genre->getLibelle();
        $req->bindParam(':libelle', $libelle);
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Permet de modifier un genre
     *
     * @param Genre $genre genre à modifier
     * @return integer resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function update(Genre $genre) :int
    {
        $req = MonPdo::getInstance()->prepare("update genre set libelle= :libelle where num = :id");
        $num =  $genre->getNum();
        $libelle = $genre->getLibelle();
        $req->bindParam(':id',$num);
        $req->bindParam(':libelle', $libelle);
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Permet de supprimer un genre
     *
     * @param Genre $genre à supprimer
     * @return integer  resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function delete(Genre $genre) :int
    {
        $req = MonPdo::getInstance()->prepare("delete from genre where num = :id");
        $num = $genre->getNum();
        $req->bindParam(':id', $num);
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Set numero du genre
     *
     * @param  [int]  $num  Numero du genre
     *
     * @return  self
     */ 
    public function setNum(int $num) :self
    {
        $this->num = $num;

        return $this;
    }
}
<?php
class Continent{

    /**
     * Numero du continent
     *
     * @var [int]
     */
    private $num;

    /**
     * Libelle du continent
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
     * retourne l'ensemble des continents
     *
     * @return array Continent[] d'objet continent
     */
    public static function findAll() :array
    {
        $req = MonPdo::getInstance()->prepare("select * from continent");
        // FETCH_PROPS_LATE pour passer par le constructeur pour construire l'objet.
        $req->setFetchMode(PDO::FETCH_CLASS|PDO::FETCH_PROPS_LATE, 'continent');
        $req->execute();
        $lesResultats = $req->fetchAll();
        return $lesResultats;
    }

    /**
     * Trouve un continent par son num
     *
     * @param integer $id numéro du continent
     * @return Continent objet continent trouvé
     */
    public static function findById(int $id) :Continent 
    {
        $req = MonPdo::getInstance()->prepare("Select * from continent whre num = :id");
        $req->setFetchMode(PDO::FETCH_CLASS|PDO::FETCH_PROPS_LATE, 'Continent');
        $req->bindParam(':id', $id);
        $req->execute();
        $leResultat = $req->fetch();
        return $leResultat;
    }

    /**
     * Permet d'ajouter un continent
     *
     * @param Continent $continent continent à ajouter
     * @return integer resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function add(Continent $continent) :int
    {
        $req = MonPdo::getInstance()->prepare("insert into continent(libelle) values(:libelle)");
        $req->bindParam(':libelle', $continent->getLibelle());
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Permet de modifier un continent
     *
     * @param Continent $continent continent à modifier
     * @return integer resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function update(Continent $continent) :int
    {
        $req = MonPdo::getInstance()->prepare("update into continent set libelle= :libelle where num = :id");
        $req->bindParam(':id', $continent->getNum());
        $req->bindParam(':libelle', $continent->getLibelle());
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Permet de supprimer un continent
     *
     * @param Continent $continent à supprimer
     * @return integer  resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function delete(Continent $continent) :int
    {
        $req = MonPdo::getInstance()->prepare("delete from continent where num = :id");
        $req->bindParam(':id', $continent->getNum());
        $nb = $req->execute();
        return $nb;
    }
}
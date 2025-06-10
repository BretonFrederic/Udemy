<?php
class Nationalite{

    /**
     * Numero de nationalité
     *
     * @var [int]
     */
    private $num;

    /**
     * Libelle de la nationalité
     *
     * @var [string]
     */
    private $libelle;

    /**
     * num continent (clé étrangère) relié à num de continent
     *
     * @var [int]
     */
    private $numContinent;

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
    public function getLibelle() : string
    {
        return $this->libelle;
    }

    /**
     * Mutateur de la valeur libelle
     * 
     * @param string $libelle
     * @return self
     */

    public function setLibelle(string $libelle) : self
    {
        $this->libelle = $libelle;
        return $this;
    }

    /**
     * Renvoie l'objet continent associé
     *
     * @return Continent
     */
    public function getNumContinent() :Continent
    {
        return Continent::findById($this->numContinent);
    }

    /**
     * Set the value of numContinent
     *
     * @return  self
     */ 
    public function setNumContinent(Continent $continent) : self
    {
        $this->numContinent = $continent->getNum();
        return $this;
    }

    /**
     * retourne l'ensemble des nationalités
     *
     * @return array Nationalite[] d'objet nationalité
     */
    public static function findAll() : array
    {
        $req = MonPdo::getInstance()->prepare("select n.num as 'numero', n.libelle as 'libNation', c.libelle as 'libContinent' from nationalite n, continent c where n.numContinent = c.num");
        // FETCH_PROPS_LATE pour passer par le constructeur pour construire l'objet.
        $req->setFetchMode(PDO::FETCH_OBJ);
        $req->execute();
        $lesResultats = $req->fetchAll();
        return $lesResultats;
    }

    /**
     * Trouve une nationalité par son num
     *
     * @param integer $id numéro de nationalité
     * @return Nationalite objet nationalite trouvé
     */
    public static function findById(int $id) :Nationalite 
    {
        $req = MonPdo::getInstance()->prepare("Select * from nationalite where num = :id");
        $req->setFetchMode(PDO::FETCH_CLASS|PDO::FETCH_PROPS_LATE, 'Nationalite');
        $req->bindParam(':id', $id);
        $req->execute();
        $leResultat = $req->fetch();
        return $leResultat;
    }

    /**
     * Permet d'ajouter une nationalité
     *
     * @param Nationalite $nationalite nationalité à ajouter
     * @return integer resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function add(Nationalite $nationalite) :int
    {
        $req = MonPdo::getInstance()->prepare("insert into nationalite(libelle,numContinent) values(:libelle, :numContinent)");
        $req->bindParam(':libelle', $nationalite->getLibelle());
        $req->bindParam(':numContinent', $nationalite->numContinent);
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Permet de modifier un nationalite
     *
     * @param Nationalite $nationalite nationalité à modifier
     * @return integer resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function update(Nationalite $nationalite) :int
    {
        $req = MonPdo::getInstance()->prepare("update table set nationalite set libelle = :libelle, numContinent = :numContinent where num = :id");
        $req->bindParam(':id', $nationalite->getNum());
        $req->bindParam(':libelle', $nationalite->getLibelle());
        $req->bindParam(':numContinent', $nationalite->numContinent);
        $nb = $req->execute();
        return $nb;
    }

    /**
     * Permet de supprimer un nationalite
     *
     * @param Nationalite $nationalite à supprimer
     * @return integer  resultat (1 si l'opération a réussi, 0 sinon)
     */
    public static function delete(Nationalite $nationalite) :int
    {
        $req = MonPdo::getInstance()->prepare("delete from nationalite where num = :id");
        $req->bindParam(':id', $nationalite->getNum());
        $nb = $req->execute();
        return $nb;
    }


}
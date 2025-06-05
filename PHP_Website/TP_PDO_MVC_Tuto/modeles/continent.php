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
     * retourne l'ensemble des continents
     *
     * @return array Continent[] d'objet continent
     */
    public static function findAll() : array
    {
        $req = MonPdo::getinstance()->prepare("select * from continent");
        // FETCH_PROPS_LATE pour passer par le constructeur pour construire l'objet.
        $req->setFetchMode(PDO::FETCH_CLASS|PDO::FETCH_PROPS_LATE, 'continent');
        $req->execute();
        $lesResultats = $req->fetchAll();
        return $lesResultats;
    }
}
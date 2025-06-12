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
    public static function findAll(?string $libelle = "", ?string $continent = "Tous") : array
    {
        // Préparation de la requête
        $texteReq = "select n.num as 'numero', n.libelle as 'libNation', c.libelle as 'libContinent' from nationalite n, continent c where n.numContinent = c.num";
        if($libelle != ""){ 
            $texteReq .= " and n.libelle like '%" .$libelle."%'";
        }
        if($continent != "Tous") { 
            $texteReq .= " and c.num =" .$continent;
        }
        $texteReq .= " order by n.libelle";

        $req = MonPdo::getInstance()->prepare($texteReq);
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
        $libelle = $nationalite->getLibelle();
        $num = $nationalite->numContinent;
        $req->bindParam(':libelle', $libelle);
        $req->bindParam(':numContinent', $num);
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
        $num = $nationalite->getNum();
        $libelle = $nationalite->getLibelle();
        $numC = $nationalite->numContinent;
        $req->bindParam(':id', $num);
        $req->bindParam(':libelle', $libelle);
        $req->bindParam(':numContinent', $numC);
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
        $num = $nationalite->getNum();
        $req->bindParam(':id', $num);
        $nb = $req->execute();
        return $nb;
    }



    /**
     * Set numero de nationalité
     *
     * @param  [int]  $num  Numero de nationalité
     *
     * @return  self
     */ 
    public function setNum(int $num)
    {
        $this->num = $num;

        return $this;
    }
}
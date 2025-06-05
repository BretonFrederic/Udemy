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
     */
    public function getLibelle() : string
    {
        return $this->libelle;
    }

    /**
     * Mutateur de la valeur libelle
     * 
     * @return self
     */

    public function setLibelle(string $libelle) : self
    {
        $this->libelle = $libelle;
        return $this;
    }
}
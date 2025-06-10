<?php
/**
 *  Classe d'accès aux données. utilise les services de la classe PDO.
 *  Les attributs sont tous statiques, les 4 premiers pour la connexion.
 *  $monPdo qui contiendra l'unique instance de la classe.
 */
class MonPdo
{
    private static $serveur = 'mysql:host = localhost';
    private static $bdd = 'dbname = biblio';
    private static $user = 'root';
    private static $mdp = '';
    private static $monPdo;
    private static $unPdo = null;

    // Contructeur privé, crée l'instance de PDO qui sera sollicitée
    // pour toutes les méthodes de la classe
    private function _construct()
    {
        MonPdo::$unPdo = new PDO(MonPdo::$serveur.';'.MonPdo::$bdd, MonPdo::$user, MonPdo::$mdp);
        MonPdo::$unPdo->query("SET CHARACTER SET utf8");
        MonPdo::$unPdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    }
    public function __destruct()
    {
        MonPdo::$unPdo = null;
    }
    /**
     *  Fonction statique qui cree l'unique instance de la classe
     *  Appel : $instanceMonPdo = MonPdo::getMonpdo();
     *  @return l'unique objet de la classe MonPdo
     */
    public static function getInstance()
    {
        if(self::$unPdo == null)
        {
            self::$monPdo = new MonPdo();
        }
        return self::$unPdo;
    }
}
?>
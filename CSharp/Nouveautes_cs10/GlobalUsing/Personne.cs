//using Newtonsoft.Json; // Ajouté dans program.cs en global donc accessible pour tous les fichiers du projet

// 1 - Déclarer un espace de nom avant cs 10
/*
namespace GlobalUsing
{
    class Personne
    {
        public string? nom { get; set; }
        public int age { get; set; }

        public string Getjson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
*/

// 2 - Déclarer un espace de nom avec cs 10

namespace GlobalUsing;
class Personne
{
    public string? nom { get; set; }
    public int age { get; set; }

    public string Getjson()
    {
        return JsonConvert.SerializeObject(this);
    }
}

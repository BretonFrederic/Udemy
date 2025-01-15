// See https://aka.ms/new-console-template for more information

global using Newtonsoft.Json; // Déclaration global doit précéder les autres
using GlobalUsing; // Doit être rajoutée car ne fait pas partie des using implicites

Console.WriteLine("Hello, World!");

// var l = new List<string>();

var p = new Personne { nom = "Toto", age = 20 };
var json_p = JsonConvert.SerializeObject(p);
Console.WriteLine(json_p);
Console.WriteLine(p.Getjson());

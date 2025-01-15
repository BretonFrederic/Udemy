// C#10 - LAMBDAS

using System.Runtime.CompilerServices;

int Filtre1(int v)
{
    if (v < 0)
    {
        return 0;
    }
    return v;
}
// Filtrer les valeurs négatives avec une fonction sans les parenthèses en paramètre de type delegate
int Addition(int a, int b, Func<int, int> f)
{
    a = f(a);
    b = f(b);
    return a + b;
}

Console.WriteLine(Addition(-5, 10, Filtre1));

// Fitrer avec une lambda, valeur > 10 alors vaut 10 sinon renvoie la valeur

Func<int, int> filtre2 = (int v) => v > 10 ? 10 : v;

Console.WriteLine(Addition(20, 10, filtre2));

// CallerArgumentExpression permet de récupérer le nom de l'argument passer en paramètre

int Multiplication(int a, int b, Func<int, int> f,
    [CallerArgumentExpression("f")]string? nom_param = null)
{
    a = f(a);
    b = f(b);
    Console.WriteLine("Fonction de filtrage : " + nom_param);
    return a + b;
}

Console.WriteLine(Multiplication(-2,15,Filtre1));


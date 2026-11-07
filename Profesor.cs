namespace Catalog.Models;

class Profesor : Persoana
{
    public string Materie { get; set; } = "";

    public Profesor(string nume, int varsta, string materie) : base(nume, varsta)
    {
        Materie = materie;
    }

    public override void AfiseazaDetalii()
    {
        Console.WriteLine("Profesorul: " + Nume);
        Console.WriteLine("Varsta: " + Varsta);
        Console.WriteLine("Materie: " + Materie);
    }
}
namespace Catalog.Models;

public class Persoana
{
    public string Nume { get; set; } = "";
    public int Varsta { get; set; }

    public Persoana(string nume, int varsta)
    {
        Nume = nume;
        Varsta = varsta;
    }

    public virtual void AfiseazaDetalii()
    {
        Console.WriteLine("Persoana: " + Nume);
        Console.WriteLine("Varsta: " + Varsta);
    }
}
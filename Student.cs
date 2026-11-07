namespace Catalog.Models;

public class Student : Persoana
{
    private double notaStudentului;

    public Student(string nume, int varsta, double nota) : base(nume, varsta)
    {
        SeteazaNota(nota);
    }

    public override void AfiseazaDetalii()
    {
        Console.WriteLine("\nStudent: " + Nume);
        Console.WriteLine("Varsta: " + Varsta);
        Console.WriteLine("Nota: " + notaStudentului);
        Console.WriteLine("Promovat: " + EstePromovat() + "\n");
    }
    public bool EstePromovat()
    {
        if (notaStudentului >= 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SeteazaNota(double notaNoua)
    {
        if (notaNoua >= 1 && notaNoua <= 10)
        {
            notaStudentului = notaNoua;
        }
    }
    public double ObtineNota()
    {
        return notaStudentului;
    }
}
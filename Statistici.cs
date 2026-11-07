namespace Catalog.Models;

public static class Statistici
{
    public static double CalculeazaMedia(List<Student> studenti)
    {
        if (studenti.Count == 0)
        {
            return 0;
        }
        double media = studenti.Average(student => student.ObtineNota());
        return media;
    }

    public static int NumaraPromovati(List<Student> studenti)
    {
        int nrPromovati = 0;
        if (studenti.Count == 0)
        {
            return 0;
        }
        else
        {
            return nrPromovati = studenti.Count(student => student.EstePromovat());
        }
    }

    public static List<Student> ObtinePromovatiSortati(List<Student> studenti)
    {
        var rezultat = studenti.Where(n => n.EstePromovat()).OrderByDescending(n => n.ObtineNota()).ToList();
        return rezultat;
    }

    public static bool ExistaRestantieri(List<Student> studenti)
    {
        bool exista = studenti.Any(student => !student.EstePromovat());

        return exista;
    }

    public static bool TotiPromovati(List<Student> studenti)
    {
        bool totiProm = studenti.Count > 0 && studenti.All(student => student.EstePromovat());

        return totiProm;
    }

    public static Student? StudentCuNotaMaxima(List<Student> studenti)
    {
        var notaMaxima = studenti.MaxBy(s => s.ObtineNota());

        return notaMaxima;
    }

    public static Student? StudentCuNotaMinima(List<Student> studenti)
    {
        var notaMinima = studenti.MinBy(s => s.ObtineNota());

        return notaMinima;
    }
}
using Catalog.Models;

int optiune = 2;

List<Student> studenti = new List<Student>();

while (optiune != 0)
{
    Console.WriteLine("\n=== CATALOG STUDENTI ===");
    Console.WriteLine("1. Adauga student\n2. Afiseaza toti studentii\n3. Afiseaza studentii promovati\n4. Calculeaza media generala\n5. Cauta student dupa nume\n6. Afiseaza studentul cu cea mai mare nota\n7. Afiseaza studentul cu cea mai mica nota\n8. Modifica nota unui student\n0. Iesire");
    Console.Write("Alege o optiune: ");
    bool optiuneValida = int.TryParse(Console.ReadLine(), out int optiuneCitita);
    if (!optiuneValida || optiuneCitita > 8 || optiuneCitita < 0)
    {
        Console.WriteLine("Optiune invalida!");
        continue;
    }
    else
    {
        optiune = optiuneCitita;
    }
    switch (optiune)
    {
        case 1:
            AdaugaStudent(studenti);
            break;
        case 2:
            AfiseazaStudenti(studenti);
            break;
        case 3:
            if (studenti.Count == 0)
            {
                Console.WriteLine("\nNu exista studenti in lista");
            }
            else
            {
                var listaPromovati = Statistici.ObtinePromovatiSortati(studenti);
                foreach (Student student in listaPromovati)
                {
                    Console.WriteLine(student.Nume + " - Nota: " + student.ObtineNota());
                }

                Console.WriteLine("\nTotalul elevilor promovati este: " + Statistici.NumaraPromovati(studenti));
            }
            break;
        case 4:
            if (studenti.Count == 0)
            {
                Console.WriteLine("\nNu exista studenti in lista");
            }
            else
            {

                Console.WriteLine("Media generala a tuturor studentilor este: " + Statistici.CalculeazaMedia(studenti));
            }
            break;
        case 5:
            CautaStudenti(studenti);
            break;
        case 6:
            var stMax = Statistici.StudentCuNotaMaxima(studenti);

            if (stMax != null)
            {
                stMax.AfiseazaDetalii();
            }
            else
            {
                Console.WriteLine("\nNu exista niciun student introdus in lista!");
            }
            break;
        case 7:
            var stMin = Statistici.StudentCuNotaMinima(studenti);

            if (stMin != null)
            {
                stMin.AfiseazaDetalii();
            }
            else
            {
                Console.WriteLine("\nNu exista niciun student introdus in lista!");
            }
            break;
        case 8:
            if(studenti.Count == 0){
                Console.WriteLine("\nNu exista niciun student introdus in lista!");
            }
            else{
                Console.WriteLine("\nIntrodu numele studentului: ");
                var numeStudentCautat = Console.ReadLine();
                Student? studentGasit = studenti.FirstOrDefault(s => s.Nume == numeStudentCautat);
                if (studentGasit == null)
                {
                    Console.WriteLine("Nu exista niciun student cu acest nume!");
                }
                else
                {
                    Console.WriteLine("Am identificat studentul: " + numeStudentCautat + ", nota acestuia este: " + studentGasit.ObtineNota());
                    Console.WriteLine("Introdu noua nota a acestuia: ");
                    var notaValida = double.TryParse(Console.ReadLine(), out double notaModificata);
                        if (notaValida && notaModificata >= 1 && notaModificata <= 10)
                        {
                            studentGasit.SeteazaNota(notaModificata);
                            Console.WriteLine("Nota studentului " + studentGasit.Nume + " a fost modificata!");
                        }
                        else
                        {
                            Console.WriteLine("Nota invalida!");
                        }
                }
            }
            break;
        case 0:
            Console.WriteLine("La revedere!");
            break;
        default:
            Console.WriteLine("Optiune necunoscuta!");
            break;
    }
}

static void AdaugaStudent(List<Student> studenti)
{
    Console.WriteLine("\nCe nume are studentul? ");
    string nume = Console.ReadLine();

    Console.WriteLine("Care este varsta studentului? ");
    bool rezultat = int.TryParse(Console.ReadLine(), out int varsta);

    while (!rezultat || varsta < 1)
    {
        Console.WriteLine("Varsta nu este valida! Introdu varsta din nou: ");
        rezultat = int.TryParse(Console.ReadLine(), out varsta);
    }

    Console.WriteLine("Ce nota a luat studentul? ");
    rezultat = double.TryParse(Console.ReadLine(), out double nota);

    while (!rezultat || nota < 1 || nota > 10)
    {
        Console.WriteLine("Nota studentului nu este valida! Introdu nota din nou: ");
        rezultat = double.TryParse(Console.ReadLine(), out nota);
    }

    studenti.Add(new Student(nume, varsta, nota));
}

static void AfiseazaStudenti(List<Student> studenti)
{
    if (studenti.Count == 0)
    {
        Console.WriteLine("\nNu exista studenti in lista");
    }
    else
    {
        foreach (Student student in studenti)
        {
            student.AfiseazaDetalii();
        }
    }
}

static void CautaStudenti(List<Student> studenti)
{
    if (studenti.Count == 0)
    {
        Console.WriteLine("\nNu exista studenti in lista");
    }
    else
    {
        Console.WriteLine("Tasteaza numele studentului cautat: ");
        string numeCautat = Console.ReadLine();
        var studentGasit = studenti.FirstOrDefault(s => s.Nume == numeCautat);
        if (studentGasit != null)
        {
            studentGasit.AfiseazaDetalii();
        }
        else
        {
            Console.WriteLine("Nu exista niciun student cu acest nume!");
        }
    }
}
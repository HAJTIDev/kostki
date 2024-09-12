using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        bool zagrajPonownie = true;
        Random random = new Random();

        while (zagrajPonownie)
        {
            int liczbaKostek = PobierzLiczbeKostek();
            List<int> rzutyKostkami = RzucKostkami(liczbaKostek, random);
            WyswietlRzuty(rzutyKostkami);
            int punkty = ObliczPunkty(rzutyKostkami);
            Console.WriteLine($"Punkty: {punkty}");
            zagrajPonownie = CzyZagracPonownie();
        }
    }

    static int PobierzLiczbeKostek()
    {
        int liczbaKostek;
        do
        {
            Console.Write("Podaj liczbę kostek do rzucenia (3-10): ");
        } while (!int.TryParse(Console.ReadLine(), out liczbaKostek) || liczbaKostek < 3 || liczbaKostek > 10);
        return liczbaKostek;
    }

    static List<int> RzucKostkami(int liczbaKostek, Random random)
    {
        List<int> rzutyKostkami = new List<int>();
        for (int i = 0; i < liczbaKostek; i++)
        {
            rzutyKostkami.Add(random.Next(1, 7));
        }
        return rzutyKostkami;
    }

    static void WyswietlRzuty(List<int> rzutyKostkami)
    {
        for (int i = 0; i < rzutyKostkami.Count; i++)
        {
            Console.WriteLine($"Kostka {i + 1}: {rzutyKostkami[i]}");
        }
    }

    static int ObliczPunkty(List<int> rzutyKostkami)
    {
        var pogrupowaneRzuty = rzutyKostkami.GroupBy(x => x)
                                            .Where(g => g.Count() > 1)
                                            .SelectMany(g => g);
        return pogrupowaneRzuty.Sum();
    }

    static bool CzyZagracPonownie()
    {
        Console.Write("Czy chcesz zagrać ponownie? (t/n): ");
        string odpowiedz = Console.ReadLine().ToLower();
        return odpowiedz == "t";
    }
}

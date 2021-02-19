using System.Text;
using System;


namespace Core
{

    public class Calc
    { 

        public static string Policz()
        {
            double wynik = 0;
            double liczba1, liczba2;
            string[] liczby = Phoneword.MainActivity.liczba;

            if (liczby[0] == "")
            {
                liczba1 = 0;
            }
            else if (liczby[0] == "." || liczby[0] == "-." || liczby[0] == "-")
            {
                liczba1 = 0;
            }
            else
            {
                liczba1 = Convert.ToDouble(liczby[0]);
            }


            if (Phoneword.MainActivity.liczba[1] == "")
            {
                liczba2 = 0;
            }
            else if (liczby[1] == "." || liczby[1] == "-." || liczby[1] == "-")
            {
                liczba2 = 0;
            }
            else
            {
                liczba2 = Convert.ToDouble(liczby[1]);
            }


            if (Phoneword.MainActivity.znak == "+")
            {
                wynik = liczba1 + liczba2;
            }
            else if (Phoneword.MainActivity.znak == "-")
            {
                wynik = liczba1 - liczba2;
            }
            else if (Phoneword.MainActivity.znak == "/")
            {
                if(liczba2 != 0)
                {
                    wynik = liczba1 / liczba2;
                }
                else
                {
                    return "Nie można dzielić przez zero";
                }
                   
            }
            else if (Phoneword.MainActivity.znak == "*")
            {
                wynik = liczba1 * liczba2;

            }

            Phoneword.MainActivity.liczba[0] = wynik.ToString();
            Phoneword.MainActivity.liczba[1] = "";
            Phoneword.MainActivity.znak = "";

            if(wynik > 0)
            {
                Phoneword.MainActivity.zmiana = false;
            }
            else
            {
                Phoneword.MainActivity.zmiana = true;
            }

            if(wynik - Math.Truncate(wynik) > 0)
            {
                Phoneword.MainActivity.przecinek_zmienna = true;
            }
            else
            {
                Phoneword.MainActivity.przecinek_zmienna = false;
            }

            return wynik.ToString();
        }

        public static string wynik_drukuj(string temp)
        {
            if (string.IsNullOrWhiteSpace(temp))
            {
                return string.Empty;
            }
            else
            {
                return temp;
            }
        }

        public static string Działanie(string temp)
        {
            Phoneword.MainActivity.przecinek_zmienna = false;
            Phoneword.MainActivity.zmiana = false;
            return temp;
        }

        public static string Liczba(string temp, string[] liczba, string znak)
        {
            string wynik;
            if (znak == "")
            {
                wynik = liczba[0] += temp;
            }
            else
            {
                wynik = liczba[1] += temp;
            }
            return wynik;
        }

        public static string Zmiana_znaku(string[] liczba, string znak, bool znak_zmiana)
        {
            string temp;
            if (znak == "")
            {
               if(znak_zmiana == true)
                {
                    liczba[0] = "-" + liczba[0];
                }
                else
                {
                    liczba[0] = liczba[0].Substring(1);
                }
                temp = liczba[0];
            }
            else
            {
                if (znak_zmiana == true)
                {
                    liczba[1] = "-" + liczba[1];
                }
                else
                {
                    liczba[1] = liczba[0].Substring(1);
                }

                temp = liczba[1];
            }

            return temp;
        }
    }
}
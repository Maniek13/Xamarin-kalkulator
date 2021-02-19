using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Phoneword
{
    [Activity(Label = "Kalkulator", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static string[] liczba = { "", ""};
        public static string znak = "";
        public static bool przecinek_zmienna = false;
        public static bool zmiana = false;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Calc.Resource.Layout.activity_main);

            TextView wynik_field = FindViewById<TextView>(Calc.Resource.Id.wynik_field);
            Button btn0 = FindViewById<Button>(Calc.Resource.Id.btn0);
            Button btn1 = FindViewById<Button>(Calc.Resource.Id.btn1);
            Button btn2 = FindViewById<Button>(Calc.Resource.Id.btn2);
            Button btn3 = FindViewById<Button>(Calc.Resource.Id.btn3);
            Button btn4 = FindViewById<Button>(Calc.Resource.Id.btn4);
            Button btn5 = FindViewById<Button>(Calc.Resource.Id.btn5);
            Button btn6 = FindViewById<Button>(Calc.Resource.Id.btn6);
            Button btn7 = FindViewById<Button>(Calc.Resource.Id.btn7);
            Button btn8 = FindViewById<Button>(Calc.Resource.Id.btn8);
            Button btn9 = FindViewById<Button>(Calc.Resource.Id.btn9);
            Button btnPlus = FindViewById<Button>(Calc.Resource.Id.btnPlus);
            Button btnMinus = FindViewById<Button>(Calc.Resource.Id.btnMinus);
            Button btnRazy = FindViewById<Button>(Calc.Resource.Id.btnRazy);
            Button btnPodzielic = FindViewById<Button>(Calc.Resource.Id.btnPodzielic);
            Button wynik = FindViewById<Button>(Calc.Resource.Id.wynik);
            Button kasuj = FindViewById<Button>(Calc.Resource.Id.btnKasuj);
            Button znak_zmiana = FindViewById<Button>(Calc.Resource.Id.btnZnak);
            Button przecinek = FindViewById<Button>(Calc.Resource.Id.btnPrzecinek);
            Button delete = FindViewById<Button>(Calc.Resource.Id.btndelete);

            wynik_field.Text = "0";


            btn0.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("0", liczba, znak).ToString());
            };

            btn1.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("1", liczba, znak).ToString());
            };

            btn2.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("2", liczba, znak).ToString());
            };

            btn3.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("3", liczba, znak).ToString());
            };

            btn4.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("4", liczba, znak).ToString());
            };

            btn5.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("5", liczba, znak).ToString());
            };

            btn6.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("6", liczba, znak).ToString());
            };

            btn7.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("7", liczba, znak).ToString());
            };

            btn8.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("8", liczba, znak).ToString());
            };

            btn9.Click += (sender, e) =>
            {
                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba("9", liczba, znak).ToString());
            };


            btnPlus.Click += (sender, e) =>
            {
                if (znak == "")
                {
                    znak = Core.Calc.Działanie("+");
                }
                else
                {
                    wynik_field.Text = Wykonaj();
                }
            };

            btnMinus.Click += (sender, e) =>
            {
                if (znak == "")
                {
                    znak = Core.Calc.Działanie("-");
                }
                else
                {
                    wynik_field.Text = Wykonaj();
                }
            };

            btnPodzielic.Click += (sender, e) =>
            {
                if (znak == "")
                {
                    znak = Core.Calc.Działanie("/");
                }
                else
                {
                    wynik_field.Text = Wykonaj();
                }
            };

            btnRazy.Click += (sender, e) =>
            {
                if (znak == "")
                {
                    znak = Core.Calc.Działanie("*");
                }
                else
                {
                    wynik_field.Text = Wykonaj();
                }
            };

            wynik.Click += (sender, e) =>
            {
                wynik_field.Text = Wykonaj();
            };


            kasuj.Click += (sender, e) =>
            {
                liczba[0] = "";
                liczba[1] = "";
                znak = "";
                przecinek_zmienna = false;
                zmiana = false;
                wynik_field.Text = "0";
            };

            znak_zmiana.Click += (sender, e) =>
            {
                if(zmiana == false)
                {
                    zmiana = true;
                }
                else
                {
                    zmiana = false;
                }

                wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Zmiana_znaku(liczba, znak, zmiana).ToString());
            };

            przecinek.Click += (sender, e) =>
            {
                if(przecinek_zmienna == false)
                {
                    wynik_field.Text = Core.Calc.Wynik_drukuj(Core.Calc.Liczba(".", liczba, znak).ToString());
                    przecinek_zmienna = true;
                }
            };

            delete.Click += (sender, e) =>
            {
                if (znak == "")
                {
                    if(liczba[0].Length > 0)
                    {
                        liczba[0] = liczba[0][0..^1];
                        wynik_field.Text = liczba[0];
                    }
                    if(liczba[0].Length == 0 && zmiana == true)
                    {
                        zmiana = false;
                    }
                }
                else
                {
                    if(liczba[1].Length > 0)
                    {
                        liczba[1] = liczba[1][0..^1];
                        wynik_field.Text = liczba[1];
                    }
                    if (liczba[1].Length == 0 && zmiana == true)
                    {
                        zmiana = false;
                    }
                }
            };
        }

        private static string Wykonaj()
        {
            string temp = Core.Calc.Policz();
            return Core.Calc.Wynik_drukuj(temp);
        }
    }
}
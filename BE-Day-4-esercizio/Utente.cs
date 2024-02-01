using System;
using System.Collections.Generic;

/*TRACCIA DELL'ESERCIZIO:
Creare una console application che riproponga un menu come quello proposto di seguito:
===============OPERAZIONI==============
Scegli l'operazione da effettuare:
1.: Login
2.: Logout
3.: Verifica ora e data di login
4.: Lista degli accessi
5.: Esci
========================================
L'esercizio deve poter simulare l'attività di login di un utente, ed in particolare:
- L'operazione di login deve richiedere una username, una password ed una conferma password. Solo se la username è stata inserita e le password coincidono, l'utente verrà autenticato,
- L'operazione di logout deve consentire di dimenticare l'utente autenticato. Se si richiede il logout quando un utente non è loggato, il sistema deve riproporre un messaggio di errore,
- L'operazione di verifica deve riportare la data e l'ora di quando è stato effettuato il login dell'utente. Nel caso in cui venisse richiamato il metodo ma nessun utente risulta autenticato, il sistema deve riproporre un messaggio di errore.
- La lista degli accessi deve riportare la lista storica dei login dell'utente.

*/
namespace BE_Day_4_esercizio
{
    internal static class Utente
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static bool IsLoggedIn { get; set; }
        public static List<DateTime> LoginDate { get; set; } = new List<DateTime>();
        public static DateTime LastLoginTime { get; private set; }


        public static void Menu()
        {

            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Logout();
                    break;
                case "3":
                    CheckLogin();
                    break;
                case "4":
                    LoginList();
                    break;
                case "5":
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    Menu();
                    break;
            }
        }

        public static void Login()
        {
            Console.WriteLine("Inserisci username:");
            Username = Console.ReadLine();
            Console.WriteLine("Inserisci password:");
            Password = Console.ReadLine();
            Console.WriteLine("Conferma password:");
            string confirmPassword = Console.ReadLine();
            if (Username != null && Password == confirmPassword)
            {
                IsLoggedIn = true;
                LastLoginTime = DateTime.Now;
                LoginDate.Add(LastLoginTime);
                Console.WriteLine("Login effettuato con successo!");
            }
            else
            {
                Console.WriteLine("Login fallito!");
            }
            Menu();
        }
        public static void Logout()
        {
            if (IsLoggedIn)
            {
                IsLoggedIn = false;
                Console.WriteLine("Logout effettuato con successo!");
            }
            else
            {
                Console.WriteLine("Logout fallito!");
            }
            Menu();
        }
        public static void CheckLogin()
        {
            if (IsLoggedIn)
            {
                Console.WriteLine($"Ultimo login effettuato  il {LastLoginTime}");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato!");
            }
            Menu();
        }
        public static void LoginList()
        {
            if (IsLoggedIn)
            {
                foreach (var item in LoginDate)
                {
                    Console.WriteLine($"Login effettuato il {item}");
                }
            }
            else
            {
                Console.WriteLine("Nessun utente loggato!");
            }
            Menu();
        }





    }

}

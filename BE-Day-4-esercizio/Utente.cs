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
        public static List<(string, string)> UserList { get; set; } = new List<(string, string)>();
        public static List<string> LoginDate { get; set; } = new List<string>();
        public static DateTime LastLoginTime { get; set; }

        // Menu () Genera un menu con le operazioni disponibili e richiama il metodo corrispondente alla scelta dell'utente 
        public static void Menu()
        {

            Console.WriteLine("\n===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================\n");
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
        /*
         * Login () Chiede all'utente di inserire username e password e verifica se l'utente è già registrato,
         * se non lo è lo registra e lo logga, se lo è controlla che la password inserita sia corretta e lo logga
         */
        public static void Login()
        {   // Chiede all'utente di inserire username e password
            Console.WriteLine("Inserisci username:");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Inserisci password:");
            string inputPassword = Console.ReadLine();
            Console.WriteLine("Conferma password:");
            string confirmPassword = Console.ReadLine();

            // Verifica che username e password non siano nulli e che la password sia uguale alla conferma password
            if (inputUsername != null && inputPassword != null && inputPassword == confirmPassword)
            {
                // Cerca l'utente nella lista
                var user = UserList.Find(u => u.Item1 == inputUsername);

                // Verifica se l'utente è già registrato
                if (user.Item1 != null && user.Item2 != null)
                {
                    /* 
                     * Verifica che la password inserita sia corretta
                     * e se la password è corretta logga l'utente
                    */
                    if (user.Item2 == inputPassword)
                    {
                        //Setta gli stati IsLoggedIn e Date
                        SetLogin(inputUsername, inputPassword);
                        Console.WriteLine("\nLogin effettuato con successo!");
                    }
                    else
                    {
                        Console.WriteLine("\nPassword errata!");
                    }
                }
                // Se l'utente non è registrato lo registra e lo logga
                else
                {
                    UserList.Add((inputUsername, inputPassword));
                    SetLogin(inputUsername, inputPassword);
                    Console.WriteLine("\nUtente creato e login effettuato con successo!");
                }
            }
            else
            {
                Console.WriteLine("\nLogin fallito!");
            }
            Menu();
        }


        // setLogin () Setta gli stati IsLoggedIn e Date e aggiunge l'accesso alla lista degli accessi
        public static void SetLogin(string inputUsername, string inputPassword)
        {
            Username = inputUsername;
            Password = inputPassword;
            IsLoggedIn = true;
            LastLoginTime = DateTime.Now;
            string lastLoginTime = LastLoginTime.ToString();
            LoginDate.Add($"\nL'utente {inputUsername} ha effettuato il login : {lastLoginTime}");
        }

        // Logout () Effettua il logout dell'utente
        public static void Logout()
        {
            if (IsLoggedIn)
            {
                IsLoggedIn = false;
                Console.WriteLine("\nLogout effettuato con successo!");
            }
            else
            {
                Console.WriteLine("\nLogout fallito!");
            }
            Menu();
        }



        // CheckLogin () Verifica se l'utente è loggato e in caso affermativo stampa la data e l'ora dell'ultimo login
        public static void CheckLogin()
        {
            if (IsLoggedIn)
            {
                Console.WriteLine($"\nUltimo login effettuato  il {LastLoginTime}");
            }
            else
            {
                Console.WriteLine("\nNon sei loggato!");
            }
            Menu();
        }



        // LoginList () Stampa la lista degli accessi
        public static void LoginList()
        {
            if (IsLoggedIn)
            {
                foreach (var item in LoginDate)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine("\nNessun utente loggato!");
            }
            Menu();
        }
    }
}

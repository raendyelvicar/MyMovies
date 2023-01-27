using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    internal class MainService
    {

        MovieService MovieServices = new MovieService();

        public MainService()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            List<string> Menu = new List<string> { "Daftar Movies", "Tambah Movie", "Exit" };
            int idx = 0;
            Console.WriteLine("Silakan pilih menu dibawah ini:");
            foreach (var data in Menu)
            {
                Console.WriteLine(++idx + ". " + data);
            }
            Console.Write("\nPilih menu: ");
            int choosen = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                HandleInputUser(choosen);
            }

        }

        public void HandleInputUser(int choosen)
        {
            bool HasDone = false;
            switch (choosen)
            {
                case 1:
                    HasDone = MovieServices.DisplayMovies();
                    break;
                case 2:
                    HasDone = MovieServices.AddNewMovie();
                    break;
                case 3:
                    Console.WriteLine("Terimakasih telah menggunakan program kami.");
                    ExitVerification();
                    break;
                default:
                    Console.WriteLine("Input tidak ditemukan. Silakan ulangi lagi.");
                    break;
            }

            if (HasDone)
            {
                ExitVerification();
            } else
            {
                RunMenu();
            }
        }

        public void ExitVerification()
        {
            Console.WriteLine("Yakin untuk exit program?");
            Console.WriteLine("Ketik 'stop' untuk keluar program");
            Console.WriteLine("Ketik 'enter' untuk memilih ulang");
            string answer = Console.ReadLine();

            if(answer.ToUpper() == "STOP")
            {
                ExitMenu();
            } else if(answer.ToUpper() == "ENTER")
            {
                RunMenu();
            } else
            {
                Console.WriteLine("Input tidak ditemukan. Silakan ulangi lagi.");
                ExitVerification();
            }

        }
        public void ExitMenu()
        {
            Console.WriteLine("Yakin exit program? Y/N");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                Console.WriteLine("Exit menu. Bye bye!");
                Environment.Exit(1);
            }
            else if (answer.ToUpper() == "N")
            {
                RunMenu();
            }
           
        }
    }
}

using MyMovies.Interfaces;
using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    internal class MovieService : IMovie
    {
        List<Movie> Movies= new List<Movie>();
        public bool AddNewMovie()
        {
            Console.Write("{0, -15}: ", "No. Movie");
            int NoMovie = Convert.ToInt32(Console.ReadLine());

            Console.Write("{0, -15}: ", "Judul Movie");
            string? JudulMovie = Console.ReadLine();

            Console.Write("{0, -15}: ", "Rating Awal");
            decimal RatingAwal = Convert.ToDecimal(Console.ReadLine());

            Movie movie = new Movie();
            movie.No = NoMovie;
            movie.Judul = JudulMovie;
            movie.Rating = RatingAwal;

            Movies.Add(movie);

            Console.WriteLine("Movie berhasil ditambahkan!");
            Console.WriteLine("Lanjutkan tambah movie? N/Y");
            string? answer = Console.ReadLine();

            if(answer.ToUpper() == "Y")
            {
                AddNewMovie();
            } else if(answer.ToUpper() == "N")
            {
                return true;
            }

            return false;
        }

        public bool GiveMovieRating()
        {
            Console.WriteLine("Pilih nomor movie yang ingin di vote: ");
            int No = Convert.ToInt32(Console.ReadLine());
            
            Movie FindMovie = FindMovieByNo(No);
            if (FindMovie != null)
            {
                Console.WriteLine("Movie ditemukan!");
                Console.WriteLine("{0, -8} : {1}", "Judul", FindMovie.Judul);
                Console.WriteLine("{0, -8} : {1}", "Rating Sekarang", FindMovie.Rating);
                Console.WriteLine("Yakin ingin vote movie " + FindMovie.Judul + "? Y/N");
                string answer = Console.ReadLine();

                if(answer.ToUpper() == "Y")
                {
                    FindMovie.Rating += (decimal)0.1;
                    Console.WriteLine($"Terimakasih sudah melakukan vote, kini rating movies dengan judul {FindMovie.Judul} telah ditambahkan sebanyak 0.1");
                    DisplayMovies();
                } 
            }
            else
            {
                Console.WriteLine("Movie tidak ditemukan!");
                Console.WriteLine("Silakan input nomor movie yang tersedia.");
                GiveMovieRating();
            }
            return true;
        }

        public bool DisplayMovies()
        {
            if(Movies?.Any() == false) {
                Console.WriteLine("Movies belum tersedia. Silakan tambah movies.\n");
                return false;
            } else
            {
                Console.WriteLine("Daftar Movie: ");

                foreach (var data in Movies.OrderByDescending( movie => movie.Rating))
                {
                    Console.WriteLine("{0}. {1} - Rating {2}", data.No, data.Judul, data.Rating);
                }

                Console.WriteLine("Vote Movie? N/Y");
                string answer = Console.ReadLine();

                if(answer.ToUpper() == "Y")
                {
                    GiveMovieRating();
                } else
                {
                    return false;
                }
            }

            return true;
        }

        public Movie FindMovieByNo(int No)
        {
            Movie query = Movies.FirstOrDefault(movie => movie.No == No);

            return query;
        }
    }
}

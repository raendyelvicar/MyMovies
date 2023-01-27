using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Interfaces
{
    internal interface IMovie
    {

        bool AddNewMovie();

        bool GiveMovieRating();

        bool DisplayMovies();
    }
}

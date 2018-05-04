using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace 影院售票系统
{
    [Serializable]
    /// <summary>
    /// 电影类
    /// </summary>
    public class Movie
    {
        public string Actor { get; set; }
        public string Director { get; set; }
        public string MovieName { get; set; }
        public MovieType MovieType { get; set; }
        public string Poster { get; set; }//海报
        public int Price { get; set; }

        public Movie(){}

        public Movie(string actor, string director, string movieName, MovieType movieType, string poster, int price)
        {
            this.Actor = actor;
            this.Director = director;
            this.MovieName = movieName;
            this.MovieType = movieType;
            this.Poster = poster;
            this.Price = price;
        }
    }
}

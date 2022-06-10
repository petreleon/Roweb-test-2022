using System;
using System.ComponentModel.DataAnnotations;
namespace Roweb_test.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Creator { get; set; }
        public decimal Price { get; set; }
    }
}
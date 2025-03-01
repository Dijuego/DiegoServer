using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DiegoServer.Dtos
{
    public class CityCountry
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Population { get; set; }

        public string countryName { get; set; } = null!;
    }
}

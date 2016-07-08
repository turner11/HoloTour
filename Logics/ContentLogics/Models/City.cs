using HoloTour.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.ContentLogics.Models
{
    public class City : IIdAndTitleObject
    {
        public int Id { get; }

        public string Title { get; }
        public Country Country { get; }

        public City(int id, string title, Country country)
        {
            this.Id = id;
            this.Title = title;
            this.Country = country;
        }
    }
}

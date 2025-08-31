using CarBook.Domain.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entites
{
    public class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public int Km { get; set; }
        public TransmissionType Transmission { get; set; }
        public byte Seat { get; set; }
        public string Luggage { get; set; }
        public FuelType Fuel { get; set; }


        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions{ get; set; }
        public List<CarPricing> CarPricings{ get; set; }


    }
}

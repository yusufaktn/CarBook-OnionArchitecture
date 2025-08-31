using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entites
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name{ get; set; }

        public List<Car> Cars { get; set; }
    }
}

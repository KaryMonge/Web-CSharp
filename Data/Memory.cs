using Microsoft.Extensions.Caching.Memory;
using Proyecto1_web.Models;

namespace Proyecto1_web.Data
{

    public class Memory
    {


        private readonly IMemoryCache _cache_memory;


        public Memory(IMemoryCache cache_memory)
        {


            _cache_memory = cache_memory;


        }


        public static List<Person> persons = new List<Person>();




        public static List<Product> products = new List<Product>();







        public static List<Supplier> suppliers = new List<Supplier>();








        public static List<Tour> tours = new List<Tour>(); 












    }
}

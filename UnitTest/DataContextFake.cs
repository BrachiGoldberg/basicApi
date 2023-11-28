using BasicAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class DataContextFake : IDataContext
    {
        public List<Event> Events { get; set; }
        public DataContextFake()
        {
            Events = new List<Event>();
            Events.Add(new Event() { Id = 1, Title = "example1", Start = new DateTime(2023, 09, 07) });
            Events.Add(new Event() { Id = 2, Title = "example2", Start = new DateTime(2023, 09, 08) });
            Events.Add(new Event() { Id = 3, Title = "example3", Start = new DateTime(2023, 09, 09) });
        }
    }
}

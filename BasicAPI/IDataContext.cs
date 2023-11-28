using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAPI
{
    public interface IDataContext
    {
        public List<Event> Events { get; set; }
    }
}

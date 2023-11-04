using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event>()
        {
            new Event() { Id=1,Title="example1",Start=new DateTime(2023,09,07)},
            new Event() { Id=2,Title="example2",Start=new DateTime(2023,09,08)},
            new Event() { Id=3,Title="example3",Start=new DateTime(2023,09,09)},
        };

       static  int counterEvents = 3;
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }


        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event myEvent)
        {
            events.Add(new Event() { Id=++counterEvents ,Title=myEvent.Title,Start=myEvent.Start,End=myEvent.End});
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event myEvent)
        {
            var e = events.Find(event_ => event_.Id == id);
            if (e != null)
            {
                e.Title = myEvent.Title;
                e.Start = myEvent.Start;
                e.End = myEvent.End;
            }

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var e=events.Find(event_=>event_.Id==id);
            if(e!=null)
                events.Remove(e);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IDataContext _data;
        static  int counterEvents = 3;

        public EventsController(IDataContext data)
        {
            _data = data;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _data.Events;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var eve = _data.Events.Find(x => x.Id == id);
            if (eve != null)
                return Ok(eve);
            return NotFound();
        }
        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event myEvent)
        {
            _data.Events.Add(new Event() { Id=++counterEvents ,Title=myEvent.Title,Start=myEvent.Start,End=myEvent.End});
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event myEvent)
        {
            var e = _data.Events.Find(event_ => event_.Id == id);
            if (e != null)
            {
                e.Title = myEvent.Title;
                e.Start = myEvent.Start;
                e.End = myEvent.End;
                return Ok(e);
            }
            return NotFound();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var e= _data.Events.Find(event_=>event_.Id==id);
            if (e != null)
            {
                _data.Events.Remove(e);
                return Ok();
            }
            return NotFound();
        }
    }
}

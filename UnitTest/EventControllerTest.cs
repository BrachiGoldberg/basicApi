using BasicAPI;
using BasicAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class EventControllerTest
    {
        EventsController controller;
        public EventControllerTest()
        {
            IDataContext data = new DataContextFake();
            controller = new EventsController(data);
        }

        [Fact]
        public void Get_OkResult()
        {
            int id = 1;

            var item = controller.Get(id);

            Assert.IsType<OkObjectResult>(item);
        }

        [Fact]
        public void Put_NotFoundResult()
        {
            int id = 10;
            Event eve = new Event();
            var item = controller.Put(id, eve);
            Assert.IsType<NotFoundResult>(item);
        }

        [Fact]
        public void Delete_OkResult()
        {
            int id = 1;
            var item = controller.Delete(id);
            Assert.IsType<OkResult>(item);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DealForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            TimeSpan interval = new TimeSpan(01, 00, 0);
            TimeSpan beginTime = new TimeSpan(00, 00, 00);
            TimeSpan endTime = new TimeSpan(23, 59, 59);

            List<string> list = new List<string>();
            for (TimeSpan tsLoop = beginTime; tsLoop < endTime; tsLoop = tsLoop.Add(interval))
            {
                int StartingHour = tsLoop.Hours;
                //int StartingMinute = 0;
                int EndingHour = tsLoop.Hours;
                //int EndingMinute = 59;
                string StartingHourStr = StartingHour < 12 ? StartingHour.ToString().PadLeft(2, '0') : StartingHour.ToString();
                string EndingHourStr = EndingHour < 12 ? EndingHour.ToString().PadLeft(2, '0') : EndingHour.ToString();
                string StartingMinuteStr = 00.ToString().PadLeft(2, '0');
                string EndingMinuteStr = 59.ToString().PadLeft(2, '0');
                string DisplayHeader = $"{StartingHourStr}{StartingMinuteStr}-{EndingHourStr}{EndingMinuteStr}";
                
                list.Add(DisplayHeader);

                //list.Add(new DateTimeTest()
                //{
                //    StartingHour = tsLoop.Hours,
                //    EndingHour = tsLoop.Hours,
                //    StartingMinute = 0,
                //    EndingMinute = 59
                //});
            }
            return new string[] { "value1", "value2" };
        }


        public class DateTimeTest
        {
            public int StartingHour { get; set; }
            public int StartingMinute { get; set; }
            public int EndingHour { get; set; }
            public int EndingMinute { get; set; }
            
            public string StartingHourStr => StartingHour < 12 ? StartingHour.ToString().PadLeft(2, '0') : StartingHour.ToString();
            public string EndingHourStr => EndingHour < 12 ? EndingHour.ToString().PadLeft(2, '0') : EndingHour.ToString();
            public string StartingMinuteStr => 00.ToString().PadLeft(2, '0');
            public string EndingMinuteStr => 59.ToString().PadLeft(2, '0');
            public string DisplayHeader => $"{StartingHourStr}{StartingMinuteStr}-{EndingHourStr}{EndingMinuteStr}";
        }


        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

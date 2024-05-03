using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPR17
{
    public class Airplanes
    {
       public int airplane_id {  get; set; }
       public string airplane_name { get; set; }
       public string date_of_issue { get; set; }
       public int capacity { get; set; }
       public string last_tech_service { get; set; }
       public int flight_hours { get; set; }
    }
}

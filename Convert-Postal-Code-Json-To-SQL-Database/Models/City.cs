using System;
using System.Collections.Generic;
using System.Text;

namespace Convert_Postal_Code_Json_To_SQL_Database.Models
{
    class City
    {
        public string CityName { get; set; }
        public string CityEngName { get; set; }
        public List<Area> AreaList { get; set; }
    }
}

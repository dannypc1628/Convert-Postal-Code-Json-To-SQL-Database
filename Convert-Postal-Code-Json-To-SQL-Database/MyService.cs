using System;
using System.Collections.Generic;
using System.Text.Json;
using Convert_Postal_Code_Json_To_SQL_Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Convert_Postal_Code_Json_To_SQL_Database
{
    class MyService
    {
        private readonly DbContext _db;
        private readonly string _data;
        private int _i;
        public MyService(string data)
        {
            _data = data;
            _db = new PostalCodeContext();
        }

        public void Start()
        {
            Console.WriteLine("Start~~~");
            JsonDecode(_data);
            Console.WriteLine("Finished~~~");

        }
        private void JsonDecode(string dataString)
        {
            var list = JsonSerializer.Deserialize<List<City>>(dataString);

            _i = 1;
            foreach (var cityItem in list)
            {
                ToDatabase(cityItem);
            }
        }

        private void ToDatabase(City item)
        {
            int cityId = _i;
            Postal cityPostal = NewPostal(cityId, item.CityName, item.CityEngName, "", cityId);
            _db.Add(cityPostal);
            _i++;

            foreach (var area in item.AreaList)
            {
                _db.Add(NewPostal(_i, area.AreaName, area.AreaEngName, area.ZipCode, cityId));
                _i++;
            }

            _db.SaveChanges();
        }

        private Postal NewPostal(int id, string name, string engName, string code, int parentId)
        {
            return new Postal
            {
                Id = id,
                Name = name,
                EnglishName = engName,
                Code = code,
                ParentId = parentId
            };
        }
    }
}

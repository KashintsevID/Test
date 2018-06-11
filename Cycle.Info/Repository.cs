using Cycle.Info.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle.Info
{
    public class Repository
    {
        //public List<Station> Stations { get; set; }
        //public List<User> Users { get; set; }
        //public List<Bicycle> Bicycles { get; set; }
        //public Repository()
        //{
        //    Restore();
        //}

        //public Repository(User user)
        //{
        //    Restore();
        //    if (Users == null)
        //    {
        //        List<User> Users = new List<User>() { new User("", "", "", 0) };
        //    }

        //    Users.Add(user);
        //    Save();

        //}


        //List<T> RestoreList<T>(string fileName)
        //{
        //    using (var sr = new StreamReader(fileName))
        //    {
        //        using (var jsonReader = new JsonTextReader(sr))
        //        {
        //            var serializer = new JsonSerializer();
        //            return serializer.Deserialize<List<T>>(jsonReader);
        //        }
        //    }
        //}
        //void Restore()
        //{
        //    Stations = RestoreList<Station>("stations.json");
        //    Bicycles = RestoreList<Bicycle>("bicycle.json");
        //    Users = RestoreList<User>("users.json");

        //}


        //void SaveList<T>(string filename, List<T> list)
        //{
        //    using (var sw = new StreamWriter(filename))
        //    {
        //        using (var jsonWriter = new JsonTextWriter(sw))
        //        {
        //            jsonWriter.Formatting = Formatting.Indented;

        //            var serializer = new JsonSerializer();
        //            serializer.Serialize(jsonWriter, list);
        //        }

        //    }
        //}
        //public void Save()
        //{
        //    //  SaveList("stations.json", Stations);
        //    //  SaveList("bicycle.json", Bicycles);
        //    SaveList("users.json", Users);
        //}
    }
}

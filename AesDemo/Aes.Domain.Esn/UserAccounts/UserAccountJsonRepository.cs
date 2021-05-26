using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aes.Data.Esn.UserAccounts;
using Newtonsoft.Json;

namespace Aes.Domain.Esn.UserAccounts
{
    public class UserAccountJsonRepository:IUserAccountRepository
    {
       // private string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JukeboxV2.0\JukeboxV2.0\Datos\ich will.mp3")
        private string _userFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"TestJson\UserAccount.json");
        public UserAccount Get(int id)
        {

            var data = Create(_userFile);
            return data.FirstOrDefault(d=>d.UserAccountId==id);
        }

        public List<UserAccount> GetAll()
        {
            var data = Create(_userFile);
            return data;
        }

        public void Add(UserAccount obj)
        {
            var items = Create(_userFile);
            obj.UserAccountId = 1;

            //get last id
            if (items.Any())
                obj.UserAccountId = items.OrderBy(m => m.UserAccountId).Last().UserAccountId + 1;

            items.Add(obj);
            SaveJsonToFile(items, _userFile);
        }

        public void Update(UserAccount obj)
        {
            //delete, then add
            Delete(obj.UserAccountId);
            var items = Create(_userFile);
            items.Add(obj);
            SaveJsonToFile(items.OrderBy(i=>i.UserAccountId), _userFile);
        }

        public void Delete(int id)
        {
            var oldItems = Create(_userFile);
            var items = oldItems.Where(i => i.UserAccountId != id).ToList();
            SaveJsonToFile(items, _userFile);
        }


        private List<UserAccount> Create(string file)
        {
            var json = string.Empty;
            using (StreamReader sr = File.OpenText(file))
            {
                json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<UserAccount>>(json) ?? new List<UserAccount>();
            }
        }


        public void SaveJsonToFile(object obj, string file)
        {
            using (FileStream fs = File.Open(file, FileMode.Truncate))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, obj);
            }
        }

    }
}

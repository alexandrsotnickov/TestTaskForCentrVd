using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrvd.NameProgram.AddCallersPlugin
{
    public class JsonCallers 
    {

        
        [JsonProperty("users")]
        public List<Users> users = new List<Users>();
        public class Users
        {
            public Users(string FirstName, string LastName, string Phone)
            {
                firstName = FirstName;
                lastName = LastName;
                phone = Phone;
            }
            [JsonProperty("firstName")]
            public string firstName = null;

            [JsonProperty("lastName")]
            public string lastName = null;

            [JsonProperty("phone")]
            public string phone = null;
        }


    }

}


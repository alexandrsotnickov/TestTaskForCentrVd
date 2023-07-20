using Newtonsoft.Json;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrvd.NameProgram.AddCallersPlugin
{
    [Author(Name = "Alexandr Sotnikov")]
    public class Plugin : IPluggable
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
         
            logger.Info("Start importing from a file...");

            var employeesList = args.Cast<EmployeesDTO>().ToList();
            
            StringBuilder name = new StringBuilder();

            string jsonContent = File.ReadAllText("users.json");
            JsonCallers jsonCallers = JsonConvert.DeserializeObject<JsonCallers>(jsonContent);
            foreach (JsonCallers.Users jsonUsers in jsonCallers.users)
            {
                EmployeesDTO employeesDTO = new EmployeesDTO();

                name.Append(jsonUsers.firstName);
                name.Append(" ");
                name.Append(jsonUsers.lastName);

                employeesDTO.Name = name.ToString();
                employeesDTO.AddPhone(jsonUsers.phone);
                employeesList.Add(employeesDTO);

                name.Clear();
            }
            logger.Info($"The import was successful! Added {jsonCallers.users.Count()} entries");

            Console.WriteLine("");

            return employeesList.Cast<DataTransferObject>();

        }
    }
}

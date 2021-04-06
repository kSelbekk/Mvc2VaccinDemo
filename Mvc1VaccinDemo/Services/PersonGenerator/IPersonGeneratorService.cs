using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mvc1VaccinDemo.Services.PersonGenerator
{
    public class GeneratedPerson
    {
        public string Name { get; set; }
        public string PersonalNumber { get; set; }
        public string EmailAddress { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
    }

    public class FakeNamePerson
    {
        public string Name { get; set; }
        public string Birth_data { get; set; }
        public string Email_u { get; set; }
        public string Email_d { get; set; }
        public string Address { get; set; }

        public string GeneratePersonalNumber(string Birth_date)
        {
            return Birth_date.Substring(0, 4) + Birth_date.Substring(5, 2) + Birth_date.Substring(8, 2) + "-1111";
        }
    }

    public interface IPersonGeneratorService
    {
        GeneratedPerson GenerateFakePerson();
    }

    internal class PersonGeneratorService : IPersonGeneratorService
    {
        public GeneratedPerson GenerateFakePerson()
        {
            var client = new HttpClient();
            var result = client.GetStringAsync("https://api.namefake.com/swedish-sweden/random/").Result;
            var p = JsonConvert.DeserializeObject<FakeNamePerson>(result);
            return new GeneratedPerson
            {
                Name = p.Name,
                EmailAddress = p.Email_u + "@" + p.Email_d,
                PersonalNumber = p.GeneratePersonalNumber(p.Birth_data),
                City = p.Address.Split('\n')[1].Substring(7),
                PostalCode = Convert.ToInt32(p.Address.Split('\n')[1].Substring(0, 6).Replace(" ", "")),
                StreetAddress = p.Address.Split('\n')[0]
            };
        }
    }
}
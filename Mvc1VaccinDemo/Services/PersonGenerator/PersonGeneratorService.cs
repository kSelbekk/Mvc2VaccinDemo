using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Mvc1VaccinDemo.Services.PersonGenerator
{
    public class PersonGeneratorService : IPersonGeneratorService
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
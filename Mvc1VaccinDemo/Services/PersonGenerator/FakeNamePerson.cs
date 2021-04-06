namespace Mvc1VaccinDemo.Services.PersonGenerator
{
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
}
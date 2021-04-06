using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc1VaccinDemo.Services.PersonGenerator
{
    public interface IPersonGeneratorService
    {
        GeneratedPerson GenerateFakePerson();
    }
}
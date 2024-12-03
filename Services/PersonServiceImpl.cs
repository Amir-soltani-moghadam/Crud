using Crud;
using Grpc.Core;
using Crud;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PersonServiceImpl : PersonService.PersonServiceBase
{
    private readonly List<Person> _persons = new List<Person>();

    public override Task<PersonsResponse> GetAllPersons(GetAllPersonsRequest request, ServerCallContext context)
    {
        var response = new PersonsResponse();
        response.Persons.AddRange(_persons);
        return Task.FromResult(response);
    }

    public override Task<PersonResponse> GetPersonById(GetPersonByIdRequest request, ServerCallContext context)
    {
        var person = _persons.FirstOrDefault(p => p.Id == request.Id);
        return Task.FromResult(new PersonResponse { Person = person });
    }

    public override Task<PersonResponse> CreatePerson(CreatePersonRequest request, ServerCallContext context)
    {
        var person = request.Person;
        _persons.Add(person);
        return Task.FromResult(new PersonResponse { Person = person });
    }

    public override Task<PersonResponse> UpdatePerson(UpdatePersonRequest request, ServerCallContext context)
    {
        var updatedPerson = request.Person;
        var existingPerson = _persons.FirstOrDefault(p => p.Id == updatedPerson.Id);
        if (existingPerson != null)
        {
            existingPerson.Name = updatedPerson.Name;
            existingPerson.Lastname = updatedPerson.Lastname;
            existingPerson.NationalCode = updatedPerson.NationalCode;
            existingPerson.BirthDate = updatedPerson.BirthDate;
        }
        return Task.FromResult(new PersonResponse { Person = existingPerson });
    }

    public override Task<PersonResponse> DeletePerson(DeletePersonRequest request, ServerCallContext context)
    {
        var person = _persons.FirstOrDefault(p => p.Id == request.Id);
        if (person != null)
        {
            _persons.Remove(person);
        }
        return Task.FromResult(new PersonResponse { Person = person });
    }
}

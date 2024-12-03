using Grpc.Net.Client;
using Grpc.Net.Client;
using Crud;
using System;
using System.Threading.Tasks;
namespace Crud.Services
{
    public class GrpcClient
    {
        public static async Task Main(string[] args)
        {
            //var channel = GrpcChannel.ForAddress("http://localhost:5002");
            //var client = new PersonService.PersonServiceClient(channel);
            //
            //// ارسال درخواست برای دریافت تمام افراد
            //var response = await client.GetAllPersonsAsync(new GetAllPersonsRequest());
            //foreach (var person in response.Persons)
            //{
            //    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Lastname: {person.Lastname}");
            //}
            //
            //// ارسال درخواست برای اضافه کردن فرد جدید
            //var newPerson = new Person
            //{
            //    Id = 1,
            //    Name = "John",
            //    Lastname = "Doe",
            //    NationalCode = "1234567890",
            //    BirthDate = "1990-01-01"
            //};
            //
            //var createResponse = await client.CreatePersonAsync(new CreatePersonRequest { Person = newPerson });
            //Console.WriteLine($"Created Person: {createResponse.Person.Name}");
        }
    }
}

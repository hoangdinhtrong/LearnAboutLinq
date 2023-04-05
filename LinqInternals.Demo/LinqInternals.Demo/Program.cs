using LinqInternals.Demo.Extensions;
using LinqInternals.Demo.Models;

namespace LinqInternals.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer[]? customers = new[]
            {
                new Customer()
                {
                    Name = "Foo",
                    Phones = new[]
                    {
                        new Phone(){ Number = "123", PhoneType = PhoneType.Home },
                        new Phone(){ Number = "456", PhoneType = PhoneType.Cell },
                    }
                },
                new Customer()
                {
                    Name = "Foo 2",
                    Phones = new[]
                    {
                        new Phone(){ Number = "345-345-3456", PhoneType = PhoneType.Cell},
                        new Phone(){ Number = "456-678-5678", PhoneType = PhoneType.Home},
                    }
                }
            };
            ExampleSelectManyLinq(customers);
        }

        private static void ExampleSelectLinq(IEnumerable<Customer> customers)
        {

            if (customers != null && customers.Count() > 0)
            {
                var customerNames = customers.NewSelect(x => x.Name);
                foreach (var name in customerNames)
                {
                    Console.WriteLine(name);
                }
            }
        }

        private static void ExampleSelectManyLinq(IEnumerable<Customer> customers)
        {

            if (customers != null && customers.Count() > 0)
            {
                var phones = customers.NewManySelect(x =>x.Phones);
                foreach (var item in phones)
                {
                    Console.WriteLine($"{item.Number} {item.PhoneType}");
                }
            }
        }

        private static void ExampleWhereLinq()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenItems = items.NewWhere(x => x % 2 == 0);

            foreach (var item in evenItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
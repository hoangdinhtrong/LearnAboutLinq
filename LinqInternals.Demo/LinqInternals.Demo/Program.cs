﻿using LinqInternals.Demo.Extensions;
using LinqInternals.Demo.Models;
using LinqInternals.Demo.Services;
using System.Reflection;

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
                    Id = 1,
                    Name = "Foo",
                    Phones = new[]
                    {
                        new Phone(){ Number = "123", PhoneType = PhoneType.Home },
                        new Phone(){ Number = "456", PhoneType = PhoneType.Cell },
                    }
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Foo 2",
                    Phones = new[]
                    {
                        new Phone(){ Number = "345-345-3456", PhoneType = PhoneType.Cell},
                        new Phone(){ Number = "456-678-5678", PhoneType = PhoneType.Home},
                    }
                }
            };

            //// Dispose
            //using (ServiceProxy serviceProxy = new ServiceProxy(null!))
            //{
            //    serviceProxy.Get();

            //    serviceProxy.Post("");
            //};
            //// End Dispose


            //// Reflection
            var assembly = Assembly.LoadFrom(@"../../../../../../LearnAboutLinq/LinqInternals.Demo/PrintAll/bin/Debug/net6.0/PrintAll.dll");

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"Type: {type.Name}");
                var instance = Activator.CreateInstance(type);

                Console.WriteLine("=============================================================================");
                foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine($"Field: {field.Name}");
                    field.SetValue(instance, "Foo");
                }

                Console.WriteLine("=============================================================================");
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(x => !x.IsSpecialName))
                {
                    Console.WriteLine($"Method: {method.Name}");
                    if (method.GetParameters().Length > 0)
                    {
                        method.Invoke(instance, new object[] { "Test Name" });
                    }
                    else if (method.ReturnType.Name != "Void")
                    {
                        var returnedValue = method.Invoke(instance, null);
                        Console.WriteLine($"Returned value from method: {returnedValue}");
                    }
                    else
                    {
                        method.Invoke(instance, null);
                    }
                }


                Console.WriteLine("=============================================================================");
                foreach (var property in type.GetProperties())
                {
                    Console.WriteLine($"Property: {property.Name}");
                    var propertyValue = property.GetValue(instance);

                    Console.WriteLine($"Property value: {propertyValue}");
                }


                Console.WriteLine("******************************************************************************");
            }
            //// End Reflection
        }

        /// <summary>
        /// EXAMPLE ABOUT JOIN IN LINQ
        /// </summary>
        /// <param name="customers"></param>
        private static void ExampleJoinLinq(IEnumerable<Customer> customers)
        {
            if (customers != null && customers.Count() > 0)
            {
                var addresses = new[]
                {
                    new Address(){Id = 1, CustomerId = 2, Street="123 Street", City="City 1"},
                    new Address(){Id = 2, CustomerId = 2, Street="456 Street", City="City 2"},
                };


                var customerInfos = customers.Join(addresses, c => c.Id, a => a.CustomerId, (c,a) => new
                {
                    c.Name, a.Street, a.City
                });
                foreach (var item in customerInfos)
                {
                    Console.WriteLine($"{item.Name} - {item.Street} - {item.City}");
                }
            }
        }

        /// <summary>
        /// EXAMPLE ABOUT SELECT IN LINQ
        /// </summary>
        /// <param name="customers"></param>
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

        /// <summary>
        /// EXAMPLE ABOUT SELECT MANY IN LINQ
        /// </summary>
        /// <param name="customers"></param>
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

        /// <summary>
        /// EXAMPLE ABOUT WHERE IN LINQ
        /// </summary>
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
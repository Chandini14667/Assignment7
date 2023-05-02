using System.Security.Cryptography.X509Certificates;

namespace CustomerManagement
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
    class Management
    {
        List<Customer> customers;
        public int CustomerId = 1;
        public Management()
        {
            customers = new List<Customer>()
            {
                new Customer{Id = CustomerId++,FirstName ="Shaik",LastName ="Chandini",Email="chandini@gmail.com",Age=21,Phone="7550246049",City="Guntur"}
            };
        }
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public Customer GetCustomer(int id)
        {
            foreach(Customer customer in customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }
        public List<Customer> GetCustomers()
        {
            return customers;
        }
        public bool UpdateCustomer(int id)
        {
            foreach(Customer c in customers)
            {
                if (c.Id == id)
                {
                    Console.WriteLine("Enter Customer updated FirstName");
                    c.FirstName  = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Customer updated LastName");
                    c.LastName  = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Customer updated email");
                    c.Email  = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Customer updated age");
                    c.Age  = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Customer updated Phone");
                    c.Phone  = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Customer updated city");
                    c.City  = Convert.ToString(Console.ReadLine());
                    return true;

                }
              
            }
            return false;

        }
        public bool DeleteCustomer(int id)
        {
            foreach(Customer c in customers)
            {
                if (c.Id == id)
                {
                    customers.Remove(c);
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Management obj = new Management();
            string ans = "";
            int CustomerId = 1;
            do
            {
                Console.WriteLine("Welcome to Customer Management App");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Get Customer by Id");
                Console.WriteLine("3. Get all Customers");
                Console.WriteLine("4. Update Customer by Id");
                Console.WriteLine("5. Delete Customer by Id");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            
                            Console.WriteLine("Enter Customer FirstName");
                            string firstname = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Enter Customer LastName");
                            string lastname = Convert.ToString (Console.ReadLine());
                            Console.WriteLine("Enter Customer email");
                            string email = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Enter Customer age");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Customer Phone");
                            string phone = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Enter Customer city");
                            string city = Convert.ToString(Console.ReadLine());
                            int id = CustomerId++;
                            obj.AddCustomer(new Customer() { Id = id, FirstName = firstname, LastName = lastname, Email = email, Age = age, Phone = phone, City = city });
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Customer? c = obj.GetCustomer(id);
                            if (c == null)
                            {
                                Console.WriteLine("The customer with the id does not exist");
                            }
                            else
                            {
                                Console.WriteLine($"{c.Id} {c.FirstName} {c.LastName} {c.Email} {c.Age} {c.Phone} {c.City}");
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach(var c in obj.GetCustomers())
                            {
                                Console.WriteLine($"{c.Id} {c.FirstName} {c.LastName} {c.Email} {c.Age} {c.Phone} {c.City}");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            obj.UpdateCustomer(id);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (obj.DeleteCustomer(id))
                            {
                                Console.WriteLine("Customer Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Customer Id does not exist");
                            }
                            break;
                        }

                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                ans = Console.ReadLine();
            } while (ans.ToLower() == "y");
        }
    }
}
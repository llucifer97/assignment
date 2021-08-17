using System;

namespace Assessment2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            Console.WriteLine("______________create new user________");
            String username, password, email;
            Registration registration = new Registration();
            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("enter username: ");
                username = Console.ReadLine();
                Console.WriteLine("enter password: ");
                password = Console.ReadLine();
                Console.WriteLine("enter email: ");
                email = Console.ReadLine();

                User user = new User(username, password, email);
                registration.addNewUser(user);
            }
        }
    }
}

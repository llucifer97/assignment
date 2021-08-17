using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace Assessment2
{
    class Registration : IRegistration

    {
        List<User> users = new List<User>();
        List<User> deserializeduser;
        public string addNewUser(User user)
        {

            if (ValidateUser(user.UserName, user.Password) == "Valid User")
            {
                users.Add(user);
                Console.WriteLine("Admin user register successfully");
                return "Admin user register successfully";
            }


            // step2: : saving to list

            
                users.Add(user);

            
           

            Console.WriteLine("username and password not in valid format");
            return "username and password not in valid format";
        }

        public void DeSerializeUser()
        {
            FileStream f = new FileStream(@"C:\Users\mindtreedotnet27\Desktop\solution", FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            b.Deserialize(f);
            Console.WriteLine("Deserialize Complete");
            //throw new NotImplementedException();
        }

        public void SaveUserInExcelFile()
        {
            // sort the list
            users.Sort();

            // save to excel file


            
        }

        public void SerializeUser()
        {

            foreach (var i in users)
            {

                FileStream f = new FileStream(@"C:\Users\mindtreedotnet27\Desktop\solution", FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(f, i);
                f.Close();
            }
            Console.WriteLine("Intern list serialized Successfully");
        }

        public string ValidateUser(string UserName, string password)
        {
            
           // Regex rgx = new Regex("[^A-Za-z0-9]");
          //  Regex rgxPassword = new Regex(@"?=.[.!@$%^&(){}[]:;<>,.?\/~_+-=|\]");
            Regex rgxPassword = new Regex("[a-z0-9@]");
            Regex rgxUsername = new Regex(@"[a-zA - Z]");
            //bool cotainsspecialcharacter = rgx.IsMatch(password);

            if (rgxPassword.IsMatch(password) && rgxUsername.IsMatch(UserName) )
            {
               
                return "Valid User";
            }
            return "user name and password not in valid format";

            //   throw new NotImplementedException();

        }
    }
}

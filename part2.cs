using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
namespace Solution
{
	[Serializable]
	public class User : IComparable<User>
	{
		public string UserName;
		public string Password;
		public string Email;

	
		public int CompareTo(User user)
		{
			return UserName.CompareTo(User.UserName);
		}

		public User(string UserName, string Password, string Email)
		{
			
			this.UserName = UserName;
			this.Password = Password;
			this.Email = Email;

		}

	}

	public class Registration
	{

		public List<User> result()
		{
			UserList.OrderBy(o => o.UserName).ToList();

			return UserList;
		}
		public List<User> UserList = new List<User>();
		public string AddNewUser()
		{

			Console.WriteLine("Enter UserName,Password,Email");
			string UserName = Console.ReadLine();
			string Password = Console.ReadLine();
			string Email = Console.ReadLine();
			Regex rgx = new Regex(@"?=.[.!@$%^&(){}[]:;<>,.?/~_+-=|\]");
			Regex regx = new Regex(@"[a-zA - Z]");
			if (regx.IsMatch(UserName) == true )
			{
				if (rgx.IsMatch(Password) == true)
				{
					User r = new User(UserName, Password, Email);
					UserList.Add(r);
					Console.WriteLine("Admin user registered successfully");
					return null;
				}
				else
				{
					Console.WriteLine("Password is not in a correct format");
				}
			}
			else
			{
				Console.WriteLine("Username is not in a correct format");
			}
			return null;
		}


	}


		public class MyClass
		{
			public static void Main()
			{
				Registration manage = new Registration();
				manage.AddNewUser();

				List<User> printlist1 = manage.result();

				if (printlist1.Count() != 0)
				{
					foreach (User i in printlist1)
					{
						Console.WriteLine("{0} {1} {2}", i.UserName, i.Password, i.Email);
					}
				}

				try
				{
					serializing s = new serializing();
					s.SerializeUser(printlist1);
					deserializing ds = new deserializing();
					ds.DeSerializeUser();

				}
				catch (NullReferenceException e)
				{
					Console.WriteLine("{0} First exception caught.", e);
				}

			}

			public class serializing
			{
				public string SerializeUser(List<User> Istintern)
				{
					foreach (var i in Istintern)
					{

						FileStream f = new FileStream("temp.txt", FileMode.Create);
						BinaryFormatter b = new BinaryFormatter();
						b.Serialize(f, i);
						f.Close();
					}
					Console.WriteLine("User list serialized Successfully");
					return "User list serialized Successfully";
				}

			}


			public class deserializing
			{
				public string DeSerializeUser()
				{
					FileStream f = new FileStream("temp.txt", FileMode.Open);
					BinaryFormatter b = new BinaryFormatter();
					b.Deserialize(f);
					Console.WriteLine("Deserialize Complete");
					return "Deserialize Complete";
				}
			}
		}
}

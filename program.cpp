using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace Solution
{   
    [Serializable]
	public class Intern : IComparable<Intern>
	{
		static int autoid = 100;
		public int InternID;
		public string InternName;
		public int PresentDays;
		public int AbsentDays;
		public long salary;
		public string month;

		public int CompareTo(Intern intern)
		{
			return InternName.CompareTo(intern.InternName);
		}

		public Intern(string InternName, int AbsentDays, string month)
		{
			autoid = autoid + 1;
			InternID = autoid;
			this.InternName = InternName;
			this.AbsentDays = AbsentDays;
			this.month = month;
			this.salary = 500 * this.PresentDays;

		}
		public static int PrintPresentDays(string month)
		{

			switch (month)
			{
				case "january":

				case "march":

				case "may":

				case "july":
				case "august":
				case "october":
				case "december":
					return 31;
				case "april":
				case "june":
				case "september":
				case "november":
					return 30;

				case "feb":
					return 28;
			}
			return 0;
		}

	}

	public class InternRepository
	{
		public List<Intern> InternList = new List<Intern>();
		public string GetNewIntern()
		{
		    Console.WriteLine("Enter number of interns");
			int n = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
			    Console.WriteLine("Enter Name, abesntdays,month");
				string InternName = Console.ReadLine();
				int absentdays = Convert.ToInt32(Console.ReadLine());
				string month = Console.ReadLine();
				Intern r = new Intern(InternName, absentdays, month);
				InternList.Add(r);
				Console.WriteLine("New Intern Added Successfully");

			}
			return null;
		}

		public List<Intern> result()
		{
		    InternList.OrderBy(o=>o.InternName).ToList();
			
			return InternList;
		}

	}

	public class MyClass
	{
		public static void Main()
		{
			InternRepository manage = new InternRepository();
			manage.GetNewIntern();

			List<Intern> printlist1 = manage.result();

			if (printlist1.Count() != 0)
			{
				foreach (Intern i in printlist1)
				{
					Console.WriteLine("{0}   {1}  {2} {3} {4} {5}", i.InternID, i.InternName,
						i.AbsentDays, i.PresentDays, i.salary, i.month);
				}
			}

try{
			serializing s = new serializing();
			s.SerializeIntern(printlist1);
			deserializing ds = new deserializing();
			ds.DeSerializeIntern();
	
	}catch(NullReferenceException e){
	    Console.WriteLine("{0} First exception caught.", e);
	}		

		}

		public class serializing
		{
			public string SerializeIntern(List<Intern> Istintern)
			{
				foreach (var i in Istintern)
				{
					
					FileStream f = new FileStream("temp.txt",FileMode.Create);
					BinaryFormatter b = new BinaryFormatter();
					b.Serialize(f, i);
					f.Close();
				}
					Console.WriteLine("Intern list serialized Successfully");
				return "Intern list serialized Successfully";
			}
			
		}


		public class deserializing
		{
			public string DeSerializeIntern()
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

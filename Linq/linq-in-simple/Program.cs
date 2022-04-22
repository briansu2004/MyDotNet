using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		// Student collection
		IList<Student> studentList = new List<Student>() { 
			new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
				new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
				new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
				new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
				new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 } 
		};
		
		var teenStudentsName = from s in studentList
                       where s.Age > 12 && s.Age < 20
                       select new { StudentName = s.StudentName };

		teenStudentsName.ToList().ForEach(s => Console.WriteLine(s.StudentName));

		Console.WriteLine("-----------");
		
		var words = new string[] { "falcon", "eagle", "sky", "tree", "water" };

		// Query syntax
		var res = from word in words
				  where word.Contains('a')
				  select word;

		foreach (var word in res)
		{
			Console.WriteLine(word);
		}

		Console.WriteLine("-----------");

		// Method syntax
		var filterWords = new string[] { "sky", "tree", "water" };
		
		var res2 = words.Where(word => filterWords.Contains(word));

		foreach (var word in res2)
		{
			Console.WriteLine(word);
		}
	}
}

public class Student{
	public int StudentID { get; set; }
	public string StudentName { get; set; }
	public int Age { get; set; }
	public int StandardID { get; set; }		
}

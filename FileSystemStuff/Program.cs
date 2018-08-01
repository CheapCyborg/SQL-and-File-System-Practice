using System;
using System.IO;
using Newtonsoft.Json;

namespace FileSystemStuff
{
    class Program
    {
        static void Main(string[] args)
        {



		}

		static void Example1()
		{
			//var name = "Third run!";
			var fileName = "Jeff.txt";
			var path = "C:\\MyFiles\\" + fileName;
			if (File.Exists(path))
			{
				var read = File.ReadAllText(path);
				Console.WriteLine(read);
			}
			else
			{
				File.WriteAllText(path, String.Empty);
			}
			File.Copy(path, path.Replace("Jeff", "Adam"));
			Console.ReadKey();
			//File.WriteAllText(path, name);
			//var read = File.ReadAllText(path);
		}

		static void Example2()
		{
			var pet = new Pet()
			{
				Name = "Loretta",
				Age = 5,
				IsSpotted = true,
				Color = "Brown"
			};

			var petJson = JsonConvert.SerializeObject(pet);

			var path = @"C:\MyFiles\LorettaJson.txt";
			File.WriteAllText(path, petJson);


			var read = File.ReadAllText(path);
			var pet2 = JsonConvert.DeserializeObject<Pet>(read);


			// Proposed Exercise:
			//  Use a file system folder as a database.
			//  Create any class you wish (such as Pet), and write many "records", where a single
			//   record is a single file in the folder.
			//  Create methods in your application to read and write those classes (in JSON shape).
			//  Use LINQ to perform queries over objects that are being read from the operating system.
			//  Be creative!
		}
	}
}

using System;
using System.IO;

namespace DataStuff
{
    class Program
    {
        static void Main(string[] args)
        {
			var path = @"C:\New Folder\Pets.txt";
			var database = new SqlDatabase("Server =.\\S2017;Database=Pets;Trusted_Connection=True;");
			var newPet = new Pet()
			{
				Name = "Loretta",
				Age = 3,
				IsSpotted = false,
				Color = "Black and White Striped"
			};
			AddPet(database, newPet);

			foreach (var pet in database.GetAllPets())
			{
				string pets = $"The pet is named {pet.Name} and is {pet.Age} years old.";

				File.WriteAllText(path, pets);
			}

			Console.ReadKey();
		}

		static void AddPet(IDatabase database, Pet pet)
		{
			database.Create(pet);
		}

		static void Example3()
		{
			var database = new FileSystemDatabase(@"C:\New Folder");
			database.Create(new Pet()
			{
				Id = 101,
				Name = "Loretta",
				Age = 5,
				IsSpotted = true,
				Color = "Brown"
			});


			var loretta = database.Read(101);
		}

		static void Example4()
		{
			var path = @"C:\New Folder\101.txt";
			//string allText;
			using (var stream = new FileStream(path, FileMode.Open))
			{
				using (var reader = new StreamReader(stream))
				{
					while (!reader.EndOfStream)
					{
						Console.WriteLine(reader.Read());
					}
				}
			}

			//Console.WriteLine(allText);
			Console.ReadKey();
		}
    }
}

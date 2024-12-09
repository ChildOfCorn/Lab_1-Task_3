using System;

class Employee
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Position { get; set; }
	public int Experience { get; set; }

	public Employee(string firstName, string lastName)
	{
		FirstName = firstName;
		LastName = lastName;
	}

	public decimal CalculateSalary()
	{
		decimal baseSalary = Position switch
		{
			"Manager" => 3000m,
			"Engineer" => 2500m,
			"Administrator" => 2000m,
			_ => 1800m,
		};

		decimal experienceBonus = 0.05m * Experience * baseSalary;
		return baseSalary + experienceBonus;
	}

	public decimal CalculateTax()
	{
		decimal salary = CalculateSalary();
		return salary * 0.2m;
	}

	public void DisplayInfo()
	{
		decimal salary = CalculateSalary();
		decimal tax = CalculateTax();

		Console.WriteLine($"Name: {FirstName}");
		Console.WriteLine($"Surname: {LastName}");
		Console.WriteLine($"Job title: {Position}");
		Console.WriteLine($"Salary: {salary:C}");
		Console.WriteLine($"Tax collection: {tax:C}");
	}
}

class Program
{
	static void Main(string[] args)
	{
		Console.Write("Enter a name: ");
		string firstName = Console.ReadLine();

		Console.Write("Enter your surname: ");
		string lastName = Console.ReadLine();

		Console.Write("Enter the position (Manager, Engineer, Administrator, etc.): ");
		string position = Console.ReadLine();

		Console.Write("Enter the length of service (in years): ");
		int experience;
		while (!int.TryParse(Console.ReadLine(), out experience) || experience < 0)
		{
			Console.Write("Incorrect input. Enter the length of service again: ");
		}

		Employee employee = new Employee(firstName, lastName)
		{
			Position = position,
			Experience = experience
		};

		Console.WriteLine("\nInformation about the employee:");
		employee.DisplayInfo();
	}
}

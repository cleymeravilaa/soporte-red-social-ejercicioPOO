using MyApplication.Models;

namespace MyApplication
{
	class Program
	{
		static void Main(string[]args)
		{
			User user = new User("Cleymer", "cleymer@gmail.com", "123456", "123456789");
			
			Console.WriteLine(user.Name);
			Console.WriteLine(user.Email);
			Console.WriteLine(user.PhoneNumber);
			
			user.Username = "clxymer";
			
			Console.WriteLine(user.Username);
			
			Console.WriteLine("----------------------------");
			Console.WriteLine(user);
		}
	}
}

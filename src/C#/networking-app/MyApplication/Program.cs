
using MyApplication.Models;

namespace MyApplication
{
	
	class Program
	{
	
		static void Main(string[]args)
		{
			User user = new User("Cleymer Avila", "cleymer@gmail.com", "cavila", "mipass0987", "3113053800");


			DateTime caducationDate = new DateTime(2024, 9, 9);
			user.PostArticle("El titulo de un articulo", "Este es el contenido del articulo");
			user.PostNews("El titulo de una noticia", "Este es el contenido de una noticia", caducationDate);

			Console.WriteLine(user);

			user.setProfile("cleymer.com", "Cartagena/Bolivar", new DateTime(2005, 01, 9), "My BioGraphy", "./profile.png");

			

			user.ListPosts();

			Console.WriteLine("-------------------------------------");
			Console.WriteLine(user.Profile);

			user.Posts.ElementAt(0).AddComment("Estoy comentando", user);
			user.Posts.ElementAt(0).AddComment("Estoy comentando otra vez", user);
			user.Posts.ElementAt(1).AddComment("Estoy comentando una tercera vez", user);
			user.Posts.ElementAt(1).AddComment("Estoy comentando una cuarta vez", user);
			user.ListPosts();

			user.AddPostToMarkedPosts(user.Posts.ElementAt(0));
			user.ListMarkedPosts();
			

			User user2 = new User("Adolfo Avila", "adolfo@gmail.com", "aavila", "mipass0987", "3113053800");
			user.AddUserToPersonalContacts(user2);
			user.ListPersonalContacts();

			user.CreateGroup("Deportes", "Esto es un grupo de deportes para compartir de sus pasiones por el deporte"); 

			Console.WriteLine(user.Groups.First());
			user.AddMemberToGroup(user.Groups.ElementAt(0), user2); 
		
			List<Group> groups = user.Groups;
			

			user.Groups.ElementAt(0).ListMembers(); 
			
			User user3 = new User("Carlos Avila", "carlos@gmail.com", "cavila", "mipass0987", "3113053800");

			
			user3.RequestToJoinGroup(groups.ElementAt(0));

			groups.ElementAt(0).ListRequests();

			user.AcceptUserRequest(groups.ElementAt(0), 0);


			groups.ElementAt(0).ListMembers();

			User user4 = new User("Juan Avila", "juan@gmail.com", "javila", "mipass0987", "3113053800");

			user4.RequestToJoinGroup(groups.ElementAt(0));

			user3.AcceptUserRequest(groups.ElementAt(0), 0);

			
			user.CreateConversation(user2, "Hola, soy Carlos");
			user.Conversations.ElementAt(0).ListMessages();

			user2.Conversations.ElementAt(0).AddMessage("Habla hermano que tal");
			user2.Conversations.ElementAt(0).ListMessages();

			user.ListNotifications();

			user3.ListNotifications();
			user4.ListNotifications();
		}
	}
}


using System.Text;

namespace MyApplication.Models
{
	public class Group
	{
		private string name;
		private string description;
		private List<User> members;
		private List<User> admins;
		private List<Post> posts;
		private List<Group> subGroups;
		private List<User> requestsUsers;
		private List<string> messages;
		private const int MAX_SUBGROUPS = 5;
		private const int MAX_ADMINS = 5;


		public Group(string name, string description)
		{
			this.name = name;
			this.description = description;
			this.members = new List<User>();
			this.admins = new List<User>(MAX_ADMINS);
			this.posts = new List<Post>();
			this.subGroups = new List<Group>(MAX_SUBGROUPS);
			this.requestsUsers = new List<User>();
			this.messages = new List<string>();
		}

		// Metodos Getters y Setters
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public List<User> Members
		{
			get { return members; }
		}

		public List<User> Admins
		{
			get { return admins; }
		}

		public List<Post> Posts
		{
			get { return posts; }
		}

		public List<Group> SubGroups
		{
			get { return subGroups; }
		}

		public List<User> RequestsUsers
		{
			get { return requestsUsers; }
		}

		public List<string> Messages
		{
			get { return messages; }
		}

		public void AddAdmin(User user)
		{
			this.admins.Add(user);
		}

		public void AddMember(User user)
		{
			this.members.Add(user);
		}

		public void AddPost(Post post)
		{
			this.posts.Add(post);
		}

		public void AddSubgroup(Group group)
		{
			this.subGroups.Add(group);
		}

		public void AddMessage(string message)
		{
			this.messages.Add(message);
		}

		public void ListMembers()
		{
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Listado de Miembros:\n");
			foreach (User u in this.members)
			{
				Console.WriteLine(u);
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Grupo: \n");
			sb.Append("-----------------------------------\n");
			sb.Append("Nombre: " + this.name + "\n");
			sb.Append("Descripción: " + this.description + "\n");
			sb.Append("Membres: \n");
			foreach (User u in this.members)
			{
				sb.Append(u);
			}
			sb.Append("-------------------------------------");
			return sb.ToString();

		}

		public void AddRequest(User user)
		{
			this.requestsUsers.Add(user);
		}

		public void ListRequests()
		{
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Listado de Solicitudes:\n");
			foreach (User u in this.requestsUsers)
			{
				Console.WriteLine(u);
			}
		}

	}
}

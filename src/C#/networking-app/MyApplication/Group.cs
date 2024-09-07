
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
		
		public Group()
		{
			
		}
		
		public Group(string name, string description)
		{
			this.name = name;
			this.description = description;
			this.members = new List<User>();
			this.admins = new List<User>();
			this.posts = new List<Post>();
			this.subGroups = new List<Group>();
		}
		
		// Metodos Getters y Setters
		public string Name
		{
			get {return name;}
			set {name = value;}
		}
		
		public string Description
		{
			get {return description;}
			set {description = value;}
		}
		
		public List<User> Members
		{
			get {return members;}
		}
	
	}
}

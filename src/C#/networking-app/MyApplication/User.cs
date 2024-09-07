
namespace MyApplication.Models
{
	public class User
	{
		private string username;
		private string name;
		private string email;
		private string phoneNumber;
		private string password;
		private List<Group> groups;
		private Profile profile;
		private List<Post> posts;
		private List<User> personlCantacts;
		private List<Post> markedPosts;
		private bool isModerator;
		private List<Notification> notifications;

		public User()
		{

		}

		public User(string name, string email, string password, string phoneNumber)
		{
			this.name = name;
			this.email = email;
			this.password = password;
			this.phoneNumber = phoneNumber;
		}

		// Metodos Getters y Setters
		public string Name 
		{ 
			get {return name;}
			set {name = value;}
		}

		public string Email
		{
			get {return email;}
			set {email = value;}
		}

		public string PhoneNumber
		{
			get {return phoneNumber;}
			set {phoneNumber = value;}
		}
		
		public string Password
		{
			get {return password;}
			set {password = value;}
		}
		
		public string Username
		{
			get {return username;}
			set {username = value;}
		}
		
		public List<Group> Groups
		{
			get {return groups;}
			set {groups = value;}
		}
		
		public Profile Profile
		{
			get {return profile;}
			set {profile = value;}
		}
		
		public List<Post> Posts
		{
			get {return posts;}
			set {posts = value;}
		}
		
		public List<User> PersonalContacts
		{
			get {return personlCantacts;}
			set {personlCantacts = value;}
		}
		
		public List<Post> MarkedPosts 
		{
			get {return markedPosts;}
			set {markedPosts = value;}
		}
		
		public bool IsModerator
		{
			get {return isModerator;}
			set {isModerator = value;}
		}
		
		public List<Notification> Notifications
		{
			get {return notifications;}
			set {notifications = value;}
		}

        public override string ToString()
        {
            return $"Nombre: {this.name}\n" +
                   $"Email: {this.email}\n" +
                   $"Usuario: {this.username}\n" +
                   $"Teléfono: {this.phoneNumber}\n" +
                   $"Contraseña: {this.password}\n" +
                   $"Notificaciones:\n" +
                   $"{this.notifications}";
        }
    }
}



using System.Text;
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
		private List<User> personalContacts;
		private List<Post> markedPosts;
		private bool isModerator;
		private List<Notification> notifications;
		private List<Conversation> conversations;
		

		public User(string name, string email, string username, string password, string phoneNumber)
		{
			this.name = name;
			this.email = email;
			this.username = username;
			this.password = password;
			this.phoneNumber = phoneNumber;
			this.posts = new List<Post>();
			this.personalContacts = new List<User>();
			this.markedPosts = new List<Post>();
			this.notifications = new List<Notification>();
			this.groups = new List<Group>();
			this.conversations = new List<Conversation>();
			this.profile = new Profile();
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
			get {return personalContacts;}
			set {personalContacts = value;}
		}
		
		public List<Conversation> Conversations
		{
			get {return conversations;}
			set {conversations = value;}
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
		
		public void setProfile(string personalWebsiteURL, string location, DateTime birthDate, string biography, string profilePicture){
			this.profile = new Profile(personalWebsiteURL, location, birthDate, biography, profilePicture);
		}

		public override string ToString()
		{
			return $"User: \n" +
				   $"----------------------------------\n"+ 
				   $"Nombre: {this.name}\n" +
				   $"Email: {this.email}\n" +
				   $"Usuario: {this.username}\n" +
				   $"Teléfono: {this.phoneNumber}\n" +
				   $"Contraseña: {this.password}\n";
		}
		
		public void PostArticle(string title, string text){
			Article post = new Article(title, text, this);
			posts.Add(post);
		}

		public void PostNews(string title, string text, DateTime caducationDate ){
			News post = new News(title, text, this, caducationDate);
			posts.Add(post);
		}

		public void ListPosts(){

			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Listado de Publicaciones:\n");
			foreach(Post p in this.posts){
				if(p is Article){
					Console.WriteLine("Tipo de Publicación: Artículo");
					Console.WriteLine(p);
				} else {
					Console.WriteLine("Tipo de Publicación: Noticia");
					Console.WriteLine(p);
				}
			}
			
		}
		
		public void AddPostToMarkedPosts(Post post){
			markedPosts.Add(post);
		}

		public void ListMarkedPosts(){
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Listado de Publicaciones marcadas:\n");
			foreach(Post p in this.markedPosts){
				Console.WriteLine(p);
			}
		}

		public void AddUserToPersonalContacts(User user){
			personalContacts.Add(user);
		}

		public void ListPersonalContacts(){
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Listado de Contactos:\n");
			foreach(User u in this.personalContacts){
				Console.WriteLine(u);
			}
		}

		public void CreateGroup(string name, string description){
			Group group = new Group(name, description);
			group.AddAdmin(this);
			group.AddMember(this);
			this.isModerator = true;
			groups.Add(group);
		}

		public void AddMemberToGroup(Group group, User user){
			group.AddMember(user);

		}

		public void AddAdminToGroup(Group group, User user){
			if (group.Members.Contains(user)) {
				group.AddAdmin(user);
				user.isModerator = true;
				
			} else {
				Console.WriteLine("El usuario no es miembro del grupo");
			}
		}
		public void ListGroups(){
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Listado de Grupos:\n");
			foreach(Group g in this.groups){
				Console.WriteLine(g);
			}
		}

		public void RequestToJoinGroup(Group group){
			group.AddRequest(this);
		}

		public void AcceptUserRequest(Group group, int index){
			if (group.Admins.Contains(this)) {
				User user = group.RequestsUsers.ElementAt(index);
				AddMemberToGroup(group,user);
				group.RequestsUsers.Remove(user);
				user.AddNotification("Solicitud de Grupo: "+ group.Name, "Has sido aceptado a unirte al grupo\nFelicitaciones ya eres miembro de este maravilloso grupo");
				Console.WriteLine("El usuario ha sido aceptado");

			} else {
				Console.WriteLine("No eres el administrador del grupo");
			}
		}


		public void DeleteUserFromGroup(Group group, int index){
			if (group.Admins.Contains(this)) {
				User user = group.Members.ElementAt(index); 
				group.Members.Remove(user);
				user.AddNotification("Solicitud de Grupo: "+ group.Name, "Has sido eliminado de este grupo por "+ this.Name);
				Console.WriteLine("El usuario ha sido eliminado");
			} else {
				Console.WriteLine("No eres el administrador del grupo");
			}
		}

		private void AddNotification(string subject, string content) {
			Notification notification = new Notification(subject, content,this.email, this.name, this.phoneNumber);
			this.notifications.Add(notification);
		}

		public void SentPostToGroup(Group group, Post post){
			if (group.Members.Contains(this)) {

				StringBuilder sb = new StringBuilder();
				sb.Append("Publicación enviada a grupo:\n");
				sb.Append("Tipo de Publicación: " + post.GetType().Name + "\n");
				sb.Append(post);

				if (post is Article) {
					var article = (Article) post;
					article.SetEditorialStatus("enviado");
				}


				group.AddPost(post);
				foreach(User u in group.Members){
					u.Notifications.Add(new Notification("Nueva Publicación", "Nueva publicación de "+ this.name+ "\nPublicación: \n"+ sb.ToString(), u.Email, u.Name, u.PhoneNumber));
				}
				group.AddMessage(sb.ToString());

			} else {
				Console.WriteLine("No eres miembro del grupo");
			}
		}
		
		public void PostOnGroup(Group group, string text){
			if(group.Members.Contains(this)){
				group.AddMessage(text);
			}
		}


		public void CreateConversation(User user, string text){
			Conversation conversationStarter= new Conversation(text, this, user);
			Conversation conversationParticipant = new Conversation(text, user, this);
			this.conversations.Add(conversationStarter);
			user.conversations.Add(conversationParticipant);

			Notification newNotification = new Notification("Nueva Conversación","Nuevo mensaje de"+ user.Username+ "\nMensaje: \n"+ text, user.Email, user.Name, user.PhoneNumber); 
			user.Notifications.Add(newNotification);
		}

		public void ListNotifications(){
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Listado de Notificaciones:\n");
			foreach(Notification n in this.notifications){
				Console.WriteLine(n);
			}
		}
	}
}


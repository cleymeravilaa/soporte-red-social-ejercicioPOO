namespace MyApplication.Models 
{
	public class Profile 
	{
		private string personalWebsiteUrl;
		private string location;
		private DateTime birthDate;
		private string biography;
		private string profilePicture;

		public Profile(){}

		public Profile(string personalWebsiteUrl, string location, DateTime birthDate, string biography, string profilePicture){
			this.personalWebsiteUrl = personalWebsiteUrl;
			this.location = location;
			this.birthDate = birthDate;
			this.biography = biography;
			this.profilePicture = profilePicture;
		}

		// Metodos Getters
		public string PersonalWebsiteUrl
		{
			get {return personalWebsiteUrl;}
			set {personalWebsiteUrl = value;}
		}
		
		public string Location
		{
			get {return location;}
			set {location = value;}
		}
		
		public DateTime BirthDate 
		{
			get {return birthDate;}
			set {birthDate = value;}
		}
		
		public string Biography 
		{
			get {return biography;}
			set {biography = value;}
		}
		
		public string ProfilePicture 
		{
			get {return profilePicture;}
			set {profilePicture = value;}
		}
	}
}
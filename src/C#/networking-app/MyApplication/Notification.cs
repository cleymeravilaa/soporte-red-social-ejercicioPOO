namespace MyApplication.Models
{
	public class Notification
	{
		private string subject;
		private string content;
		private string recipientEmail; 
		private string recipientName;
		private string recipientPhoneNumber;
		
		public Notification()
		{
			
		}
		
		public Notification(string subject, string content, string recipientEmail, string recipientName, string recipientPhoneNumber)
		{
			this.subject = subject;
			this.content = content;
			this.recipientEmail = recipientEmail;
			this.recipientName = recipientName;
			this.recipientPhoneNumber = recipientPhoneNumber;
		}
		
		// Metodos Getters y Setters
		public string Subject
		{
			get {return subject;}
			set {subject = value;}
		}
		
		public string Content
		{
			get {return content;}
			set {content = value;}
		}
		
		public string RecipientEmail
		{
			get {return recipientEmail;}
			set {recipientEmail = value;}
		}
		
		public string RecipientName
		{
			get {return recipientName;}
			set {recipientName = value;}
		}
		
		public string RecipientPhoneNumber
		{
			get {return recipientPhoneNumber;}
			set {recipientPhoneNumber = value;}
		}
	}
}
using System.Text;

namespace MyApplication.Models
{
	public class Notification
	{
		private string subject;
		private string content;
		private string recipientEmail; 
		private string recipientName;
		private string recipientPhoneNumber;
		
		private DateTime date;
		
		
		public Notification(string subject, string content, string recipientEmail, string recipientName, string recipientPhoneNumber)
		{
			this.subject = subject;
			this.content = content;
			this.recipientEmail = recipientEmail;
			this.recipientName = recipientName;
			this.recipientPhoneNumber = recipientPhoneNumber;
			this.date = DateTime.Now;
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
		
		public DateTime Date
		{
			get {return date;}
			set {date = value;}
		}
		
		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			sb.Append("-----------------------------------\n");
			sb.Append("Fecha: " + this.date + "\n");
			sb.Append("Subject: " + this.subject + "\n");
			sb.Append("Content: " + this.content + "\n");
			sb.Append("-------------------------------------");
			return sb.ToString();
		}
	}
}
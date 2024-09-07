package Java;

import java.util.Date;

public class Notification {
    private String subject;
    private String recipientEmail;
    private String recipientName;
    private String recipientPhoneNumber;
    private String content;
    private Date date;

    public Notification(){

    }

    public Notification(String subject, String recipientEmail, String recipientName, String recipientPhoneNumber, String content){
        this.subject = subject;
        this.recipientEmail = recipientEmail;
        this.recipientName = recipientName;
        this.recipientPhoneNumber = recipientPhoneNumber;
        this.content = content;
        this.date = new Date();
    }

    // Metodos Getters
    public String getSubject(){
        return this.subject;
    }

    public String getRecipientEmail(){
        return this.recipientEmail;
    }

    public String getRecipientName(){
        return this.recipientName;
    }

    public String getRecipientPhoneNumber(){
        return this.recipientPhoneNumber;
    }

    public String getContent(){
        return this.content;
    }

    // Metodos Setters

    public void subject(String subject){
        this.subject = subject;
    }

    public void recipientEmail(String recipientEmail){
        this.recipientEmail = recipientEmail;
    }

    public void recipientName(String recipientName){
        this.recipientName = recipientName;
    }

    public void recipientPhoneNumber(String recipientPhoneNumber){
        this.recipientPhoneNumber = recipientPhoneNumber;
    }
    
    public void content(String content){
        this.content = content;
    }

    @Override
    public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append("-----------------------------------\n");
        sb.append("Fecha: " + this.date + "\n");
        sb.append("Subject: " + this.subject + "\n");
        sb.append("Content: " + this.content + "\n");
        sb.append("-------------------------------------");
        return sb.toString();
    }
    
}

package Java;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class News extends Post {
    private static int coutsId;;
    private int id;
    private static int countCommentId;
    private Date caducationDate;

    public News(){
    }

    public News(String title, String content, User author, Date caducationDate){
        super(title, content, author);
        this.id = ++News.coutsId;
        this.caducationDate = caducationDate;
        this.comments = new ArrayList<>();
    }

    // Metodos Getters
    public Date getCaducationDate(){
        return this.caducationDate;
    }

    public int getId(){
        return this.id;
    }

    public List<Comment> getComments(){
        return this.comments;
    }
    
    // Metodos Setters
    public void setCaducationDate(Date caducationDate){
        this.caducationDate = caducationDate;
    }

    @Override
    public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append(super.toString());
        sb.append("Id: " + this.id + "\n");
        sb.append("Fecha de caducidad: " + this.caducationDate + "\n");
        if (super.comments.size() > 0){
            sb.append("-------------------------------------\n");
            sb.append("Comentarios: \n");
            for(Comment c : super.comments){
                sb.append(c);
                sb.append("\n");
            }
        } else {
            sb.append("No hay comentarios\n");
        }
        sb.append("-------------------------------------");
        return sb.toString();
    }

    @Override
    public void addComment(String text, User author){
        this.comments.add(new Comment( ++News.countCommentId,text, this.author, this));
        Notification newNotification = new Notification("Nuevo Comentario", this.author.getEmail(), this.author.getName(), this.author.getPhoneNumber(), "Nuevo comentario de "+author.getUsername()+ "\nComentario: \n"+ text);
        this.author.getNotifications().add(newNotification);
    }

}

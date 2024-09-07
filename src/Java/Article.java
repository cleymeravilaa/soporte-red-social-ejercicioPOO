package Java;

import java.util.ArrayList;
import java.util.List;

public class Article extends Post {
    private String editorialStatus; // sent, aproved, rejected
    private static int coutsId;;
    private static int coutsCommentsId;
    private int id;

    public Article(String title, String content, User author){
        super(title, content, author);
        this.id = ++Article.coutsId;
        this.editorialStatus = "sent";
        
        this.comments = new ArrayList<>();
    }

    // Metodos Getters
    public String getEditorialStatus(){
        return this.editorialStatus;
    }

    public List<Comment> getComments(){
        return this.comments;
    }

    public int getId(){
        return this.id;
    }

    // Metodos Setters
    public void setEditorialStatus(String editorialStatus){
        this.editorialStatus = editorialStatus;
    }

    @Override
    public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append(super.toString());
        sb.append("Id: " + this.id + "\n");
        sb.append("Estado de editorial: " + this.editorialStatus + "\n");
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
        this.comments.add(new Comment(++Article.coutsCommentsId, text, author, this));
        Notification newNotification = new Notification("Nuevo Comentario", this.author.getEmail(), this.author.getName(), this.author.getPhoneNumber(), "Nuevo comentario de "+author.getUsername()+ "\nComentario: \n"+ text);
        this.author.getNotifications().add(newNotification);
    }
}

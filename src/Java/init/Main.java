package Java.init;

import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;
import Java.Group;

import Java.User;

public class Main {
    public static void main(String[] args) {
        User user = new User("Cleymer Avila", "cleymer@gmail.com", "cavila", "mipass0987", "3113053800");


        Date caducationDate = new GregorianCalendar(2024, 9, 9).getTime();
        user.PostArticle("El titulo de un articulo", "Este es el contenido del articulo");
        user.PostNews("El titulo de una noticia", "Este es el contenido de una noticia", caducationDate);

        System.out.println(user);

        user.setProfile("cleymer.com", "Cartagena/Bolivar", new GregorianCalendar(2005, 01, 9).getTime(), "My BioGraphy", "./profile.png");

        

        user.ListPosts();

        System.out.println("-------------------------------------");
        System.out.println(user.getProfile());

        user.getPosts().get(0).addComment("Estoy comentando", user);
        user.getPosts().get(0).addComment("Estoy comentando otra vez", user);
        user.getPosts().get(1).addComment("Estoy comentando una tercera vez", user);
        user.getPosts().get(1).addComment("Estoy comentando una cuarta vez", user);
        user.ListPosts();

        user.addPostToMarkedPosts(user.getPosts().get(0));
        user.listMarkedPosts();
        

        User user2 = new User("Adolfo Avila", "adolfo@gmail.com", "aavila", "mipass0987", "3113053800");
        user.addUserToPersonalContacts(user2);
        user.listPersonalContacts();

        user.createGroup("Deportes", "Esto es un grupo de deportes para compartir de sus pasiones por el deporte"); 

        System.out.println(user.getGroups().getFirst());
        user.addMemberToGroup(user.getGroups().get(0), user2);
    
        List<Group> groups = user.getGroups();
        

        user.getGroups().get(0).listMembers();
        
        User user3 = new User("Carlos Avila", "carlos@gmail.com", "cavila", "mipass0987", "3113053800");

        
        user3.requestToJoinGroup(groups.get(0));

        groups.get(0).listRequests();

        user.acceptUserRequest(groups.get(0), 0);


        groups.get(0).listMembers();

        User user4 = new User("Juan Avila", "juan@gmail.com", "javila", "mipass0987", "3113053800");

        user4.requestToJoinGroup(groups.get(0));

        user3.acceptUserRequest(groups.get(0), 0);

        
        user.createConversation(user2, "Hola, soy Carlos");
        user.getConversations().get(0).listMessages();

        user2.getConversations().get(0).addMessage("Habla hermano que tal");
        user2.getConversations().get(0).listMessages();

        user.listNotifications();

        user3.listNotifications();
        user4.listNotifications();

    }

    
}

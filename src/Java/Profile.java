package Java;

import java.util.Date;

public class Profile {
    private String personalWebsiteUrl;
    private String location;
    private Date birthDate;
    private String biography;
    private String profilePicture;

    public Profile(){}

    public Profile(String personalWebsiteUrl, String location, Date birthDate, String biography, String profilePicture){
        this.personalWebsiteUrl = personalWebsiteUrl;
        this.location = location;
        this.birthDate = birthDate;
        this.biography = biography;
        this.profilePicture = profilePicture;
    }

    // Metodos Getters
    public String getPersonalWebsiteUrl(){
        return this.personalWebsiteUrl;
    }

    public String getLocation(){
        return this.location;
    }

    public Date getBirthDate(){
        return this.birthDate;
    }

    public String getBiography(){
        return this.biography;
    }

    public String getProfilePicture(){
        return this.profilePicture;
    }

    // Metodos Setters
    public void setPersonalWebsiteUrl(String personalWebsiteUrl){
        this.personalWebsiteUrl = personalWebsiteUrl;
    }

    public void setLocation(String location){
        this.location = location;
    }

    public void setBiography(String bio){
        this.biography = bio;
    }   

    public void setProfilePicture(String profilePicture){
        this.profilePicture = profilePicture;
    }

    public void setBirthDate(Date birthDate){
        this.birthDate = birthDate;
    }
    
    @Override
    public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append("Perfil: \n");
        sb.append("-----------------------------------\n");
        sb.append("URL de mi página personal: " + this.personalWebsiteUrl + "\n");
        sb.append("Ubicación: " + this.location + "\n");
        sb.append("Fecha de nacimiento: " + this.birthDate + "\n");
        sb.append("Biografía: " + this.biography + "\n");
        sb.append("URL de mi foto: " + this.profilePicture + "\n");
        sb.append("-------------------------------------"); 
        return sb.toString();
    }
}

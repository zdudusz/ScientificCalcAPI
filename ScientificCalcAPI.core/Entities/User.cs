namespace ScientificCalcAPI.Core.Entities;

public class User
{
    public User(string name, string email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.Now; //inicio já com a data de criação do usuário
        UpdatedAt = DateTime.Now;
    }

    public int Id { get; set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; }

    public DateTime CreatedAt { get;}

    public DateTime UpdatedAt { get; set; }

    public void UpdateName(string name)
    {
        Name = name;
        UpdatedAt = DateTime.Now; 
    }

    public void UpdateEmail(string email)
    {
        Email = email;
        UpdatedAt = DateTime.Now; 
    }

    public void UpdatePassword(string passwordHash)
    {
        PasswordHash = passwordHash;
        UpdatedAt = DateTime.Now; 
    }


}

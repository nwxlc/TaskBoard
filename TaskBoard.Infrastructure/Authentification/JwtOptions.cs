namespace TaskBoard.Infrastructure.Authentification;

public class JwtOptions
{
    public string SecretKey { get; set; }
    
    public int ExpireHours { get; set; }
}
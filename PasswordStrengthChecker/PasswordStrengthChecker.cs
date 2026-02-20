using System.Text.RegularExpressions; 
namespace PasswordStrengthChecker; 

public class PassWordStrengthChecker
{
    private int _strength;
    private List<string> _weakpoints;
    
    static void Main(string[] args) 
    { 
        Console.Write("Enter your password: "); 
        string password = Console.ReadLine(); 
        if(Regex.IsMatch(password, "[ ]")) 
            throw new Exception("Password cannot include spaces."); 
        int strength = 4; //password is very strong by default
        List<string> weakpoints = new List<string>();
        CheckPasswordStrength(password, ref strength, ref weakpoints);
        switch (strength)
        {
                case 4: 
                    Console.WriteLine("Password is very strong."); 
                    break; 
                case 3: 
                    Console.WriteLine("Password is strong."); 
                    Console.WriteLine("Weakpoints:"); 
                    foreach (var weakpoint in weakpoints) 
                        Console.WriteLine(weakpoint); 
                    break; 
                case >0: 
                    Console.WriteLine("Password is weak."); 
                    Console.WriteLine("Weakpoints:"); 
                    foreach (var weakpoint in weakpoints) 
                        Console.WriteLine(weakpoint); 
                    break; 
                case 0: 
                    Console.WriteLine("Password is very weak."); 
                    Console.WriteLine("Weakpoints:"); 
                    foreach (var weakpoint in weakpoints) 
                        Console.WriteLine(weakpoint); 
                    break;
        } 
    }

    private static void CheckPasswordStrength(string password, ref int strength, ref List<string> weakpoints)
    {
        if (password.Length < 8)
        {
            strength--; 
            weakpoints.Add("Password should contain at least 8 characters.");
        }

        if (!Regex.IsMatch(password, "[a-z]") || !Regex.IsMatch(password, "[A-Z]"))
        {
            strength--; 
            weakpoints.Add("Password should contain both lowercase and uppercase letters.");
        }

        if (!Regex.IsMatch(password, "[0-9]"))
        {
            strength--; 
            weakpoints.Add("Password should contain at least one number.");
        }

        if (!Regex.IsMatch(password, "[\\^_=\\!#\\$%&\\(\\)\\*\\+\\-\\.:'/\\?@]"))
        {
            strength--; 
            weakpoints.Add("Password should contain at least one special character.");
        }
    } 
}
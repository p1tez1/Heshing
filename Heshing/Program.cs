using System;
using System.IO;
using System.Runtime.CompilerServices;
namespace Markiian
{
    public class program
    {

        public static void Main(string[] args)
        {
            String FilePath = "C:\\Users\\marek\\Downloads\\Password.txt";
            Console.WriteLine("Login(1)        |      Sing up(2)");
            int Ch = int.Parse(Console.ReadLine());
            switch (Ch)
            {
                case 1:
                {
                    Console.Write("Enter your password ");
                    string Password = Console.ReadLine();
                    string CompPassword = string.Empty;
                    int flag = 0;
                    int Key = 0;
                        using (StreamReader reader = new StreamReader(FilePath))
                        {
                            string HeshingLine = string.Empty;
                            while ((HeshingLine = reader.ReadLine()) !=null)
                            {
                                CompPassword = string.Empty;
                                char[] Leter = HeshingLine.ToCharArray();
                                if((Leter.Length) % 2 == 0)
                                {
                                    flag = 1;
                                }
                                char MiddleChar = Leter[(Leter.Length / 2)-flag];
                                Key = (int)(MiddleChar - '0');
                                for(int i = 0; i < Leter.Length/2-flag; i++)
                                {
                                    CompPassword += (char)(Leter[i]-Key);
                                }
                                for (int i = (Leter.Length / 2) + 1 - flag; i < Leter.Length; i++)
                                {
                                    CompPassword += (char)(Leter[i] - Key);
                                }
                                if(Password == CompPassword)
                                {
                                    Console.WriteLine("Congratulation you enter :D");
                                }
                                
                            }
                        }
                    break;
                }
                
                case 2:
                { 
                    Console.Write("Create your password ");
                    string Password = Console.ReadLine();
                    Console.Write("Enter a salt ");
                    int Key = int.Parse(Console.ReadLine());
                    string LastPassword = string.Empty;
                    char[] Leter = Password.ToCharArray();
                    for (int i = 0; i < (Leter.Length); i++)
                    {
                         if (i == (Leter.Length / 2))
                         {
                             LastPassword += Key;
                             LastPassword += (char)(Leter[i]+Key);
                         }
                         else
                            LastPassword += (char)(Leter[i]+Key);
                         
                    }
                    Console.WriteLine($"your password {LastPassword}");
                    using (StreamWriter writer = new StreamWriter(FilePath, true))
                    {
                        writer.WriteLine(LastPassword);
                    }
                break;
                }   
            }
        }
    }
}
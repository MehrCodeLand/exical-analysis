using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace compiler.Mehrshad.MainClasses; 
// mehrshad asadi
// 40012341054038
public class myMainCompile
{
    private static List<string> keywords = new List<string >();
    private static List<string> symbol = new List<string>();
    private static List<string> command = new List<string>();
    private static List<string> consts = new List<string>();
    private static bool JustNumber = false;
    private static Regex rgxNumber = new Regex("^[0-9]");
    private static Regex rgxHasChar = new Regex(@"^[a-zA-Z]+$");

    
    public static void OrderingData()
    {
        keywords.Add( "var");
        keywords.Add("int");
        keywords.Add("string");
        keywords.Add("char");

        symbol.Add("+");
        symbol.Add("*");
        symbol.Add("/");
        symbol.Add("$");

        command.Add("if");
        command.Add("for");
        command.Add("foreach");
        command.Add("go");

        consts.Add("=");
        consts.Add("-");
        consts.Add("+");
        consts.Add("%");

    }

    public static void Main()
    {
        var cmd = "2000 int name = 2000 ";
        string piceCmd = "";

        OrderingData();

        foreach( var myChar in cmd)
        {
            if (myChar == ' ')
            {
                CheckString(piceCmd.Replace(" " , ""));
                piceCmd = "";
            }
            piceCmd += $"{myChar}";

        }
    }

    // if thats valabla ? use regex
    public static int IsVariable( string data )
    {
        var hasNumber = false;
        var hasChar = false;

        if( rgxNumber.IsMatch(data))
            hasNumber = true;
        if(rgxHasChar.IsMatch(data))
            hasChar = true;

        if (hasNumber && hasChar)
            return 7356;
        // its 100% varName and save data 

        else if (!hasNumber && hasChar)
            return 7356;
        // ist 100% varName and save data

        else if (!hasChar && hasNumber)
            return 8000;
        // its 100% number and numercial Var 

        return -1000;
    }


    public static int CheckString( string cmd)
    {
        if (keywords.Any(x => x == cmd))
            Console.WriteLine($"keywords - {cmd} : " + 2000);
        else if (symbol.Any(x => x == cmd))
            Console.WriteLine($"symbol - {cmd} : " + 3000);
        else if (consts.Any(x => x == cmd))
            Console.WriteLine($"consts {cmd} : " + 5000);
        else
        {
            var isVar = IsVariable(cmd);
            if (isVar == 7356)
                Console.WriteLine($"varieble - {cmd} : " + 7356);

            else if (isVar == 8000)
                Console.WriteLine($"numerical var - {cmd} : " + 8000);
            // just number 
        }

        return 100;
    }
}

public class MyVariable
{
    public int CodeId { get; set; }
    public string VarName { get; set; }
    public string Data { get; set; }
    public string DataType { get; set; }

    // string : 20
    // int : 25 
    // var : 45 
}
public static class GetRandomId
{
    public static int Get()
    {
        var rnd  = new Random();
        return rnd.Next(100 , 500 );
    }
}


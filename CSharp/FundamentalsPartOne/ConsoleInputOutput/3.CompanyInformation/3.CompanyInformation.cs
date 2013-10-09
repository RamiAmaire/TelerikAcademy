using System;

class CompanyInformation
{
    static void Main()
    {
        Console.Write("Vuvedete ime na firma= ");
        string imef = System.Convert.ToString(Console.ReadLine());
        Console.Write("Vuvedete adres na firma= ");
        string adr = System.Convert.ToString(Console.ReadLine());
        Console.Write("Vuvedete telefonen nomer na firma= ");
        int numf = System.Convert.ToInt32(Console.ReadLine());
        Console.Write("Vuvedete fax nomer na firma= ");
        int fax = System.Convert.ToInt32(Console.ReadLine());
        Console.Write("Vuvedete website na firma= ");
        string webs = System.Convert.ToString(Console.ReadLine());
        Console.Write("Vuvedete manager na firma= ");
        string manager = System.Convert.ToString(Console.ReadLine());
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(new string('-', 40));
        Console.Write("Vuvedete ime na manager= ");
        string nmanager = System.Convert.ToString(Console.ReadLine());
        Console.Write("Vuvedete familiq na manager= ");
        string fmanager = System.Convert.ToString(Console.ReadLine());
        Console.Write("Vuvedete nomer na manager= ");
        int numbm = System.Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Firm Name: {0}" + Environment.NewLine + "Firm Address: {1}" + Environment.NewLine + "Firm Number: {2}" +
            Environment.NewLine + "Firm Fax: {3}" + Environment.NewLine + "Firm Website: {4}" + Environment.NewLine + "Firm Manager: {5}"
            , imef, adr, numf, fax, webs, manager);
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Manager Name: {0}" + Environment.NewLine + "Manager FamilyName: {1}" + Environment.NewLine + "Manager Number: {2}",
            nmanager, fmanager, numbm);
    }
}

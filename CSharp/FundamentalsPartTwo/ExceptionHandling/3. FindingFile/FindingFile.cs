using System;
using System.IO;
using System.Web;
using System.Net;
using System.Security;

class FindingFile
{
    static void Main()
    {
        try
        {
            string path = @"C:\Documents and Settings\Rami\My Documents\Visual Studio 2010\Projects\ExceptionHandling\Zadacha12\bin\Debug\test.txt";
            string getPath = Path.GetDirectoryName(path);
            string value = File.ReadAllText(path);
            Console.WriteLine("File's directory is: \n {0} ", getPath);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("File test.txt contains : ");
            foreach (var item in value)
            {
                Console.Write(item);
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("There is nothing in the file ! ");
            throw;
        }
        catch (ArgumentException)
        {
            Console.WriteLine("File contains value of inapropriate format");
            throw;
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The path for file's directory is too long");
            throw;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Couldn't find file's directery");
            throw;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The given file was not found");
            throw;
        }
        catch
        {
            Console.WriteLine("The path to the file is in invalid format");
            throw;
        }

    }
}

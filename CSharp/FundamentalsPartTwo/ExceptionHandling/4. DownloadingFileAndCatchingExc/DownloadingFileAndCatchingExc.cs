using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

class DownloadingFileAndCatchingExc
{
    static void Main()
    {
        try
        {
            string path = @"C:\Documents and Settings\Rami\My Documents\Visual Studio 2010\Projects\ExceptionHandling\Zadacha13\bin\Debug\logo.jpg";
            WebClient client = new WebClient();
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));
            using (client)
            {
                byte[] arr = client.DownloadData("http://www.devbg.org/img/Logo-BASD.jpg");
                using (writer)
                {
                    foreach (var item in arr)
                    {
                        writer.Write(item);
                    }
                }
            }
        }
        catch (WebException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (UriFormatException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (FileLoadException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (FieldAccessException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsAutoComplete2
{
    class PersonalUris
    {
        
        private Uri address;
        private string favorites = @"C:\Users\zohal\Favorites\Links\Android Debugging";
        public  List<Uri> dirUris = new List<Uri>();
        public Uri CurrentUri { get
            {
                return address;
            }
            protected set 
            {
            address = value;
            } }
        public String[] convertToArray(List<Uri> uriList)
        {
            string[] the_array = uriList.Select(i => i.ToString()).ToArray();
            return the_array;
        }
        public void ProcessDirectory(string targetDirectory, ref List<Uri> dirUris)
        {
            // Process the list of files found in the directory.


            List<Uri> fileUris = new List<Uri>();
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.url");
            foreach (string fileName in fileEntries)
            {
                fileUris.Add(ProcessFile(fileName));
            }
            dirUris.AddRange(fileUris);  
            

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory, ref dirUris);
            
        }
        // Insert logic for processing found files here.
        public Uri ProcessFile(string theFile)
        {
            //Console.WriteLine("Processed file '{0}'.", theFile);
            // Add the file to the list of internet shortcut files 
            StreamReader reader = File.OpenText(theFile);
            System.String line;
            //List<Uri> favoriteUris = new List<Uri>();
            //List<Uri> currentUris = new List<Uri>();
            while ((line = reader.ReadLine()) != null)
            {
                //Go through the file, and match any URIs, and add them to a list
                Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
                //Regex r = new Regex (@"http(s) ?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");
                //Regex r = new Regex(@"http(s) ?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");
                //Regex r = new Regex(@"(((ht|f)tp(s?))\://)?(www.|[a-zA-Z].)[a-zA-Z0-9\-\.]+\.(com|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk)(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\;\?\'\\\+&amp;%\$#\=~_\-]+))*$");
                // Match the regular expression pattern against a text string.
                Match m = r.Match(line);
                Uri currentUri;
                if (m.Success)
                {
                    currentUri = new Uri(m.ToString());
                    return currentUri;
                    //m = m.NextMatch();
                }
            }
            return null;
        }
        //public void addItems(AutoCompleteStringCollection col)
        //{
        //    string favorites = @"C:\Users\zohal\Favorites";
        //    List<Uri> totalUris = new List<Uri>();
        //    if (File.Exists(favorites))
        //    {
        //        // This path is a file
        //        ProcessFile(favorites, out totalUris);
        //        col.Add(totalUris.ToString());
        //    }
        //    else if (Directory.Exists(favorites))
        //    {
        //        // This path is a directory
        //        ProcessDirectory(favorites, col);
        //        col.Add(totalUris.ToString());
        //    }
        //    else
        //    {
        //        Console.WriteLine("No file or directory to process");
        //    }

        //    col.Add(totalUris.ToString());
        //    col.Add("Abel");
        //    col.Add("Bing");
        //    col.Add("Catherine");
        //    col.Add("Varghese");
        //    col.Add("John");
        //    col.Add("Kerry");
        //}
        //public static void ProcessDirectory(string targetDirectory, AutoCompleteStringCollection col)
        //{
        //    List<Uri> favoriteUrisInCurrentDirectory = new List<Uri>();
        //    // Process the list of files found in the directory.
        //    string[] fileEntries = Directory.GetFiles(targetDirectory);
        //    foreach (string fileName in fileEntries)
        //        //if (fileName == "desktop.ini") ???
        //        //cumulativeUris.AddRange(favoriteUrisInCurrentDirectory = ProcessFile(fileName));
        //        ProcessFile(fileName, out favoriteUrisInCurrentDirectory);
        //    // Recurse into subdirectories of this directory.
        //    string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        //    foreach (string subdirectory in subdirectoryEntries)
        //        ProcessDirectory(subdirectory, col);
        //}
        //// Insert logic for processing found files here.
        //public static void ProcessFile(string theFile, out List<Uri> totalUris)
        //{
        //    Console.WriteLine("Processed file '{0}'.", theFile);
        //    // Add the file to the list of internet shortcut files 
        //    StreamReader reader = File.OpenText(theFile);
        //    System.String line;
        //    List<Uri> favoriteUris = new List<Uri>();
        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        //Go through the file, and match any URIs, and add them to a list
        //        Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
        //        //Regex r = new Regex (@"http(s) ?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");
        //        //Regex r = new Regex(@"http(s) ?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");
        //        //Regex r = new Regex(@"(((ht|f)tp(s?))\://)?(www.|[a-zA-Z].)[a-zA-Z0-9\-\.]+\.(com|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk)(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\;\?\'\\\+&amp;%\$#\=~_\-]+))*$");
        //        // Match the regular expression pattern against a text string.
        //        Match m = r.Match(line);
        //        Uri currentUri;

        //        while (m.Success)
        //        {
        //            currentUri = new Uri(m.ToString());
        //            favoriteUris.Add(currentUri);
        //            m = m.NextMatch();
        //        }
        //    }
        //    totalUris = favoriteUris;
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace IEnumerableStreamer
{
    public class FileGenerator
    {
        readonly string _location = string.Empty;
        readonly string _filename = string.Empty;

        public FileGenerator(string location = @"c:/temp/", string filename = "TestLoad.txt")
        {
            _location = location;
            _filename = filename;
        }

        public void GenerateFile(int lines)
        {
            const char d = '|'; //delim
            const string alphanum = "abcdefghijklmnopqurstuvwxyz1234567890";
            var rand = new Random();

            var sb = new StringBuilder();

            for(int i = 0; i < lines; ++i)
            {
                var thisNumber = rand.Next(1000);  //simulates quantity
                var thisDouble = rand.NextDouble() * thisNumber; //simulates prices
                var thisString = alphanum.Substring(0, thisNumber % 36); //simulates descriptions

                sb.AppendLine($"{thisNumber}{d}{thisDouble}{d}{thisString}");
            }
          
            File.WriteAllText(_location + _filename, sb.ToString());
        }
    }
}

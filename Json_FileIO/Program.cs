using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;

namespace Json_FileIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Read Data From Csv And Write Data In To Json");
            ReadCSV_WriteJsonANDReadJson_WriteCSV.ImplementCSVToJSON();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Read Data From Json And Write Data In To Csv");
            ReadCSV_WriteJsonANDReadJson_WriteCSV.ImplementJSONToCSV();
        }
    }
}
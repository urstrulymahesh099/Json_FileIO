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
    public class ReadCSV_WriteJsonANDReadJson_WriteCSV
    {

        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"E:\Bridgelabz\Json_FileIO\Json_FileIO\Utility\address.csv";
            string exportFilePath = @"E:\Bridgelabz\Json_FileIO\Json_FileIO\Utility\export.json";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from address data");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.name);
                    Console.WriteLine("\t" + addressData.email);
                    Console.WriteLine("\t" + addressData.phone);
                    Console.WriteLine("\t" + addressData.country);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n************** Now reading from csv file and write to json file **************");
                JsonSerializer serializer = new JsonSerializer();
                using(StreamWriter strem = new StreamWriter(exportFilePath))
                using(JsonWriter writer = new JsonTextWriter(strem))
                {
                    serializer.Serialize(writer, records);
                }
               
            }
        }
        public static void ImplementJSONToCSV()
        {
            string importFilePath = @"E:\Bridgelabz\Json_FileIO\Json_FileIO\Utility\address.csv";
            string exportFilePath = @"E:\Bridgelabz\Json_FileIO\Json_FileIO\Utility\export.json";
            IList<AddressData>addressData=JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(exportFilePath));
            Console.WriteLine("***********Now Reading from Json file and Write csv file*************");
            using(var writer=new StreamWriter(importFilePath))
                using(var csvImport=new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvImport.WriteRecords(addressData);
            }
        }

    }
}

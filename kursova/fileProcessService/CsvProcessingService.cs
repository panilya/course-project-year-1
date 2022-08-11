using kursova.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using System.ComponentModel;

namespace kursova.fileProcessService
{
    public class CsvProcessingService : DataProcessingService
    {
        protected override BindingList<ComputerBase> ReadData()
        {
            BindingList<ComputerBase> computers = null;

            using (var streamReader = new StreamReader("C:/Users/panil/dev/kursova/kursova/kursova/db/db.csv"))
            using (var csv = new CsvReader(streamReader, CultureInfo.CurrentCulture))
            {
                computers = new BindingList<ComputerBase>(csv.GetRecords<ComputerBase>().ToList());
            }
            return computers;
        }

        protected override void WriteData(object data)
        {
            using (var writer = new StreamWriter("C:/Users/panil/dev/kursova/kursova/kursova/db/db.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csv.WriteRecords((BindingList<ComputerBase>)data);
            }
        }
    }
}

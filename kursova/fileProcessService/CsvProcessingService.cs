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

namespace kursova.fileProcessService
{
    public class CsvProcessingService : DataProcessingService
    {
        protected override List<ComputerBase> ReadData()
        {
            var records = new List<ComputerBase>();

            using var streamReader = File.OpenText("C:/Users/panil/dev/kursova/kursova/kursova/db/db.csv");
            using (var csv = new CsvReader(streamReader, CultureInfo.CurrentCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    if (csv.GetField(10).ToLower().Equals("true") || csv.GetField(10).ToLower().Equals("false"))
                    {
                        string processorType = csv.GetField<string>(0);
                        string monitorType = csv.GetField<string>(1);
                        string graphicCardType = csv.GetField<string>(2);
                        int driveSize = csv.GetField<int>(3);
                        string keyboardType = csv.GetField<string>(4);
                        int idNumber = csv.GetField<int>(5);
                        int classRoomNumber = csv.GetField<int>(6);
                        bool isRepairing = csv.GetField<bool>(7);
                        bool isHighPerformance = csv.GetField<bool>(10);
                        records.Add(new NewComputer(processorType, monitorType, graphicCardType, driveSize, keyboardType, idNumber, classRoomNumber, isRepairing, isHighPerformance));
                    } else if (csv.GetField(8).ToLower().Equals("false") || csv.GetField(8).ToLower().Equals("false") && csv.GetField(9).ToLower().Equals("true") || csv.GetField(9).ToLower().Equals("false")) {
                        string processorType = csv.GetField<string>(0);
                        string monitorType = csv.GetField<string>(1);
                        string graphicCardType = csv.GetField<string>(2);
                        int driveSize = csv.GetField<int>(3);
                        string keyboardType = csv.GetField<string>(4);
                        int idNumber = csv.GetField<int>(5);
                        int classRoomNumber = csv.GetField<int>(6);
                        bool isRepairing = csv.GetField<bool>(7);
                        bool cdRom = csv.GetField<bool>(8);
                        bool floppy = csv.GetField<bool>(9);
                        records.Add(new OldComputer(processorType, monitorType, graphicCardType, driveSize, keyboardType, idNumber, classRoomNumber, isRepairing, cdRom, floppy));
                    } else {
                        throw new Exception("Exception while parsing .csv file");
                    }
                }
            }
            return records;
        }

        protected override void WriteData(List<ComputerBase> data)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
            };
            using (var stream = File.Open("C:/Users/panil/dev/kursova/kursova/kursova/db/db.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.NextRecord();
                foreach (var computer in data)
                {
                    if (computer is NewComputer)
                    {
                        var pc = (NewComputer)computer;
                        csv.WriteField(pc.ProcessorType);
                        csv.WriteField(pc.MonitorType);
                        csv.WriteField(pc.GraphicCardType);
                        csv.WriteField(pc.DriveSize);
                        csv.WriteField(pc.KeyboardType);
                        csv.WriteField(pc.IdNumber);
                        csv.WriteField(pc.ClassRoomNumber);
                        csv.WriteField(pc.IsRepairing);
                        csv.WriteField("null");
                        csv.WriteField("null");
                        csv.WriteField(pc.IsHighPerformance);
                        csv.NextRecord();
                    } else if (computer is OldComputer) {
                        var pc = (OldComputer)computer;
                        csv.WriteField(pc.ProcessorType);
                        csv.WriteField(pc.MonitorType);
                        csv.WriteField(pc.GraphicCardType);
                        csv.WriteField(pc.DriveSize);
                        csv.WriteField(pc.KeyboardType);
                        csv.WriteField(pc.IdNumber);
                        csv.WriteField(pc.ClassRoomNumber);
                        csv.WriteField(pc.IsRepairing);
                        csv.WriteField(pc.CdRom);
                        csv.WriteField(pc.Floppy);
                        csv.WriteField("null");
                        csv.NextRecord();
                    }
                }
            }
        }
    }
}

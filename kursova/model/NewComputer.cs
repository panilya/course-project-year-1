using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursova.model
{
    public class NewComputer : ComputerBase
    {

        private bool isHighPerformance;

        public NewComputer(string processorType, string monitorType, string graphicCardType, int driveSize, string keyboardType, int idNumber, int classRoomNumber, bool isHighPerformance) : base(processorType, monitorType, graphicCardType, driveSize, keyboardType, idNumber, classRoomNumber)
        {
           this.isHighPerformance = isHighPerformance;
        }

        public NewComputer(string processorType, string monitorType, string graphicCardType, int driveSize, string keyboardType, int idNumber, int classRoomNumber, bool isRepairing, bool isHighPerformance) : base(processorType, monitorType, graphicCardType, driveSize, keyboardType, idNumber, classRoomNumber, isRepairing)
        {
            this.isHighPerformance = isHighPerformance;
        }

        public bool IsHighPerformance { get => isHighPerformance; set => isHighPerformance = value; }

        public override string? ToString()
        {
            return "processorType: " + base.ProcessorType +
                ". monitorType: " + base.MonitorType +
                ". graphicCardType: " + base.GraphicCardType +
                ". driveSize: " + base.DriveSize.ToString() +
                ". keyboardType: " + base.KeyboardType +
                ". idNumber: " + base.IdNumber.ToString() +
                ". classRoomNumber: " + base.ClassRoomNumber.ToString() +
                ". isRepairing: " + base.IsRepairing.ToString() + 
                ". isHighPerformance: " + isHighPerformance.ToString();
        }
    }
}

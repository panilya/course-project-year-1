using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursova.model
{
    public class OldComputer : ComputerBase
    {

        private bool cdRom;
        private bool floppy;

        public OldComputer()
        {
        }

        public OldComputer(string processorType, string monitorType, string graphicCardType, int driveSize, string keyboardType, int idNumber, int classRoomNumber, bool cdRom, bool floppy) : base(processorType, monitorType, graphicCardType, driveSize, keyboardType, idNumber, classRoomNumber)
        {
            this.cdRom = cdRom;
            this.floppy = floppy;
        }

        public OldComputer(string processorType, string monitorType, string graphicCardType, int driveSize, string keyboardType, int idNumber, int classRoomNumber, bool isRepairing, bool cdRom, bool floppy) : base(processorType, monitorType, graphicCardType, driveSize, keyboardType, idNumber, classRoomNumber, isRepairing)
        {
            this.cdRom = cdRom;
            this.floppy = floppy;
        }

        public bool CdRom { get => cdRom; set => cdRom = value; }

        public bool Floppy { get => floppy; set => floppy = value; }

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
                ". cdRom: " + cdRom.ToString() + 
                ". floppy: " + floppy.ToString();
        }
    }
}

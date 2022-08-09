using System;

namespace kursova.model
{
    public abstract class ComputerBase : IComputer
    {

        private string processorType;
        private string monitorType;
        private string graphicCardType;
        private int driveSize;
        private string keyboardType;
        private int idNumber;
        private int classRoomNumber;
        private bool isRepairing;

        public ComputerBase()
        {
        }

        public ComputerBase(string processorType, string monitorType, string graphicCardType, int driveSize, string keyboardType, int idNumber, int classRoomNumber)
        {
            this.processorType = processorType;
            this.monitorType = monitorType;
            this.graphicCardType = graphicCardType;
            this.driveSize = driveSize;
            this.keyboardType = keyboardType;
            this.idNumber = idNumber;
            this.classRoomNumber = classRoomNumber;
            this.isRepairing = false;
        }

        public ComputerBase(string processorType, string monitorType, string graphicCardType, int driveSize, string keyboardType, int idNumber, int classRoomNumber, bool isRepairing)
        {
            this.processorType = processorType ?? throw new ArgumentNullException(nameof(processorType));
            this.monitorType = monitorType ?? throw new ArgumentNullException(nameof(monitorType));
            this.graphicCardType = graphicCardType ?? throw new ArgumentNullException(nameof(graphicCardType));
            this.driveSize = driveSize;
            this.keyboardType = keyboardType ?? throw new ArgumentNullException(nameof(keyboardType));
            this.idNumber = idNumber;
            this.classRoomNumber = classRoomNumber;
            this.isRepairing = isRepairing;
        }

        public string ProcessorType { get => processorType; set => processorType = value; }
        public string MonitorType { get => monitorType; set => monitorType = value; }
        public string GraphicCardType { get => graphicCardType; set => graphicCardType = value; }
        public int DriveSize { get => driveSize; set => driveSize = value; }
        public string KeyboardType { get => keyboardType; set => keyboardType = value; }
        public int IdNumber { get => idNumber; set => idNumber = value; }
        public int ClassRoomNumber { get => classRoomNumber; set => classRoomNumber = value; }
        public bool IsRepairing { get => isRepairing; set => isRepairing = value; }

        public override string? ToString()
        {
            return "processorType: " + processorType +
                ". monitorType: " + monitorType + 
                ". graphicCardType: " + graphicCardType +
                ". driveSize: " + driveSize.ToString() +
                ". keyboardType: " + keyboardType +
                ". idNumber: " + idNumber.ToString() +
                ". classRoomNumber: " + classRoomNumber.ToString() + 
                ". isRepairing: " + isRepairing.ToString();
        }
    }
}
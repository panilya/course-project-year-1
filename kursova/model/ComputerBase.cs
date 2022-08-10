using System;
using System.ComponentModel;

namespace kursova.model
{
    public class ComputerBase : INotifyPropertyChanged
    {

        private string processorType;
        private string monitorType;
        private string graphicCardType;
        private int driveSize;
        private string keyboardType;
        private int idNumber;
        private int classRoomNumber;
        private bool isRepairing;
        private bool cdRom;
        private bool floppy;

        public ComputerBase()
        {
        }

        public ComputerBase(string processorType, string monitorType, string graphicCardType, int driveSize, string keyboardType, int idNumber, int classRoomNumber, bool isRepairing, bool cdRom, bool floppy)
        {
            this.processorType = processorType;
            this.monitorType = monitorType;
            this.graphicCardType = graphicCardType;
            this.driveSize = driveSize;
            this.keyboardType = keyboardType;
            this.idNumber = idNumber;
            this.classRoomNumber = classRoomNumber;
            this.isRepairing = isRepairing;
            this.cdRom = cdRom;
            this.floppy = floppy;
        }

        public string ProcessorType 
        {
            get { return processorType; }
            set 
            {
                if (processorType == value)
                    return;
                processorType = value;
                OnPropertyChanged("ProcessorType");
            }
        }
        public string MonitorType
        {
            get { return monitorType; }
            set
            {
                if (monitorType == value)
                    return;
                monitorType = value;
                OnPropertyChanged("MonitorType");
            }
        }
        public string GraphicCardType
        {
            get { return graphicCardType; }
            set
            {
                if (graphicCardType == value)
                    return;
                graphicCardType = value;
                OnPropertyChanged("GraphicCardType");
            }
        }
        public int DriveSize
        {
            get { return driveSize; }
            set
            {
                if (driveSize == value)
                    return;
                driveSize = value;
                OnPropertyChanged("DriveSize");
            }
        }
        public string KeyboardType
        {
            get { return keyboardType; }
            set
            {
                if (keyboardType == value)
                    return;
                keyboardType = value;
                OnPropertyChanged("KeyboardType");
            }
        }
        public int IdNumber
        {
            get { return idNumber; }
            set
            {
                if (idNumber == value)
                    return;
                idNumber = value;
                OnPropertyChanged("IdNumber");
            }
        }
        public int ClassRoomNumber
        {
            get { return classRoomNumber; }
            set
            {
                if (classRoomNumber == value)
                    return;
                classRoomNumber = value;
                OnPropertyChanged("ClassRoomNumber");
            }
        }
        public bool IsRepairing
        {
            get { return isRepairing; }
            set
            {
                if (isRepairing == value)
                    return;
                isRepairing = value;
                OnPropertyChanged("IsRepairing");
            }
        }
        public bool CdRom
        {
            get { return cdRom; }
            set
            {
                if (cdRom == value)
                    return;
                cdRom = value;
                OnPropertyChanged("CdRom");
            }
        }
        public bool Floppy
        {
            get { return floppy; }
            set
            {
                if (floppy == value)
                    return;
                floppy = value;
                OnPropertyChanged("Floopy");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string? ToString()
        {
            return "processorType: " + processorType +
                ". monitorType: " + monitorType + 
                ". graphicCardType: " + graphicCardType +
                ". driveSize: " + driveSize.ToString() +
                ". keyboardType: " + keyboardType +
                ". idNumber: " + idNumber.ToString() +
                ". classRoomNumber: " + classRoomNumber.ToString() + 
                ". isRepairing: " + isRepairing.ToString() +
                ". cdRom: " + cdRom.ToString() +
                ". floppy: " + floppy.ToString();
        }
    }
}
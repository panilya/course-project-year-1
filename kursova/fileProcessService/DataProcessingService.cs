using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursova.model;

namespace kursova.fileProcessService
{
    public abstract class DataProcessingService
    {

        public BindingList<ComputerBase> ReadFromDatabase()
        {
            return ReadData();
        }

        public void WriteToDatabase(object data)
        {
            WriteData(data);
        }

        protected abstract BindingList<ComputerBase> ReadData();

        protected abstract void WriteData(object data);

    }
}

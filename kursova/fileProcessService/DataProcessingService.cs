using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursova.model;

namespace kursova.fileProcessService
{
    public abstract class DataProcessingService
    {

        public List<ComputerBase> ReadFromDatabase()
        {
            return ReadData();
        }

        public void WriteToDatabase(List<ComputerBase> data)
        {
            WriteData(data);
        }

        protected abstract List<ComputerBase> ReadData();

        protected abstract void WriteData(List<ComputerBase> data);

    }
}

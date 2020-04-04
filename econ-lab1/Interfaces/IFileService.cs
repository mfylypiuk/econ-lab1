using IOData;
using System;
using System.Collections.Generic;
using System.Text;

namespace econ_lab1.Interfaces
{
    interface IFileService
    {
        InputData Open(string filename);
        void Save(string filename, OutputData instance);
    }
}

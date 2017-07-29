using SportsViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsViewer.FileMagr
{
    interface FileLoader
    {
        Team loadFile(String filePath);  
    }
}

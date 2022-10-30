using System.IO;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Models
{
    public class Executable : FileStreamModel
    {
        public Executable(BinaryReader execBinaryFileStream) : base(execBinaryFileStream)
        {

        }
    }
}
using System.IO;

namespace indiana_jones_desktop_adventures_ripper.Models.Base
{
    public class ExeBlock
    {
        public BinaryReader BinaryReader { get; }

        public ExeBlock(BinaryReader binaryReader)
        {
            BinaryReader = binaryReader;
        }
    }
}
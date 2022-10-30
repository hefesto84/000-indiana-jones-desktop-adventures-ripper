using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections
{
    public abstract class Section
    {
        public abstract string Tag { get; }

        protected MemoryStream Ms;
        protected BinaryReader Br;

        public virtual void Parse(DataBlock dataBlock)
        {
            Ms = new MemoryStream(dataBlock.Data);
            Br = new BinaryReader(Ms);
        }
    }
}
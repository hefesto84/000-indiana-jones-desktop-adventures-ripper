using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.Base
{
    public abstract class Data
    {
        public abstract string Tag { get; }

        protected MemoryStream MS;
        protected BinaryReader BR;

        public virtual void Parse(Section section)
        {
            MS = new MemoryStream(section.Data);
            BR = new BinaryReader(MS);
        }
    }
}
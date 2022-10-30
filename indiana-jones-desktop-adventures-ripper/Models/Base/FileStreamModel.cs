using System.IO;

namespace indiana_jones_desktop_adventures_ripper.Models.Base
{
    public abstract class FileStreamModel
    {
        protected BinaryReader Fs;

        public FileStreamModel(BinaryReader fs)
        {
            Fs = fs;
        }
    }
}
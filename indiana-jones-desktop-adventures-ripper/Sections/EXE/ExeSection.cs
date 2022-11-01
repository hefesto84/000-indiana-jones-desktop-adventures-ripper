using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.EXE
{
    public class ExeSection
    {
        private const int OffsetExeWav = 0x3FA60;
        private const int OffsetExePal = 0x36656;
        
        public string Tag => "EXE";

        public void Parse(ExeBlock exeBlock, out Palette palette)
        {
            ParsePalette(exeBlock.BinaryReader, out palette);
            ParseWav(exeBlock.BinaryReader);
        }

        private void ParsePalette(BinaryReader binaryReader, out Palette palette)
        {
            palette = new Palette(binaryReader).Extract(OffsetExePal);
        }

        private void ParseWav(BinaryReader binaryReader)
        {
            var wavData = new Wav(binaryReader);
            wavData.Extract(OffsetExeWav);
        }
    }
}
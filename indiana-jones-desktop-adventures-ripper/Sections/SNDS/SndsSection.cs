using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.SNDS
{
    public class SndsSection : Section
    {
        public override string Tag => "SNDS";

        public override void Parse(DataBlock dataBlock)
        {
            base.Parse(dataBlock);
            
            var d = Br.ReadUInt16();

            while (Ms.Position != dataBlock.Data.Length)
            {
                var path = new string(Br.ReadChars(Br.ReadUInt16()));
                Console.WriteLine($"\\__SNDS: {path}");
            }
        }
    }
}
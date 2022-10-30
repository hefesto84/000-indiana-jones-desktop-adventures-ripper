using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.SNDS
{
    public class SndsData : Base.Data
    {
        public override string Tag => "SNDS";

        public override void Parse(Section section)
        {
            base.Parse(section);
            
            var d = BR.ReadUInt16();

            while (MS.Position != section.Data.Length)
            {
                var path = new string(BR.ReadChars(BR.ReadUInt16()));
                Console.WriteLine($"\\__SNDS: {path}");
            }
        }
    }
}
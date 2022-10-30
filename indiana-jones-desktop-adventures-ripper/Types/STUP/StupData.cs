using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.STUP
{
    public class StupData : Base.Data
    {
        public override string Tag => "STUP";

        public override void Parse(Section section)
        {
            base.Parse(section);
            Console.WriteLine($"Parsing: {Tag}");
        }
    }
}
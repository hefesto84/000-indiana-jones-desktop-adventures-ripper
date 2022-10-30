using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.STUP
{
    public class StupSection : Section
    {
        public override string Tag => "STUP";

        public override void Parse(DataBlock dataBlock)
        {
            base.Parse(dataBlock);
            Console.WriteLine($"Parsing: {Tag}");
        }
    }
}
using System;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.CHAR;

public class CharSection : Section
{
    public override string Tag => "CHAR";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        var padding = Br.ReadInt16();
        var k = 0;
        while (Ms.Position != dataBlock.Data.Length)
        {
            var ichad = new string(Br.ReadChars(5));
            Br.ReadBytes(3);
            var ichadName = new string(Br.ReadChars(16));
            var unknown = Br.ReadBytes(54);
            //var ichadData = Br.ReadBytes(73);
            Console.WriteLine($"{Tag}-{k}: {ichadName}");
            k++;
            //Br.ReadBytes(dataBlock.Data.Length);
        }
    }
}
using System;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.CHWP;

public class ChwpSection : Section
{
    public override string Tag => "CHWP";
    private const int ChwpMetadataSize = 8;
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        var unknown = Br.ReadBytes(ChwpMetadataSize);

        var entries = 0;
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            var unknown1 = Br.ReadInt16();
            var unknown2 = Br.ReadInt16();
            var unknown3 = Br.ReadInt16();
            
            Console.WriteLine($"unknown1: {unknown1} , unknown2: {unknown2}, unknown3 : {unknown3}");
            entries++;
        }
        
        Console.WriteLine($"CHWP Entries: {entries}");
    }
}
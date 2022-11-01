using System;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.ZAUX;

public class ZAuxSection : Section
{
    public override string Tag => "ZAUX";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        Console.WriteLine($"Parsing: {Tag}");

        var k = 0;
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            var izax = new string(Br.ReadChars(4));
            var size = Br.ReadInt16();
            var izaxData = Br.ReadBytes(size - 6);

            Console.WriteLine($"IZAX Size {size}");

            k++;
        }
        
        Console.WriteLine($"IZAX structs: {k}");
        
    }
}
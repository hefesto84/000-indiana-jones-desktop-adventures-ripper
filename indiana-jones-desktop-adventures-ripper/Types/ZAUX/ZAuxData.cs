using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.ZAUX;

public class ZAuxData : Base.Data
{
    public override string Tag => "ZAUX";
    
    public override void Parse(Section section)
    {
        base.Parse(section);
        
        Console.WriteLine($"Parsing: {Tag}");

        var k = 0;
        
        while (MS.Position != section.Data.Length)
        {
            var izax = new string(BR.ReadChars(4));
            var size = BR.ReadInt16();
            var izaxData = BR.ReadBytes(size - 6);
            
            Console.WriteLine($"IZAX Size {size}");
            k++;
        }
        
        Console.WriteLine($"IZAX structs: {k}");
        
    }
}
using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.ZAX2;

public class Zax2Data : Base.Data
{
    public override string Tag => "ZAX2";
    
    public override void Parse(Section section)
    {
        base.Parse(section);
        
        Console.WriteLine($"Parsing: {Tag}");

        var k = 0;
        
        while (MS.Position != section.Data.Length)
        {
            var izx2 = new string(BR.ReadChars(4));
            var size = BR.ReadInt16();
            var izx2Data = BR.ReadBytes(size - 6);
            
            Console.WriteLine($"IZX2 Size {size}");
            k++;
        }
        
        Console.WriteLine($"IZX2 structs: {k}");
    }
    
}
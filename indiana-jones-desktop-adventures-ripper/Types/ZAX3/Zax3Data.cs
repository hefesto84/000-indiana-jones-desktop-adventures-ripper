using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.ZAX3;

public class Zax3Data : Base.Data
{
    public override string Tag => "ZAX3";
    
    public override void Parse(Section section)
    {
        base.Parse(section);
        
        Console.WriteLine($"Parsing: {Tag}");

        var k = 0;
        
        while (MS.Position != section.Data.Length)
        {
            var izx3 = new string(BR.ReadChars(4));
            var size = BR.ReadInt16();
            var izx3Data = BR.ReadBytes(size - 6);
            
            Console.WriteLine($"IZX3 Size {size}");
            k++;
        }
        
        Console.WriteLine($"IZX3 structs: {k}");
    }
}
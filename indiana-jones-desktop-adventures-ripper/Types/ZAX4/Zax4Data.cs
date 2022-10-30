using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.ZAX4;

public class Zax4Data : Base.Data
{
    public override string Tag => "ZAX4";
    
    public override void Parse(Section section)
    {
        base.Parse(section);
        
        Console.WriteLine($"Parsing: {Tag}");

        var k = 0;
        
        while (MS.Position != section.Data.Length)
        {
            var izx4 = new string(BR.ReadChars(4));
            var unknown = BR.ReadBytes(6);
            k++;
        }
        
        Console.WriteLine($"IZX4 structs: {k}");
    }
}
using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.ZAX4;

public class Zax4Data : Section
{
    public override string Tag => "ZAX4";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        Console.WriteLine($"Parsing: {Tag}");

        var k = 0;
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            var izx4 = new string(Br.ReadChars(4));
            var unknown = Br.ReadBytes(6);
            
            if (k == 108)
            {
                Console.WriteLine($"IZX4 Size");
            }
            
            k++;
        }
        
        Console.WriteLine($"IZX4 structs: {k}");
    }
}
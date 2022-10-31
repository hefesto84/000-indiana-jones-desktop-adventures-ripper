using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.ZAX2;

public class Zax2Data : Section
{
    public override string Tag => "ZAX2";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        Console.WriteLine($"Parsing: {Tag}");

        var k = 0;
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            var izx2 = new string(Br.ReadChars(4));
            var size = Br.ReadInt16();
            var izx2Data = Br.ReadBytes(size - 6);

            if (k == 108)
            {
                Console.WriteLine($"IZX2 Size {size}");
            }

            k++;
        }
        
        Console.WriteLine($"IZX2 structs: {k}");
    }
    
}
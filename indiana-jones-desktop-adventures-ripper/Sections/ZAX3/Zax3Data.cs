using System;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.ZAX3;

public class Zax3Data : Section
{
    public override string Tag => "ZAX3";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        Console.WriteLine($"Parsing: {Tag}");

        var k = 0;
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            var izx3 = new string(Br.ReadChars(4));
            var size = Br.ReadInt16();
            var izx3Data = Br.ReadBytes(size - 6);

            Console.WriteLine($"IZX3 Size {size}");
            k++;
        }
        
        Console.WriteLine($"IZX3 structs: {k}");
    }
}
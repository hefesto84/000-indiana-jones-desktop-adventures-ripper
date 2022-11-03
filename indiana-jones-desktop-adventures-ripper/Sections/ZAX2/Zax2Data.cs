using System;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

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

            //Console.WriteLine($"IZX2 Size {size}");
            if (k == 333)
            {
                File.WriteAllBytes("izax2-aux.dat",izx2Data);
            }
            k++;
        }
        
        Console.WriteLine($"IZX2 structs: {k}");
    }
    
}
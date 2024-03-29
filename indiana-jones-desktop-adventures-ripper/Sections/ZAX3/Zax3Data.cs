using System;
using System.IO;
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
            var size = Br.ReadInt32();
            var numItems = Br.ReadInt16();
           
            Console.WriteLine($"IZX3 Map id: {k} - Size {size} : num items: {numItems}");

            if (numItems != 0)
            {
                for (var i = 0; i < numItems; i++)
                {
                    var itemId = Br.ReadInt16();
                    Console.WriteLine($"\\_{itemId}");
                }
            }

            
            /*
            var izx3 = new string(Br.ReadChars(4));
            var size = Br.ReadInt16();
            var izx3Data = Br.ReadBytes(size - 6);

            //Console.WriteLine($"IZX3 Size {size}");
            
            if (k == 103)
            {
                File.WriteAllBytes("izax3-aux.dat",izx3Data);
            }
            */
            k++;
        }
        
        Console.WriteLine($"IZX3 structs: {k}");
    }
}
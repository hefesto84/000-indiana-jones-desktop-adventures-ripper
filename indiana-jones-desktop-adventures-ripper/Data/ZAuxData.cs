using System;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Data.Base;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Data;

public class ZAuxData : IData
{
    public static string Tag => "ZAUX";
    
    public void Parse(Section section)
    {
        Console.WriteLine($"Parsing: {Tag}");
        
        var ms = new MemoryStream(section.Data);
        var br = new BinaryReader(ms);
        
        while (ms.Position != section.Data.Length)
        {
            var izax = new string(br.ReadChars(4));
            var size = br.ReadInt16();
            var izaxData = br.ReadBytes(size - 6);
            
            Console.WriteLine($"IZAX Size {size}");
        }
    }
}
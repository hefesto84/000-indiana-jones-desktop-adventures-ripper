using System;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Data.Base;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Data;

public class Zax4Data : IData
{
    public static string Tag => "ZAX4";
    
    public void Parse(Section section)
    {
        Console.WriteLine($"Parsing: {Tag}");
        
        var ms = new MemoryStream(section.Data);
        var br = new BinaryReader(ms);

        while (ms.Position != section.Data.Length)
        {
            br.ReadBytes(section.Data.Length);
        }
        //var size = br.ReadInt16();
    }
}
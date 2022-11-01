using System;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.PNAM;

public class PnamSection : Section
{
    public override string Tag => "PNAM";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        var val = Br.ReadInt16();
        
        Console.WriteLine($"PNAM entries: {val}");
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            var name = new string(Br.ReadChars(16));
            Console.WriteLine($"PNAM Name: {name}");
        }
    }
}
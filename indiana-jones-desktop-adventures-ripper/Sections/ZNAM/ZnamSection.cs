using System;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.ZNAM;

public class ZnamSection : Section
{
    public override string Tag => "ZNAM";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        //var val = Br.ReadBytes(6);
        
        //Console.WriteLine($"{Tag} entries: {val}");
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            Br.ReadBytes(dataBlock.Data.Length);
            //Console.WriteLine($"{Tag} Entry : {new string(Br.ReadChars(16))}");
        }
    }
}
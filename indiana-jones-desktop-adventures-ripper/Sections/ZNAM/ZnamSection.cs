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

        //var size = Br.ReadInt32();
        var offset = Br.ReadInt16();

        //var data = new string(Br.ReadChars(4));
        //var val = Br.ReadBytes(6);
        
        //Console.WriteLine($"{Tag} entries: {val}");

        var k = 0;
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            //var znamData = new string(Br.ReadChars(12));
            //Br.ReadBytes(dataBlock.Data.Length);
            //Console.WriteLine($"{Tag} Entry : {new string(Br.ReadChars(10))}");
            //var data = Br.ReadBytes(10);
            var name = Br.ReadChars(9);
            Br.ReadBytes(9);
            Console.WriteLine($"{Tag} Entry : {new string(name)}");
            k++;
        }
        
        Console.WriteLine($"{Tag} entries: {k}");
    }
}
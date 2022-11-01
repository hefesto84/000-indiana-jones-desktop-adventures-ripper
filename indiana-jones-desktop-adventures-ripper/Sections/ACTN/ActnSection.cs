using System;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.ACTN;

public class ActnSection : Section
{
    public override string Tag => "ACTN";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        var unk = Br.ReadInt32();
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            Br.ReadBytes(dataBlock.Data.Length);
            //var iact = new string(Br.ReadChars(4));
            //Console.WriteLine($"Parsing ACTN: {dataBlock.Data.Length}");
        }
        //while (Ms.Position != dataBlock.Data.Length)
        //{
        //var unk = Br.ReadInt32();
            //var iact = new string(Br.ReadChars(4));   
            
            //var iact2 = new string(Br.ReadChars(4));
            
            //var data = Br.ReadBytes(50);
            //var iact3 = new string(Br.ReadChars(4));
            //Console.WriteLine($"Parsing ACTN: {dataBlock.Data.Length}");
            //    Br.ReadBytes(dataBlock.Data.Length);
            //}
    }
}
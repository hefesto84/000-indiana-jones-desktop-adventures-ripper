using System;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

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
        }
        
        // IACT
        // 2 bytes -> X coordinate
        // 2 bytes -> Y coordinate
        // 6 byes -> unknown
        // 2 bytes -> size of Message
        // N -> bytes of message from pnj
    }
}
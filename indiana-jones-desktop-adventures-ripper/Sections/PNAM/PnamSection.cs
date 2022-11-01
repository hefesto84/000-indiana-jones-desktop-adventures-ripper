using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.PNAM;

public class PnamSection : Section
{
    public override string Tag => "PNAM";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            Br.ReadBytes(dataBlock.Data.Length);
        }
    }
}
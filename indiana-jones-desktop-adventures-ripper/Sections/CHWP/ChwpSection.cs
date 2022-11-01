using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.CHWP;

public class ChwpSection : Section
{
    public override string Tag => "CHWP";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            Br.ReadBytes(dataBlock.Data.Length);
        }
    }
}
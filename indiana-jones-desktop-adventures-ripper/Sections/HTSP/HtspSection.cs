using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.HTSP;

public class HtspSection : Section
{
    public override string Tag => "HTSP";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            Br.ReadBytes(dataBlock.Data.Length);
        }
    }
}
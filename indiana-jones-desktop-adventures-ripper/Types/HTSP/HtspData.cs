using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.HTSP;

public class HtspData : Base.Data
{
    public override string Tag => "HTSP";
    
    public override void Parse(Section section)
    {
        base.Parse(section);
        
        while (MS.Position != section.Data.Length)
        {
            BR.ReadBytes(section.Data.Length);
        }
    }
}
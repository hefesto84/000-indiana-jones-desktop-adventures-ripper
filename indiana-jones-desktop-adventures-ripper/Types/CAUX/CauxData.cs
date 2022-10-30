using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.CAUX;

public class CauxData : Base.Data
{
    public override string Tag => "CAUX";
    
    public override void Parse(Section section)
    {
        base.Parse(section);
        
        while (MS.Position != section.Data.Length)
        {
            BR.ReadBytes(section.Data.Length);
        }
    }
}
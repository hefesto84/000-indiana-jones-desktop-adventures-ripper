using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.PUZ2;

public class Puz2Data : Base.Data
{
    public override string Tag => "PUZ2";
    
    public override void Parse(Section section)
    {
        base.Parse(section);
        
        while (MS.Position != section.Data.Length)
        {
            BR.ReadBytes(section.Data.Length);
        }
    }
}
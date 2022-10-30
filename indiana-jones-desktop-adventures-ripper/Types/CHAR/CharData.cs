using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.CHAR;

public class CharData : Base.Data
{
    public override string Tag => "CHAR";
    
    public override void Parse(Section section)
    {
        base.Parse(section);

        while (MS.Position != section.Data.Length)
        {
            BR.ReadBytes(section.Data.Length);
        }
    }
}
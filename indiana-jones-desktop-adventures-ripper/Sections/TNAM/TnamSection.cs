using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.TNAM;

public class TnamSection : Section
{
    public override string Tag => "TNAM";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        while (Ms.Position != dataBlock.Data.Length)
        {
            Br.ReadBytes(dataBlock.Data.Length);
        }
    }
}
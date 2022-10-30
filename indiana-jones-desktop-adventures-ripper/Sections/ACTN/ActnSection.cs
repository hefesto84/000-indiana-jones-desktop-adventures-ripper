using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.ACTN;

public class ActnSection : Section
{
    public override string Tag => "ACTN";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        while (Ms.Position != dataBlock.Data.Length)
        {
            Br.ReadBytes(dataBlock.Data.Length);
        }
    }
}
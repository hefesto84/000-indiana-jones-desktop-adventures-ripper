using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Sections.PUZ2;

public class Puz2Data : Section
{
    public override string Tag => "PUZ2";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            Br.ReadBytes(dataBlock.Data.Length);
        }
    }
}
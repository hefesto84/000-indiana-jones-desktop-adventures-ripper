using System;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.TNAM;

public class TnamSection : Section
{
    public override string Tag => "TNAM";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        while (Ms.Position != dataBlock.Data.Length)
        {
            var id = Br.ReadInt16();
            var name = new string(Br.ReadChars(16));
            Console.WriteLine($"TNAM: ID: {id} Name: {name}");
        }
    }
}
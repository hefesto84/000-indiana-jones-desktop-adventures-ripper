using System;
using System.IO;
using System.Text;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;

namespace indiana_jones_desktop_adventures_ripper.Sections.ZNAM;

public class ZnamSection : Section
{
    public override string Tag => "ZNAM";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        while (Ms.Position != dataBlock.Data.Length)
        {
            var data = Br.ReadBytes(18);
            ParseZnamData(data);
        }
    }

    private void ParseZnamData(byte[] znamData)
    {
        var ms = new MemoryStream(znamData);
        var br = new BinaryReader(ms);
        
        var b = br.ReadInt16(); // MAP ID!

        if (b == -1) return;

        var data = br.ReadBytes(16);

        var i = 0;
        
        while (data[i] != 0) { i++; }

        var name = Encoding.UTF8.GetString(data, 0, i);
        
        Console.WriteLine($"{Tag} Entry: {b} with data: {name}");
    }
}
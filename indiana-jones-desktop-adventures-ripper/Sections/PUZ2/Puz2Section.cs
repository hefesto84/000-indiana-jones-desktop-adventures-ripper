using System;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;
using Microsoft.VisualBasic;

namespace indiana_jones_desktop_adventures_ripper.Sections.PUZ2;

public class Puz2Section : Section
{
    public override string Tag => "PUZ2";
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        var unknown = Br.ReadInt16();

        var k = 0;
        
        while (Ms.Position != dataBlock.Data.Length)
        {
            var ipuz = new string(Br.ReadChars(4));
            var size = Br.ReadInt32();
            var data = Br.ReadBytes(size+2);
           
            ParsePuzSection(data, k);    
            
            
            k++;
        }
        
        Console.WriteLine($"PUZ Entries: {k}");
    }

    private void ParsePuzSection(byte[] data, int k)
    {
        var ms = new MemoryStream(data);
        var br = new BinaryReader(ms);

        //br.ReadBytes(12);
        //var text = new string(br.ReadChars(data.Length));
        //Console.WriteLine($"IPUZ-{k} Size: {data.Length} Text: {text}");
    }
}
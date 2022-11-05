using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
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
        ParsePuzDialog(data, k);
        //br.ReadBytes(12);
        //var text = new string(br.ReadChars(data.Length));
    }

    private void ParsePuzDialog(byte[] payload, int k)
    {
        var ms = new MemoryStream(payload);
        var br = new BinaryReader(ms);


        var dialogs = new List<string>();
        
        br.ReadBytes(10); // Unknown payload
        
        while (br.BaseStream.Position != payload.Length)
        {
            var size = br.ReadInt16();

            if (size !=0)
            {
                var dialog = new string(br.ReadChars(size));
                dialogs.Add(new string(dialog));
            }
        }

        Console.WriteLine($"IPUZ-{k} Size: {payload.Length} Dialogs: {dialogs.Count}");
        
        for (var i = 0; i < dialogs.Count; i++)
        {
            Console.WriteLine($"==> {dialogs[i]}");
        }
    }
}
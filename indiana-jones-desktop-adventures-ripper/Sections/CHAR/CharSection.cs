using System;
using System.Collections.Generic;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;
using indiana_jones_desktop_adventures_ripper.Services;

namespace indiana_jones_desktop_adventures_ripper.Sections.CHAR;

public class CharSection : Section
{
    public override string Tag => "CHAR";
    
    private SpriteService _spriteService;
        
    public CharSection(SpriteService spriteService)
    {
        _spriteService = spriteService;
    }
    
    public override void Parse(DataBlock dataBlock)
    {
        base.Parse(dataBlock);

        var padding = Br.ReadInt16();
        var k = 0;
        while (Ms.Position != dataBlock.Data.Length)
        {
            var ichad = new string(Br.ReadChars(5));
            Br.ReadBytes(3);
            var ichadName = new string(Br.ReadChars(16));
            var unknown1 = Br.ReadInt16();
            var unknown2 = Br.ReadInt16();

            var tileIds = new List<int>();
            
            for (var i = 0; i < 25; i++)
            {
                var tileId = Br.ReadInt16();
                
                if(tileId==-1) continue;
                
                tileIds.Add(tileId);
            }
            
            _spriteService.BuildAnimation(new Anim
            {
                Id = ichadName.Trim(),
                Tiles = tileIds.ToArray()
            });
            
            Console.WriteLine($"{Tag}-{k}: {ichadName} - {tileIds[tileIds.Count-1]}");
            
            k++;
        }
    }
}
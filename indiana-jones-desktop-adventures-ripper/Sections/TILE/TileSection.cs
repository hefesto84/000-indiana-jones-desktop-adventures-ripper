using System;
using System.Collections.Generic;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace indiana_jones_desktop_adventures_ripper.Sections.TILE
{
    public class TileSection : Section
    {
        public override string Tag => "TILE";

        private readonly Palette _palette;
        private Dictionary<string, Image> _tiles;
        private const int SpriteW = 32;
        private const int SpriteH = 32;
        private const string SpritesFolder = "Tiles/";
        private const string SpritesheetFolder = "Spritesheet/";

        private readonly SpriteService _spriteService;
        
        public TileSection(Palette palette, SpriteService spriteService)
        {
            _palette = palette;
            _spriteService = spriteService;
        }

        public override void Parse(DataBlock dataBlock)
        {
            base.Parse(dataBlock);
  
            if (Directory.Exists(SpritesFolder)) Directory.Delete(SpritesFolder, true);
            if (Directory.Exists(SpritesheetFolder)) Directory.Delete(SpritesheetFolder, true);

            Directory.CreateDirectory(SpritesFolder);
            Directory.CreateDirectory(SpritesheetFolder);

            var tileIndex = 0;
            
            while (Ms.Position != dataBlock.Data.Length)
            {
                var flags = Br.ReadUInt32();
                var tileData = Br.ReadBytes((int)1024);

                _spriteService.BuildTile(tileData, tileIndex, _palette);

                tileIndex++;
            }
            
            _spriteService.BuildSpritesheet();
        }
    }
}
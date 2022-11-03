using System;
using System.Collections.Generic;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Sections.CHAR;
using indiana_jones_desktop_adventures_ripper.Sections.ZONE;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace indiana_jones_desktop_adventures_ripper.Services;

public class SpriteService
{
    private const int SpriteW = 32;
    private const int SpriteH = 32;
    private const string SpritesFolder = "Tiles/";
    private const string SpritesheetFolder = "Spritesheet/";
    private const string AnimationsFolder = "Animations/";
    private Dictionary<int, Image> _tiles = new Dictionary<int, Image>();
    private Palette _palette;
    
    public void SetPalette(Palette palette)
    {
        _palette = palette;
    }
    
    public void BuildTile(byte[] data, int key)
    {
        var ms = new MemoryStream(data);
        var br = new BinaryReader(ms);

        var img = new Image<Rgba32>(SpriteW, SpriteH);

        for (var j = 0; j < SpriteW * SpriteH; j++)
        {
            var pixelData = br.ReadByte();
            var pd = (int)pixelData;

            var pixelColor = _palette.GetColor(pd);

            var x = j % SpriteW;
            var y = j / SpriteH;

            img[x, y] = pixelData == 0 ? new Rgba32(255, 255, 255, 0) : new Rgba32(pixelColor.R, pixelColor.G, pixelColor.B, 255);
        }

        img.SaveAsPng($"{SpritesFolder}/{key}.png", new PngEncoder());
        
        _tiles.Add(key,img);
    }

    public void BuildMap(Zone zone, int w, int h)
    {
        var width = w * SpriteW;
        var height = h * SpriteH;

        var spriteMap = new Image<Rgba32>(width, height);

        var index = 0;
        
        for (var i = 0; i < zone.H; i++)
        {
            for (var j = 0; j < zone.W; j++)
            {
                for (var k =0; k <zone.Tiles[index].Length; k++)
                {
                    if (zone.Tiles[index][k] != -1)
                    {
                        var d =  _tiles[zone.Tiles[index][k]].CloneAs<Rgba32>();
                
                        for (var x = 0; x < SpriteH; x++)
                        {
                            for (var y = 0; y < SpriteW; y++)
                            {
                                if(d[x,y].A == 0) continue;
                                spriteMap[x + (j * SpriteH), y + (i * SpriteW)] = d[x, y];
                            }
                        }
                        
                        d.Dispose();
                    }
                }
                index++;
            }
        }
        
        var output = $"spritemap-{zone.K}.png";
        
        spriteMap.SaveAsPng($"{SpritesheetFolder}/{output}", new PngEncoder());
        
        Console.WriteLine("Parsing map: "+zone);
    }
    
    public void BuildAnimation(Anim anim)
    {
        var width = anim.Tiles.Length * SpriteW;
        var height = SpriteH;
        var spriteMap = new Image<Rgba32>(width, height);
        
        for (var i = 0; i < anim.Tiles.Length; i++)
        {
            var d =  _tiles[anim.Tiles[i]].CloneAs<Rgba32>();
                
            for (var x = 0; x < SpriteH; x++)
            {
                for (var y = 0; y < SpriteW; y++)
                {
                    spriteMap[x + (i*SpriteW), y] = d[x, y];
                }
            }
            
            d.Dispose();
        }
        
        var output = $"animation-{Guid.NewGuid().ToString()}.png";
        
        spriteMap.SaveAsPng($"{SpritesheetFolder}/{output}", new PngEncoder());
    }
    
    public void BuildSpritesheet()
    {
        var sq = (int)Math.Round(Math.Sqrt(_tiles.Count));
        
        var width = sq * SpriteW;
        var height = sq * SpriteH;

        var spriteSheet = new Image<Rgba32>(width, height);

        var row = 0;
        var col = 0;
        var index = 0;

        var tiles = new List<int>();
        
        foreach (var (key, value) in _tiles)
        {
            tiles.Add(key);
        }
        
        for (var i = 0; i < tiles.Count; i++)
        {
            var d = _tiles[i].CloneAs<Rgba32>();

            for (var x = 0; x < SpriteH; x++)
            {
                for (var y = 0; y < SpriteW; y++)
                {
                    spriteSheet[x + (row * SpriteH), y + (col * SpriteW)] = d[x, y];
                }
            }

            index++;

            if (index % sq == 0)
            {
                row = 0;
                col++;
            }
            else
            {
                row++;
            }
        }

        var output = $"spritesheet.png";
        
        spriteSheet.SaveAsPng($"{SpritesheetFolder}/{output}", new PngEncoder());
    }

    
}
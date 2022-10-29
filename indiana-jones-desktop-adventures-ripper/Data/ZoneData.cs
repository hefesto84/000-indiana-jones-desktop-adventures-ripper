using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using indiana_jones_desktop_adventures_ripper.Data.Base;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Data
{
    public class ZoneData : IData
    {
        public static string Tag => "ZONE";

        public void Parse(Section section)
        {
            // 4 bytes -> IZON
            // 2 bytes -> Size of block
            // 2 bytes -> 00 Unknown
            // 2 bytes -> W
            // 2 bytes -> H
            // 9 x 9 -> 1f6 -> 502 bytes
            // 18 x 18 -> 7a4 -> 1960 bytes
            Console.WriteLine($"Parsing: {Tag}");
            
            var ms = new MemoryStream(section.Data);
            var br = new BinaryReader(ms);

            var izonNum = br.ReadUInt16();
            
            var k = 0;
            
            while (ms.Position != section.Data.Length)
            {
                /* 16 bytes header */
                var iz = new string(br.ReadChars(4));
                var p = br.ReadUInt16(); // size block
                var unk = br.ReadUInt16(); // unknown
                var w = br.ReadUInt16(); // 
                var h = br.ReadUInt16();
                var unk2 = br.ReadUInt16(); // unknown = id ??
                var unk3 = br.ReadUInt16(); // padding
                // end of 16 bytes header */
                
                var zoneData = br.ReadBytes(p - 16);
                
                ParseZoneData(zoneData);
                
                Console.WriteLine($"{iz}_{k} : Unk2? {unk2}, padding {unk3}, {w}x{h} block size: {p} bytes");
                
                k++;
            }
        }

        private void ParseZoneData(byte[] zoneData)
        {
            var ms = new MemoryStream(zoneData);
            var br = new BinaryReader(ms);

            var sb = new StringBuilder();

            
            var k = 0;
            while (ms.Position != zoneData.Length)
            {
                var backgroundTile = br.ReadInt16();
                var midgroundTile = br.ReadInt16();
                //var backgroundTile = br.ReadUInt32();
                var foregroundTile = br.ReadInt16();
                //br.ReadUInt32();
                //var metadata = br.ReadBytes(4);

                //if (tile == 989)
                //{
                //    isFirst = true;
                //}
                //if (backgroundTile != 65535) backgroundTile = -1;

                /*
                if (backgroundTile == -1)
                {
                    sb.Append($"{midgroundTile},");
                }
                else
                {
                    sb.Append($"{backgroundTile},");
                }
                */

                sb.Append($"[{backgroundTile},{midgroundTile},{foregroundTile}]");
                k++;
                //if(backgroundTile!=65535) sb.Append($"{backgroundTile},");
                //if(midgroundTile!=65535) sb.Append($"{midgroundTile},");
                //if(foregroundTile!=65535) sb.Append($"{midgroundTile},");

            }
            
            Console.WriteLine($"Entries: {k}: {sb.ToString()}");
            
            /*
            if(isFirst)
            {
                Console.WriteLine(sb.ToString());
            }
            */
           
        }
    }
}
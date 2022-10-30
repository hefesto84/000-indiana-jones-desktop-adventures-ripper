using System;
using System.IO;
using System.Text;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Types.ZONE
{
    public class ZoneData : Base.Data
    {
        public override string Tag => "ZONE";

        public override void Parse(Section section)
        {
            base.Parse(section);
            
            // 4 bytes -> IZON
            // 2 bytes -> Size of block
            // 2 bytes -> 00 Unknown
            // 2 bytes -> W
            // 2 bytes -> H
            // 9 x 9 -> 1f6 -> 502 bytes
            // 18 x 18 -> 7a4 -> 1960 bytes
            Console.WriteLine($"Parsing: {Tag}");

            var izonNum = BR.ReadUInt16();
            
            var k = 0;
            
            while (MS.Position != section.Data.Length)
            {
                /* 16 bytes header */
                var iz = new string(BR.ReadChars(4));
                var p = BR.ReadInt16(); // size block
                var unk = BR.ReadInt16(); // unknown
                var w = BR.ReadInt16(); // 
                var h = BR.ReadInt16();
                var unk2 = BR.ReadInt16(); // unknown = id ??
                var unk3 = BR.ReadInt16(); // padding
                // end of 16 bytes header */
                
                var zoneData = BR.ReadBytes(p - 16);
                
                ParseZoneData(zoneData);
                
                //Console.WriteLine($"{iz}_{k} : Unk2? {unk2}, padding {unk3}, {w}x{h} block size: {p} bytes");
                
                k++;
            }
            
            Console.WriteLine($"IZON structs: {k}");
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
                var foregroundTile = br.ReadInt16();
                
                sb.Append($"[{backgroundTile},{midgroundTile},{foregroundTile}]");
                k++;
            }
            
            //Console.WriteLine($"Entries: {k}: {sb.ToString()}");
        }
        
        // 4 bytes -> zaux
        // 2 bytes -> size ? 
        // 4 bytes -> izax
        // 2 bytes -> size  => 4 + 2 + 8 = 14
        // 8 bytes -> unknow
    }
}
using System;
using System.IO;
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
                /* 12 bytes header */
                var iz = new string(br.ReadChars(4));
                var p = br.ReadUInt16();
                var unk = br.ReadUInt16();
                var w = br.ReadUInt16();
                var h = br.ReadUInt16();
                // end of 12 bytes header */
                
                var zoneData = br.ReadBytes(p - 12);
                Console.WriteLine($"{iz}_{k} : {w}x{h} block size: {p} bytes");
                k++;
            }
            //var sizeOfBlock = br.ReadBytes(6);
            //var s = br.ReadBytes(2);
            //var izon = new string(br.ReadChars(4));
            
            //var p = br.ReadInt16();
            /*
            var a1 = br.ReadUInt16();
            var w = br.ReadUInt16();
            var h = br.ReadUInt16();
            var x = br.ReadUInt16();
            */
            //var zoneData = br.ReadBytes(p - 6);
            //var izon2 = new string(br.ReadChars(4));
            //Console.WriteLine("Size: "+izon);
        }
    }
}
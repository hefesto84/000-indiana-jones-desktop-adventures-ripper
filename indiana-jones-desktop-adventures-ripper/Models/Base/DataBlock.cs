using System;
using System.IO;

namespace indiana_jones_desktop_adventures_ripper.Models.Base
{
    public class DataBlock
    {
        public string Tag { get; }
        public byte[] Data { get; }

        public DataBlock(string tag, byte[] data)
        {
            Tag = tag;
            Data = data;

            Console.WriteLine($"DATABLOCK: {Tag} DATA SIZE: {Data.Length}");
        }
    }
}
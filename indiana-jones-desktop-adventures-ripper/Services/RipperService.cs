﻿using System;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;

namespace indiana_jones_desktop_adventures_ripper.Services
{
    public class RipperService
    {
        private readonly BinaryReader _dataBinaryFileStream;
        private readonly BinaryReader _execBinaryFileStream;
        private readonly SectionService _sectionService;
        
        private Palette _palette;
        
        public RipperService(
            BinaryReader dataBinaryFileStream , 
            BinaryReader execBinaryFileStream ,
            SectionService sectionService)
        {
            _dataBinaryFileStream = dataBinaryFileStream;
            _execBinaryFileStream = execBinaryFileStream;
            _sectionService = sectionService;
        }

        public void Rip()
        {
            CheckFileStreams();

            SetupPalette();

            ParseSections();
            var p = 0;
            /*
            Console.WriteLine($"Position {_execBinaryFileStream.BaseStream.Position}");
            
            _execBinaryFileStream.BaseStream.Position = _offsetPalette;
            
            Console.WriteLine($"Position {_execBinaryFileStream.BaseStream.Position}");

            var b = new byte[256 * 4];
            */

            /*
            for (var i = 0; i < b.Length; i++)
            {
                var s = _execBinaryFileStream.ReadByte();
                
                Console.WriteLine($"Position {_execBinaryFileStream.BaseStream.Position}");
            }*/

            /*
            var s = _execBinaryFileStream.ReadBytes(b.Length);
            
            Console.WriteLine($"Bytes read: {b.Length}");

            var bs = new BinaryWriter(File.OpenWrite("palette.bin"));
            bs.Write(s);
            bs.Flush();
            bs.Close();
            */
            //var s = _execBinaryFileStream.Read(b, (int)_execBinaryFileStream.BaseStream.Position, b.Length-1);


            /*
            var paletteBuffer = new byte[256*4];
            
            var result = _execBinaryFileStream.Read(paletteBuffer, _offsetPalette, paletteBuffer.Length);
            */
            //Console.WriteLine("RES: "+result);
            //_execBinaryFileStream.Position = _offsetPalette;

        }

        private void CheckFileStreams()
        {
            if (_dataBinaryFileStream == null || _execBinaryFileStream == null)
                throw new Exception("Error reading data.");
        }

        private void SetupPalette()
        {
            _palette = new Palette(_execBinaryFileStream);   
            _palette.Extract();
            
            _sectionService.SetDependencies(_palette);
        }

        private void ParseSections()
        {
            var s = _dataBinaryFileStream.ReadChars(4);
            var section1 = new string(s);
            var version = _dataBinaryFileStream.ReadUInt32();

            while (!_sectionService.IsEndOfFile)
            {
                _sectionService.GetSection(_dataBinaryFileStream);
            }
        }
    }
}
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
        private readonly SpriteService _spriteService;
        private Palette _palette;

        public RipperService(
            BinaryReader dataBinaryFileStream,
            BinaryReader execBinaryFileStream,
            SectionService sectionService,
            SpriteService spriteService)
        {
            _dataBinaryFileStream = dataBinaryFileStream;
            _execBinaryFileStream = execBinaryFileStream;
            _sectionService = sectionService;
            _spriteService = spriteService;
        }

        public void Rip()
        {
            CheckFileStreams();

            ParseExeSections();
            ParseDawSections();
        }

        private void CheckFileStreams()
        {
            if (_dataBinaryFileStream == null || _execBinaryFileStream == null)
                throw new Exception("Error reading data.");
        }

        private void ParseDawSections()
        {
            var s = _dataBinaryFileStream.ReadChars(4);
            var section1 = new string(s);
            var version = _dataBinaryFileStream.ReadUInt32();

            while (!_sectionService.IsEndOfFile)
            {
                _sectionService.GetSection(_dataBinaryFileStream);
            }
        }

        private void ParseExeSections()
        {
            _palette = new Palette(_execBinaryFileStream);
            _palette.Extract();
            _spriteService.SetPalette(_palette);
        }
    }
}
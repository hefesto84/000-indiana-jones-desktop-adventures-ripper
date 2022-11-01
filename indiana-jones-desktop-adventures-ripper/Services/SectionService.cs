using System;
using System.Collections.Generic;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Sections;
using indiana_jones_desktop_adventures_ripper.Sections.ACTN;
using indiana_jones_desktop_adventures_ripper.Sections.ANAM;
using indiana_jones_desktop_adventures_ripper.Sections.CAUX;
using indiana_jones_desktop_adventures_ripper.Sections.CHAR;
using indiana_jones_desktop_adventures_ripper.Sections.CHWP;
using indiana_jones_desktop_adventures_ripper.Sections.HTSP;
using indiana_jones_desktop_adventures_ripper.Sections.PNAM;
using indiana_jones_desktop_adventures_ripper.Sections.PUZ2;
using indiana_jones_desktop_adventures_ripper.Sections.SNDS;
using indiana_jones_desktop_adventures_ripper.Sections.STUP;
using indiana_jones_desktop_adventures_ripper.Sections.TILE;
using indiana_jones_desktop_adventures_ripper.Sections.TNAM;
using indiana_jones_desktop_adventures_ripper.Sections.ZAUX;
using indiana_jones_desktop_adventures_ripper.Sections.ZAX2;
using indiana_jones_desktop_adventures_ripper.Sections.ZAX3;
using indiana_jones_desktop_adventures_ripper.Sections.ZAX4;
using indiana_jones_desktop_adventures_ripper.Sections.ZNAM;
using indiana_jones_desktop_adventures_ripper.Sections.ZONE;

namespace indiana_jones_desktop_adventures_ripper.Services
{
    public class SectionService
    {
        public bool IsEndOfFile { get; private set; }

        private const string EndOfFile = "ENDF";
        private Dictionary<string, Section> _dataContents;
        private readonly SpriteService _spriteService;

        public SectionService(SpriteService spriteService)
        {
            _spriteService = spriteService;
            _dataContents = new Dictionary<string, Section>();
            
            RegisterTypes();
        }

        public void SetPalette(Palette palette)
        {
                
        }
        
        private void RegisterTypes()
        {
            Register(new StupSection());
            Register(new SndsSection());
            Register(new TileSection(_spriteService));
            Register(new ZoneSection(_spriteService));
            Register(new ZAuxSection());
            Register(new Zax2Data());
            Register(new Zax3Data());
            Register(new Zax4Data());
            Register(new HtspSection());
            Register(new ActnSection());
            Register(new Puz2Data());
            Register(new CharSection());
            Register(new ChwpSection());
            Register(new CauxSection());
            Register(new TnamSection());
            Register(new ZnamSection());
            Register(new PnamSection());
            Register(new AnamSection());
        }

        private void Register(Section d)
        {
            _dataContents.Add(d.Tag, d);
        }
        
        public void GetSection(BinaryReader binaryReader)
        {
            var tag = new string(binaryReader.ReadChars(4));
            var sectionSize = binaryReader.ReadInt32();
            var data = binaryReader.ReadBytes((int)sectionSize);

            if (_dataContents.ContainsKey(tag)) _dataContents[tag].Parse(new DataBlock(tag, data));

            IsEndOfFile = tag.Equals(EndOfFile);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Models.Base;
using indiana_jones_desktop_adventures_ripper.Sections;
using indiana_jones_desktop_adventures_ripper.Sections.ACTN;
using indiana_jones_desktop_adventures_ripper.Sections.ANAM;
using indiana_jones_desktop_adventures_ripper.Sections.CAUX;
using indiana_jones_desktop_adventures_ripper.Sections.CHAR;
using indiana_jones_desktop_adventures_ripper.Sections.CHWP;
using indiana_jones_desktop_adventures_ripper.Sections.EXE;
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
        
        private readonly Dictionary<string, Section> _dawDataContents;
        private readonly Dictionary<string, ExeSection> _exeDataContents;
        
        private readonly SpriteService _spriteService;

        public SectionService(SpriteService spriteService)
        {
            _spriteService = spriteService;
            _dawDataContents = new Dictionary<string, Section>();
            _exeDataContents = new Dictionary<string, ExeSection>();
            
            RegisterDawTypes();
            RegisterExeTypes();
        }

        private void RegisterDawTypes()
        {
            /*
            RegisterDawSection(new StupSection());
            RegisterDawSection(new SndsSection());
            RegisterDawSection(new TileSection(_spriteService));
            RegisterDawSection(new ZoneSection(_spriteService));
            RegisterDawSection(new ZAuxSection());
            RegisterDawSection(new Zax2Data());
            RegisterDawSection(new Zax3Data());
            RegisterDawSection(new Zax4Data());
            RegisterDawSection(new HtspSection());
            RegisterDawSection(new ActnSection());
            RegisterDawSection(new Puz2Section());
            RegisterDawSection(new CharSection(_spriteService));
            RegisterDawSection(new ChwpSection());
            RegisterDawSection(new CauxSection());
            RegisterDawSection(new TnamSection());
            RegisterDawSection(new ZnamSection());
            RegisterDawSection(new PnamSection());
            RegisterDawSection(new AnamSection());
            */
            RegisterDawSection(new ChwpSection());
            RegisterDawSection(new Puz2Section());
        }

        private void RegisterExeTypes()
        {
            RegisterExeSection(new ExeSection());
        }

        private void RegisterDawSection(Section d)
        {
            _dawDataContents.Add(d.Tag, d);
        }

        private void RegisterExeSection(ExeSection d)
        {
            _exeDataContents.Add(d.Tag, d);
        }
        
        public void GetDawSections(BinaryReader binaryReader)
        {
            var tag = new string(binaryReader.ReadChars(4));
            var sectionSize = binaryReader.ReadInt32();
            var data = binaryReader.ReadBytes((int)sectionSize);

            if (_dawDataContents.ContainsKey(tag)) _dawDataContents[tag].Parse(new DataBlock(tag, data));

            IsEndOfFile = tag.Equals(EndOfFile);
        }

        public void GetExeSections(BinaryReader binaryReader, out Palette palette)
        {
            _exeDataContents["EXE"].Parse(new ExeBlock(binaryReader), out palette);
        }
    }
}
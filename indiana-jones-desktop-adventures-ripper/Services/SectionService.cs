using System;
using System.Collections.Generic;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Models;
using indiana_jones_desktop_adventures_ripper.Types.ACTN;
using indiana_jones_desktop_adventures_ripper.Types.ANAM;
using indiana_jones_desktop_adventures_ripper.Types.Base;
using indiana_jones_desktop_adventures_ripper.Types.CAUX;
using indiana_jones_desktop_adventures_ripper.Types.CHAR;
using indiana_jones_desktop_adventures_ripper.Types.CHWP;
using indiana_jones_desktop_adventures_ripper.Types.HTSP;
using indiana_jones_desktop_adventures_ripper.Types.PNAM;
using indiana_jones_desktop_adventures_ripper.Types.PUZ2;
using indiana_jones_desktop_adventures_ripper.Types.SNDS;
using indiana_jones_desktop_adventures_ripper.Types.STUP;
using indiana_jones_desktop_adventures_ripper.Types.TILE;
using indiana_jones_desktop_adventures_ripper.Types.TNAM;
using indiana_jones_desktop_adventures_ripper.Types.ZAUX;
using indiana_jones_desktop_adventures_ripper.Types.ZAX2;
using indiana_jones_desktop_adventures_ripper.Types.ZAX3;
using indiana_jones_desktop_adventures_ripper.Types.ZAX4;
using indiana_jones_desktop_adventures_ripper.Types.ZNAM;
using indiana_jones_desktop_adventures_ripper.Types.ZONE;

namespace indiana_jones_desktop_adventures_ripper.Services
{
    public class SectionService
    {
        public bool IsEndOfFile { get; private set; }

        private const string EndOfFile = "ENDF";
        private Dictionary<string, Data> _dataContents;

        public void RegisterTypes(Palette palette)
        {
            _dataContents = new Dictionary<string, Data>();

            Register(new StupData());
            Register(new SndsData());
            Register(new TileData(palette));
            Register(new ZoneData());
            Register(new ZAuxData());
            Register(new Zax2Data());
            Register(new Zax3Data());
            Register(new Zax4Data());
            Register(new HtspData());
            Register(new ActnData());
            Register(new Puz2Data());
            Register(new CharData());
            Register(new ChwpData());
            Register(new CauxData());
            Register(new TnamData());
            Register(new ZnamData());
            Register(new PnamData());
            Register(new AnamData());
        }

        private void Register(Data d)
        {
            _dataContents.Add(d.Tag, d);
        }
        
        public void GetSection(BinaryReader binaryReader)
        {
            var tag = new string(binaryReader.ReadChars(4));
            var sectionSize = binaryReader.ReadInt32();
            var data = binaryReader.ReadBytes((int)sectionSize);

            //Console.WriteLine($"Detected: {tag}");
            if (_dataContents.ContainsKey(tag)) _dataContents[tag].Parse(new Section(tag, data));

            IsEndOfFile = tag.Equals(EndOfFile);
        }
    }
}
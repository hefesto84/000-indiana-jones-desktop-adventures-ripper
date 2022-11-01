using System;
using System.IO;
using indiana_jones_desktop_adventures_ripper.Services;

namespace indiana_jones_desktop_adventures_ripper
{
    class Program
    {
        static void Main(string[] args)
        {
            var spriteService = new SpriteService();
            var sectionService = new SectionService(spriteService);

            var ripperService = new RipperService(
                new BinaryReader(File.OpenRead($"{Directory.GetCurrentDirectory()}/Files/DESKTOP.DAW")),
                new BinaryReader(File.OpenRead($"{Directory.GetCurrentDirectory()}/Files/DESKADV.EXE")),
                sectionService,spriteService);

            ripperService.Rip();
        }
    }
}

using System.IO;

namespace indiana_jones_desktop_adventures_ripper.Models
{
    public class Wav
    {
        private readonly BinaryReader _binaryReader;
        private const string Sounds = "Sounds/";
        
        public Wav(BinaryReader binaryReader)
        {
            _binaryReader = binaryReader;
        }

        public void Extract(int offset)
        {
            _binaryReader.BaseStream.Position = offset;
            _binaryReader.ReadChars(4);
            var size = _binaryReader.ReadInt32();

            _binaryReader.BaseStream.Position = offset;

            var data = _binaryReader.ReadBytes(size + 8);
            
            if(Directory.Exists(Sounds)) Directory.Delete(Sounds, true);
            
            Directory.CreateDirectory(Sounds);
            
            File.WriteAllBytes($"{Sounds}/unnamed-sound-from-exe.wav",data);
        }
    }
}
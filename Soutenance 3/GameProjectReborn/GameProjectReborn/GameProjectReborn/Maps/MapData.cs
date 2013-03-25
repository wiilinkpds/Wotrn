using System;
using System.IO;

namespace GameProjectReborn.Maps
{
    public class MapData
    {
        public int[] MapTilesHigh { get; private set; }
        public int[] MapTilesMiddle { get; private set; }
        public int[] MapTilesLow { get; private set; }
        public int[] Accessibility { get; private set; }
        public int[] SideAccess { get; private set; }

        public int MapWidth { get; private set; }
        public int MapHeight { get; private set; }

        private const int FileHeader = 1196446285;

        private int[] FromData(BinaryReader reader)
        {
            int[] array = new int[MapHeight * MapWidth];

            for (int i = 0; i < MapHeight*MapWidth; i++)
                array[i] = reader.ReadInt16();

            return array;
        }

        public bool FromFile(string filename)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);

                int header = reader.ReadInt32();
                if (header != FileHeader)
                    throw new Exception();

                reader.ReadInt16();

                MapWidth = reader.ReadInt16();
                MapHeight = reader.ReadInt16();

                MapTilesHigh = FromData(reader);
                MapTilesMiddle = FromData(reader);
                MapTilesLow = FromData(reader);
                Accessibility = FromData(reader);
                SideAccess = FromData(reader);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
    }
}

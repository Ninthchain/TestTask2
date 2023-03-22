using System.Drawing;
using System.Numerics;

namespace WebApplication1.Models
{
    public enum MapSlotValue
    {
        Empty,
        CircleOccupied = 1,
        CrossOccupied = 2
    }

    public class GameMap
    {
        private Size _mapSize;

        private MapSlotValue[,] _map;
        public MapSlotValue[,] Map => _map;

        private void FillMap()
        {
            for (int i = 0; i < _mapSize.Height; i++)
                for (int j = 0; j < _mapSize.Width; j++)
                    _map.SetValue(MapSlotValue.Empty, i, j);
            
        }

        public GameMap(Size size)
        {
            _mapSize = size;
            _map = new MapSlotValue[size.Width, size.Height];

            FillMap();
        }

        public void SetValue(MapSlotValue value, int horizontalIndex, int verticalIndex) => _map.SetValue(value, horizontalIndex, verticalIndex);

        public MapSlotValue GetValue(int horizontalIndex, int verticalIndex)
        {
            MapSlotValue mapSlotValue = (MapSlotValue)_map.GetValue (horizontalIndex, verticalIndex);
            return mapSlotValue;
        }

        public bool IsEmpty(int horizontalIndex, int verticalIndex) => GetValue(horizontalIndex, verticalIndex) == MapSlotValue.Empty;

        public bool IsFull()
        {
            for(int vertical = 0; vertical < _mapSize.Height; vertical++)
                for(int horizontal = 0; horizontal < _mapSize.Width; horizontal++)
                    if(IsEmpty(horizontal, vertical)) return false;

            return true;
        }
    }


}

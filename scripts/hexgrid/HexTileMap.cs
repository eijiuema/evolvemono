using Godot;

namespace EvolveMono.Scripts.Hexgrid {

    [Tool]
    public class HexTileMap : TileMap {
        
        private Vector2 _tileSize;
        private int _tileC;

        [Export]
        public Vector2 TileSize
        {
            get => _tileSize;
            set {
                _tileSize = value;
                UpdateCellSize();
            }
        }

        [Export]
        public int TileC
        {
            get => _tileC;
            set {
                _tileC = value;
                UpdateCellSize();
            }
        }

        private float _m;

        public override void _EnterTree()
        {
            _m = _tileC / (_tileSize.x / 2);
            CellYSort = true;
            CellHalfOffset = TileMap.HalfOffset.X;
        }

        public new Vector2 WorldToMap(Vector2 world)
        {
            var worldPosLocal = ToLocal(world);
            var mapPos = base.WorldToMap(world);
            var relativePos = worldPosLocal - MapToWorld(mapPos);

            if (relativePos.x < _tileSize.x / 2)
            {
                if (-_m * relativePos.x + _tileC - relativePos.y >= 1)
                {
                    if (mapPos.y % 2 == 0)
                    {
                        mapPos += new Vector2(-1, -1);
                    }
                    else
                    {
                        mapPos += new Vector2(0, -1);
                    }
                }
            }
            else
            {
                if (_m * relativePos.x - _tileC - relativePos.y >= 1)
                {
                    if (mapPos.y % 2 == 0)
                    {
                        mapPos += new Vector2(0, -1);
                    } else {
                        mapPos += new Vector2(1, -1);
                    }
                }
            }

            return mapPos;
        }

        private void UpdateCellSize()
        {
            CellSize = _tileSize - new Vector2(0, _tileC + 1);
        }

    }

}
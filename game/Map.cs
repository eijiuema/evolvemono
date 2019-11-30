using Godot;
using EvolveMono.Game.Units;
using EvolveMono.Game.Tiles;
using EvolveMono.Game.Hexgrid;

namespace EvolveMono.Game
{
    public class Map : Navigation2D
    {

        [Signal]
        delegate void TileHovered(Tile tile);
        [Signal]
        delegate void TileSelected(Tile tile);

        public HexTileMap TileMap;
        public Sprite HoveredSprite;
        public Sprite SelectedSprite;

        public Vector2 hoveredMapPos;

        public override void _Ready()
        {
            TileMap = (HexTileMap)GetNode("HexTileMap");
            HoveredSprite = (Sprite)GetNode("Hovered");
            SelectedSprite = (Sprite)GetNode("Selected");

            // Inicia o TileManager
            foreach (Vector2 cell in TileMap.GetUsedCells())
            {
                TileManager.Tiles[cell.x, cell.y] = new Tile(Terrain.GetTerrain(TileMap.GetCellv(cell)));
            }

            // Adiciona a primeira unidade do jogo
            // Unit newUnit = UnitManager.CreateUnit(UnitType.Goblin);
            // newUnit.Position = TileMap.TileSize / 2;
            // AddChild(newUnit);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventMouseMotion eventMouseMotion)
            {
                var newHoveredMapPos = TileMap.WorldToMap(GetGlobalMousePosition());
                if (hoveredMapPos != newHoveredMapPos)
                {
                    hoveredMapPos = newHoveredMapPos;
                    Tile hoveredTile = TileManager.Tiles[hoveredMapPos];
                    if (hoveredTile != null)
                    {
                        HoveredSprite.Position = TileMap.MapToWorld(hoveredMapPos) + TileMap.TileSize / 2;
                        EmitSignal(nameof(TileHovered), hoveredTile);
                    }
                }
            }
            if (@event.IsActionPressed("map_left_click"))
            {
                Tile selectedTile = TileManager.Tiles[hoveredMapPos];
                if (selectedTile != null)
                {
                    SelectedSprite.Position = HoveredSprite.Position;
                    EmitSignal(nameof(TileSelected), selectedTile);
                }
            }
        }
    }

}
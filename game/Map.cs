using Godot;
using EvolveMono.Game.Units;
using EvolveMono.Game.Tiles;
using EvolveMono.Game.Hexgrid;

namespace EvolveMono.Game
{
    public class Map : Navigation2D
    {

        [Signal]
        public delegate void Select();

        public HexTileMap TileMap;
        public Sprite Hovered;
        public Sprite Selected;

        public Vector2 hoveredMapPos;

        public override void _Ready()
        {
            TileMap = (HexTileMap)GetNode("HexTileMap");
            Hovered = (Sprite)GetNode("Hovered");
            Selected = (Sprite)GetNode("Selected");

            // Inicia o TileManager
            foreach (Vector2 cell in TileMap.GetUsedCells())
            {
                TileManager.Tiles[cell.x, cell.y] = new Tile(Terrain.GetTerrain(TileMap.GetCellv(cell)));
            }

            // Adiciona a primeira unidade do jogo
            Unit newUnit = UnitManager.CreateUnit(UnitType.Goblin);
            newUnit.Position = TileMap.TileSize / 2;
            AddChild(newUnit);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventMouseMotion eventMouseMotion)
            {
                hoveredMapPos = TileMap.WorldToMap(GetGlobalMousePosition());
                Hovered.Position = TileMap.MapToWorld(hoveredMapPos) + TileMap.TileSize / 2;
            }
            if (@event.IsActionPressed("map_left_click"))
            {
                EmitSignal(nameof(Select));
                Selected.Position = Hovered.Position;
                Tile selectedTile = TileManager.Tiles[hoveredMapPos];
                if (selectedTile != null)
                {
                    GD.Print(hoveredMapPos + ": ");
                    foreach (var resourceType in selectedTile.Terrain.ResourceTypes)
                    {
                        GD.Print("\t" + resourceType);
                    }
                }
            }
        }
    }

}
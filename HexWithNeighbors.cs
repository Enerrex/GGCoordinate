using static GGHexCoordinate.Neighbors;

namespace GGHexCoordinate
{
    public struct HexWithNeighbors<T> where T : unmanaged, INeighbors<T>, IHexCoordinate<T>
    {
        public HexagonalAxis Neighbors;
        public T Coordinate;

        public HexWithNeighbors
        (
            T coordinate,
            HexagonalAxis neighbors = HexagonalAxis.All
        )
        {
            Neighbors = neighbors;
            Coordinate = coordinate;
        }

        public T this
        [
            HexagonalAxis index
        ]
        {
            get
            {
                return index switch
                {
                    HexagonalAxis.North => Coordinate.GetNeighbor(HexagonalAxis.North),
                    HexagonalAxis.NorthEast => Coordinate.GetNeighbor(HexagonalAxis.NorthEast),
                    HexagonalAxis.SouthEast => Coordinate.GetNeighbor(HexagonalAxis.SouthEast),
                    HexagonalAxis.South => Coordinate.GetNeighbor(HexagonalAxis.South),
                    HexagonalAxis.SouthWest => Coordinate.GetNeighbor(HexagonalAxis.SouthWest),
                    HexagonalAxis.NorthWest => Coordinate.GetNeighbor(HexagonalAxis.NorthWest),
                    _ => throw new ArgumentException("Hexagons only have 6 sides dummy.")
                };
            }
        }

        public readonly HexWithNeighborsIterator<T> GetIterator()
        {
            return new HexWithNeighborsIterator<T>(this);
        }

        public T North => Coordinate.GetNeighbor(HexagonalAxis.North);
        public T NorthEast => Coordinate.GetNeighbor(HexagonalAxis.NorthEast);
        public T SouthEast => Coordinate.GetNeighbor(HexagonalAxis.SouthEast);
        public T South => Coordinate.GetNeighbor(HexagonalAxis.South);
        public T SouthWest => Coordinate.GetNeighbor(HexagonalAxis.SouthWest);
        public T NorthWest => Coordinate.GetNeighbor(HexagonalAxis.NorthWest);
    }
}
namespace GGHexCoordinate.FlatTop
{
    public struct HexWithNeighborsIterator<T> where T : unmanaged, IHexCoordinate<T>
    {
        private Neighbors.HexagonalAxisIterator _axisIterator;
        private HexWithNeighbors<T> _target;

        public T Current { get; private set; }

        public Neighbors.HexagonalAxis CurrentAxis => _axisIterator.Current;

        /// <summary>
        /// The default "current" will point to the target hex, i.e. the hex that is in the center of the neighbors.
        /// </summary>
        /// <param name="target"></param>
        public HexWithNeighborsIterator
        (
            HexWithNeighbors<T> target
        )
        {
            _axisIterator = new Neighbors.HexagonalAxisIterator();
            _target = target;
            Current = target.Coordinate;
        }

        /// <summary>
        /// Checks if the iterator has reached the end of the iteration.
        /// Moves the current index up by one, then checks to see if the bit in the neighbors mask is set.
        /// If it is, then the current coordinate is set to the neighbor in that direction.
        /// If it is not, then the iterator moves to the next neighbor, and the process repeats.
        /// </summary>
        /// <returns>bool, whether the current value is valid.</returns>
        public bool MoveNext()
        {
            while (true)
            {
                // Get the neighbor flag that corresponds to the current neighbor index
                var neighbor_flag = _axisIterator.Current;
                if (!_axisIterator.MoveNext()) return false;
                // Check to see if the current bit is a valid neighbor
                if ((_target.Neighbors & neighbor_flag) == 0) continue;
                Current = _target[neighbor_flag];
                return true;
            }
        }
    }
}
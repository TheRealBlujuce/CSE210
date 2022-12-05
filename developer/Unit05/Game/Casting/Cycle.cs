using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>The responsibility of Cycle is to move itself.</para>
    /// </summary>
    public class Cycle : Actor
    {
        private List<Actor> _segments = new List<Actor>();
        private Point currentDirection;
        /// <summary>
        /// Constructs a new instance of a Cycle.
        /// </summary>
        public Cycle(Point startingPoint, Color playerColor)
        {
            PrepareBody(startingPoint, playerColor);
            currentDirection = new Point(0, Constants.CELL_SIZE);
        }

        /// <summary>
        /// Gets the cycle's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(_segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the cycle's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return _segments[0];
        }

        /// <summary>
        /// Gets the cycle's segments (including the head).
        /// </summary>
        /// <returns>A list of cycle segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return _segments;
        }

        /// <summary>
        /// Grows the cycle's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = _segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("o");
                segment.SetColor(Constants.YELLOW);
                _segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            // add new segment to the beginning of the head
            Actor prevHead = GetHead();
            prevHead.SetText("#");
            int x = (prevHead.GetPosition().GetX() + currentDirection.GetX() + Constants.MAX_X) % Constants.MAX_X;
            int y = (prevHead.GetPosition().GetY() + currentDirection.GetY() + Constants.MAX_Y) % Constants.MAX_Y;

            Point position = new Point(x, y);
            Point velocity = new Point(0, 0);
            string text = "@";
            Color color = prevHead.GetColor();

            Actor segment = new Actor();
            segment.SetPosition(position);
            segment.SetVelocity(velocity);
            segment.SetText(text);
            segment.SetColor(color);
            _segments.Insert(0, segment);

           // this is added in the direction we are moving
        }

        /// <summary>
        /// Turns the head of the cycle in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
           currentDirection = direction;
        }

        /// <summary>
        /// Prepares the cycle body for moving.
        /// </summary>
        private void PrepareBody(Point startingPoint, Color playerColor)
        {

            Point position = startingPoint;
            Point velocity = new Point(0, 0);
            string text = "O";
            Color color = playerColor;

            Actor segment = new Actor();
            segment.SetPosition(position);
            segment.SetVelocity(velocity);
            segment.SetText(text);
            segment.SetColor(color);
            _segments.Add(segment);
            
        }
    }
}
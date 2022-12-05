using Unit05.Game.Casting;
using Unit05.Game.Services;
using System.Collections.Generic;

namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the Cycle.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the Cycle's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService _keyboardService;
        private Point direction1 = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> cycles = cast.GetActors(group: "cycles");

            Cycle p1Cycle = (Cycle)cycles[0];
            Cycle p2Cycle = (Cycle)cycles[1];

            MoveCycle1(p1Cycle, cast);
            MoveCycle2(p2Cycle, cast);
        }

        private void MoveCycle1(Cycle cycle, Cast cast)
        {
            // left
            if (_keyboardService.IsKeyDown("a"))
            {
                direction1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("d"))
            {
                direction1 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("w"))
            {
                direction1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("s"))
            {
                direction1 = new Point(0, Constants.CELL_SIZE);
            }

            // player 1
            cycle.TurnHead(direction1);

        }

        private void MoveCycle2(Cycle cycle, Cast cast)
        {
            // left
            if (_keyboardService.IsKeyDown("j"))
            {
                direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("l"))
            {
                direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("i"))
            {
                direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("k"))
            {
                direction2 = new Point(0, Constants.CELL_SIZE);
            }

            // player 1
            cycle.TurnHead(direction2);

        }

    }
}
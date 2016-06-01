using System;

namespace RollingBallGame.GameCore
{
	public class FloorCell : Cell
	{
		public override void Draw()
		{
			Console.Write("Å°");
		}

		public FloorCell() : base(CellType.Floor) { }
	}
}

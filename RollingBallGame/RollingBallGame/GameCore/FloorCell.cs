using System;

namespace RollingBallGame.GameCore
{
	public class FloorCell : Cell
	{
		public override void Draw()
		{
			Console.Write("■");
		}

		public FloorCell() : base(CellType.Floor) { }
	}
}

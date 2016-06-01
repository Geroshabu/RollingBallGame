using System;

namespace RollingBallGame.GameCore
{
	public class HoleCell : Cell
	{
		public override void Draw()
		{
			Console.Write("Å@");
		}

		public HoleCell() : base(CellType.Hole) { }
	}
}

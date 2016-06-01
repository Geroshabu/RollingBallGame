using System;

namespace RollingBallGame.GameCore
{
	public class HoleCell : Cell
	{
		public override void Draw()
		{
			throw new NotImplementedException();
		}

		public HoleCell() : base(CellType.Hole) { }
	}
}

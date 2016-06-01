using System;

namespace RollingBallGame.GameCore
{
	public class FloorCell : Cell
	{
		public override void Draw()
		{
			throw new NotImplementedException();
		}

		public FloorCell() : base(CellType.Floor) { }
	}
}

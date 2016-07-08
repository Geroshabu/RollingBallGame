using System;

namespace RollingBallGame.GameCore
{
	public class GoalCell : Cell
	{
		public override void Draw()
		{
			Console.Write("★");
		}

		public GoalCell() : base(CellType.Goal) { }
	}
}

using System;
using Xunit;
using RollingBallGame.GameCore;

namespace RollingBallGameTest
{
	public class CellTest
	{
		public class GoalCellTest
		{
			[Fact(DisplayName="�����l�m�F")]
			public void InitializeTest()
			{
				GoalCell cell = new GoalCell();
				Assert.Equal(CellType.Goal, cell.CellType);
			}
		}
	}
}

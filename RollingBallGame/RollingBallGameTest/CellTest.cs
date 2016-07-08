using System;
using Xunit;
using RollingBallGame.GameCore;

namespace RollingBallGameTest
{
	public class CellTest
	{
		public class GoalCellTest
		{
			[Fact(DisplayName="初期値確認")]
			public void InitializeTest()
			{
				GoalCell cell = new GoalCell();
				Assert.Equal(CellType.Goal, cell.CellType);
			}
		}
	}
}

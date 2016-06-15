using System;
using Xunit;
using System.Windows;
using RollingBallGame.GameCore;

namespace RollingBallGameTest
{
	public class BallTest
	{
		[Fact(DisplayName = "‰Šú’lŠm”F")]
		public void InitializeTest()
		{
			Ball target = new Ball();
			Assert.Equal(new Point(0.0, 0.0), target.Position);
		}
	}
}
using System;
using System.Collections.Generic;
using Xunit;
using System.Windows;
using RollingBallGame.GameCore;
using System.Reflection;

namespace RollingBallGameTest
{
	public class BallTest
	{
		[Fact(DisplayName = "�����l�m�F")]
		public void InitializeTest()
		{
			Ball target = new Ball();
			Assert.Equal(new Point(0.0, 0.0), target.Position);
			Assert.Equal(new Vector(0.0, 0.0), target.Velocity);
			Assert.Equal(new Vector(0.0, 0.0), target.Acceleration);
		}

		public static IEnumerable<object[]> GridPositionTestData
		{
			get
			{
				yield return new object[] { new Point(3.0, 4.0), new GridPoint(3, 4) };	// ®”(³)
				yield return new object[] { new Point(2.999, 4.0), new GridPoint(2, 4) };	// XÀ•W’[”ˆ—(³)
				yield return new object[] { new Point(3.0, 3.999), new GridPoint(3, 3) };	// YÀ•W’[”ˆ—(³)
				yield return new object[] { new Point(-3.0, -4.0), new GridPoint(-3, -4) };	// ®”(•‰)
				yield return new object[] { new Point(-3.001, -4.0), new GridPoint(-4, -4) };	// XÀ•W’[”ˆ—(•‰)
				yield return new object[] { new Point(-3.0, -4.001), new GridPoint(-3, -5) };	// YÀ•W’[”ˆ—(•‰)
			}
		}

		[Theory(DisplayName = "GridPointƒvƒƒpƒeƒB‚ÌŠm”F")]
		[MemberData("GridPositionTestData")]
		public void GridPointTest(Point position, GridPoint expected)
		{
			Ball ball = new Ball();

			PropertyInfo property_info = ball.GetType().GetProperty("Position",
				BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);
			property_info.SetValue(ball, position);

			Assert.Equal(expected, ball.GridPosition);
		}
	}
}
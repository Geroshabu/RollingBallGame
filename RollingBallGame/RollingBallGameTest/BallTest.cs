using System;
using System.Collections.Generic;
using Xunit;
using System.Windows;
using RollingBallGame.GameCore;
using System.Reflection;

namespace RollingBallGameTest
{
	/// <summary>
	/// privateなメンバにアクセスするというチート用拡張メソッド
	/// </summary>
	internal static class BallExtentions
	{
		public static void SetPosition(this Ball ball, Point position)
		{
			PropertyInfo property_info = ball.GetType().GetProperty("Position",
				BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);
			property_info.SetValue(ball, position);
		}

		public static void SetVelocity(this Ball ball, Vector velocity)
		{
			PropertyInfo property_info = ball.GetType().GetProperty("Velocity",
				BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);
			property_info.SetValue(ball, velocity);
		}

		public static void SetAcceleration(this Ball ball, Vector acceleration)
		{
			PropertyInfo property_info = ball.GetType().GetProperty("Acceleration",
				BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);
			property_info.SetValue(ball, acceleration);
		}
	}

	public class BallTest
	{
		[Fact(DisplayName = "初期値確認")]
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
				yield return new object[] { new Point(3.0, 4.0), new GridPoint(3, 4) };	// 整数(正)
				yield return new object[] { new Point(2.999, 4.0), new GridPoint(2, 4) };	// X座標端数処理(正)
				yield return new object[] { new Point(3.0, 3.999), new GridPoint(3, 3) };	// Y座標端数処理(正)
				yield return new object[] { new Point(-3.0, -4.0), new GridPoint(-3, -4) };	// 整数(負)
				yield return new object[] { new Point(-3.001, -4.0), new GridPoint(-4, -4) };	// X座標端数処理(負)
				yield return new object[] { new Point(-3.0, -4.001), new GridPoint(-3, -5) };	// Y座標端数処理(負)
			}
		}

		[Theory(DisplayName = "GridPointプロパティの確認")]
		[MemberData("GridPositionTestData")]
		public void GridPointTest(Point position, GridPoint expected)
		{
			Ball ball = new Ball();

			ball.SetPosition(position);

			Assert.Equal(expected, ball.GridPosition);
		}

		public static IEnumerable<object[]> RollTestData
		{
			get
			{
				yield return new object[] {	// 正の加速度を与える
					new Point(0.2, 0.3), new Vector(0.5, 0.7), new Vector(1.1, 1.3), new Vector(1.7, 1.9),
					new Point(2.4, 2.9), new Vector(2.2, 2.6), new Vector(1.7, 1.9)
				};
				yield return new object[] {	// 負の加速度を与える. (そしてPositionを負に...)
					new Point(1.7, 1.9), new Vector(0.2, 0.3), new Vector(0.5, 0.7), new Vector(-1.1, -2.3),
					new Point(0.8, -0.1), new Vector(-0.9, -2.0), new Vector(-1.1, -2.3)
				};

			}
		}

		[Theory(DisplayName = "Rollメソッドの確認")]
		[MemberData("RollTestData")]
		public void RollTest(Point position, Vector velocity, Vector acceleration, Vector input,
							Point expected_position, Vector expected_velocity, Vector expected_acceleration)
		{
			Ball ball = new Ball();

			ball.SetPosition(position);
			ball.SetVelocity(velocity);
			ball.SetAcceleration(acceleration);

			ball.Roll(input);

			// 計算の過程で誤差が出るはず. 精度指定して比較する.
			Assert.Equal(expected_position.X, ball.Position.X, 1);
			Assert.Equal(expected_position.Y, ball.Position.Y, 1);
			Assert.Equal(expected_velocity.X, ball.Velocity.X, 1);
			Assert.Equal(expected_velocity.Y, ball.Velocity.Y, 1);
			Assert.Equal(expected_acceleration.X, ball.Acceleration.X, 1);
			Assert.Equal(expected_acceleration.Y, ball.Acceleration.Y, 1);
		}
	}
}

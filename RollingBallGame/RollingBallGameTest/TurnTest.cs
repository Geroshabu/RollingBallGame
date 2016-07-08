using System;
using System.Windows;
using System.Collections.Generic;
using Xunit;
using RollingBallGame.GameCore;

namespace RollingBallGameTest
{
	public class TurnTest
	{
		private Board defaultBoard;
		private Ball defaultBallBeforeExecute;

		public TurnTest()
		{
			defaultBoard = new Board();
			defaultBoard.Set_Cells(new Cell[5, 5]{
				{ new FloorCell(), new FloorCell(), new FloorCell(), new FloorCell(), new FloorCell() },
				{ new FloorCell(), new HoleCell(),  new HoleCell(),  new FloorCell(), new FloorCell() },
				{ new FloorCell(), new HoleCell(),  new HoleCell(),  new FloorCell(), new FloorCell() },
				{ new FloorCell(), new FloorCell(), new FloorCell(), new GoalCell(),  new FloorCell() },
				{ new FloorCell(), new FloorCell(), new FloorCell(), new FloorCell(), new FloorCell() }
			});
			defaultBoard.SetWidth(5);
			defaultBoard.SetHeight(5);

			defaultBallBeforeExecute = new Ball();
		}

		[Fact(DisplayName = "初期値確認")]
		public void InitializeTest()
		{
			Turn turn = new Turn(defaultBoard, defaultBallBeforeExecute);

			Assert.Equal(defaultBoard, turn.Board);
			Assert.NotEqual(defaultBallBeforeExecute, turn.BallBeforeExecute);
			Assert.Equal(defaultBallBeforeExecute.Position, turn.BallBeforeExecute.Position);
			Assert.Equal(defaultBallBeforeExecute.Velocity, turn.BallBeforeExecute.Velocity);
			Assert.Equal(defaultBallBeforeExecute.Acceleration, turn.BallBeforeExecute.Acceleration);
			Assert.Equal(null, turn.BallAfterExecute);
		}

		public static IEnumerable<object[]> ExecuteTestData
		{
			get
			{
				//                          beforePosition         inputAcceleration       expectedPosition
				// 通常の移動
				yield return new object[] { new Point(0.20, 0.30), new Vector(0.10, 0.30), new Point(0.30, 0.60) };
				// 穴に落ちる移動
				yield return new object[] { new Point(0.20, 0.30), new Vector(1.00, 1.00), new Point(1.20, 1.30) };
				// 穴を飛び越える移動
				yield return new object[] { new Point(0.20, 0.30), new Vector(2.80, 2.70), new Point(3.00, 3.00) };
				// 盤面の外に落ちる移動(負方向)
				yield return new object[] { new Point(0.20, 0.30), new Vector(-0.21, -0.31), new Point(-0.01, -0.01) };
				// 盤面の外に落ちる移動(正方向)
				yield return new object[] { new Point(0.20, 0.30), new Vector(4.80, 4.70), new Point(5.00, 5.00) };
				// 盤面ぎりぎりからの移動(xが小さい側)
				yield return new object[] { new Point(0.00, 0.30), new Vector(0.10, 0.30), new Point(0.10, 0.60) };
				// 盤面ぎりぎりからの移動(xが大きい側)
				yield return new object[] { new Point(4.99, 0.30), new Vector(-0.10, 0.30), new Point(4.89, 0.60) };
				// 盤面ぎりぎりからの移動(yが小さい側)
				yield return new object[] { new Point(0.20, 0.00), new Vector(0.10, 0.30), new Point(0.30, 0.30) };
				// 盤面ぎりぎりからの移動(yが大きい側)
				yield return new object[] { new Point(0.20, 4.99), new Vector(0.10, -0.30), new Point(0.30, 4.69) };
				// 穴ぎりぎりからの移動(穴の渕のうちxが小さい側)
				yield return new object[] { new Point(0.99, 1.50), new Vector(-0.10, 0.30), new Point(0.89, 1.80) };
				// 穴ぎりぎりからの移動(穴の渕のうちxが大きい側)
				yield return new object[] { new Point(3.00, 1.50), new Vector(0.10, 0.30), new Point(3.10, 1.80) };
				// 穴ぎりぎりからの移動(穴の渕のうちyが小さい側)
				yield return new object[] { new Point(1.50, 0.99), new Vector(0.10, -0.30), new Point(1.60, 0.69) };
				// 穴ぎりぎりからの移動(穴の渕のうちyが大きい側)
				yield return new object[] { new Point(1.50, 3.00), new Vector(0.10, 0.30), new Point(1.60, 3.30) };
				// ゴールぎりぎりからの移動(ゴールの渕のうちxが小さい側)
				yield return new object[] { new Point(2.99, 3.50), new Vector(0.10, 0.30), new Point(3.09, 3.80) };
				// ゴールぎりぎりからの移動(ゴールの渕のうちxが大きい側)
				yield return new object[] { new Point(4.00, 3.50), new Vector(0.10, 0.30), new Point(4.10, 3.80) };
				// ゴールぎりぎりからの移動(ゴールの渕のうちyが小さい側)
				yield return new object[] { new Point(3.50, 2.99), new Vector(0.10, 0.30), new Point(3.60, 3.29) };
				// ゴールぎりぎりからの移動(ゴールの渕のうちyが大きい側)
				yield return new object[] { new Point(3.50, 4.00), new Vector(0.10, 0.30), new Point(3.60, 4.30) };
			}
		}

		[Theory(DisplayName = "Executeの正常な実行", Skip = "未実装")]
		[MemberData("ExecuteTestData")]
		public void ExecuteTest(Point beforePosition, Vector inputAcceleration, Point expectedPosition)
		{
			Ball before_ball = new Ball();
			before_ball.SetPosition(beforePosition);
			Turn turn = new Turn(defaultBoard, before_ball);
			turn.InputAcceleration = inputAcceleration;

			turn.Execute();

			Assert.NotNull(turn.BallAfterExecute);
			// 計算の過程で誤差が出るはず. 精度指定して比較する.
			Assert.Equal(expectedPosition.X, turn.BallAfterExecute.Position.X, 2);
			Assert.Equal(expectedPosition.Y, turn.BallAfterExecute.Position.Y, 2);
		}

		public static IEnumerable<Point> ExecuteTest_AfterFinishData
		{
			get
			{
				yield return new Point(1.00, 1.50);		// ぎりぎり穴に落ちてる(穴の渕のうちxが小さい側)
				yield return new Point(2.99, 1.50);		// ぎりぎり穴に落ちてる(穴の渕のうちxが大きい側)
				yield return new Point(1.50, 1.00);		// ぎりぎり穴に落ちてる(穴の渕のうちyが小さい側)
				yield return new Point(1.50, 2.99);		// ぎりぎり穴に落ちてる(穴の渕のうちyが大きい側)
				yield return new Point(-0.01, 0.50);	// ぎりぎり盤面外(盤面の渕のうちxが小さい側)
				yield return new Point(5.00, 0.50);		// ぎりぎり盤面外(盤面の渕のうちxが大きい側)
				yield return new Point(0.05, -0.01);	// ぎりぎり盤面外(盤面の渕のうちyが小さい側)
				yield return new Point(0.05, 5.00);		// ぎりぎり盤面外(盤面の渕のうちyが大きい側)
				yield return new Point(3.00, 3.50);		// ぎりぎりゴール(ゴールの渕のうちxが小さい側)
				yield return new Point(3.99, 3.50);		// ぎりぎりゴール(ゴールの渕のうちxが大きい側)
				yield return new Point(3.50, 3.00);		// ぎりぎりゴール(ゴールの渕のうちyが小さい側)
				yield return new Point(3.50, 3.99);		// ぎりぎりゴール(ゴールの渕のうちyが大きい側)
			}
		}

		[Theory(DisplayName = "Executeした時に, ボールが盤面に乗っていなかったら, ボールの状態は変わらないこと", Skip = "未実装")]
		public void ExecuteTest_AfterFinish(Point beforePosition)
		{
			Turn turn = new Turn(defaultBoard, defaultBallBeforeExecute);
			defaultBallBeforeExecute.SetPosition(beforePosition);
			turn.Execute();

			Assert.Equal(turn.BallAfterExecute.Position, beforePosition);
			Assert.Equal(turn.BallAfterExecute.Velocity, defaultBallBeforeExecute.Velocity);
			Assert.Equal(turn.BallAfterExecute.Acceleration, defaultBallBeforeExecute.Acceleration);
		}
	}
}

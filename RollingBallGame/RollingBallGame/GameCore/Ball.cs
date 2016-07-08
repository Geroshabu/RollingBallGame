using System;
using System.Windows;

namespace RollingBallGame.GameCore
{
	public struct GridPoint
	{
		public int X;
		public int Y;
		public GridPoint(int x, int y)
		{
			X = x;
			Y = y;
		}
		public override string ToString()
		{
			return X.ToString() + "," + Y.ToString();
		}
	}

	public class Ball : ICloneable
	{
		/// <summary>
		/// 現在位置
		/// </summary>
		public Point Position { get; private set; }
		/// <summary>
		/// マス目で数えた場合の位置
		/// </summary>
		public GridPoint GridPosition
		{
			get
			{
				GridPoint ret;
				ret.X = (int)Math.Floor(Position.X);
				ret.Y = (int)Math.Floor(Position.Y);
				return ret;
			}
		}

		/// <summary>
		/// 速度
		/// </summary>
		public Vector Velocity { get; private set; }

		/// <summary>
		/// 加速度
		/// </summary>
		public Vector Acceleration { get; private set; }

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public Ball()
		{
			Position = new Point();
			Velocity = new Vector();
			Acceleration = new Vector();
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="ball">コピー元</param>
		public Ball(Ball ball)
		{
			if (ball == null) { throw new ArgumentNullException("ball"); }

			Position = ball.Position;
			Velocity = ball.Velocity;
			Acceleration = ball.Acceleration;
		}

		/// <summary>
		/// 加速度を与え、ボールを1ターン分移動させる
		/// </summary>
		/// <param name="acceleration">ボールに与える加速度</param>
		public void Roll(Vector acceleration)
		{
			Acceleration = acceleration;

			Velocity = Vector.Add(Velocity, Acceleration);

			Position = Point.Add(Position, Velocity);
		}

		public override string ToString()
		{
			return "Pos:" + Position.ToString()
				   + "(Grid:" + GridPosition.ToString() + ")"
				   + "  Vel:" + Velocity.ToString()
				   + "  Accel:" + Acceleration.ToString();
		}

		public object Clone()
		{
			return new Ball(this);
		}
	}
}

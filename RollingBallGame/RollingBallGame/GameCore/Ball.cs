using System;
using System.Windows;

namespace RollingBallGame.GameCore
{
	public struct GridPoint
	{
		public int X;
		public int Y;
	}

	public class Ball
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
				ret.X = (int)Math.Round(Position.X);
				ret.Y = (int)Math.Round(Position.Y);
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
		/// 加速度を与え、ボールを1ターン分移動させる
		/// </summary>
		/// <param name="acceleration">ボールに与える加速度</param>
		public void Roll(Vector acceleration)
		{
			throw new NotImplementedException();
		}
	}
}

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
		/// ���݈ʒu
		/// </summary>
		public Point Position { get; private set; }
		/// <summary>
		/// �}�X�ڂŐ������ꍇ�̈ʒu
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
		/// ���x
		/// </summary>
		public Vector Velocity { get; private set; }

		/// <summary>
		/// �����x
		/// </summary>
		public Vector Acceleration { get; private set; }

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public Ball()
		{
			Position = new Point();
			Velocity = new Vector();
			Acceleration = new Vector();
		}

		/// <summary>
		/// �R�s�[�R���X�g���N�^
		/// </summary>
		/// <param name="ball">�R�s�[��</param>
		public Ball(Ball ball)
		{
			Position = ball.Position;
			Velocity = ball.Velocity;
			Acceleration = ball.Acceleration;
		}

		/// <summary>
		/// �����x��^���A�{�[����1�^�[�����ړ�������
		/// </summary>
		/// <param name="acceleration">�{�[���ɗ^��������x</param>
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

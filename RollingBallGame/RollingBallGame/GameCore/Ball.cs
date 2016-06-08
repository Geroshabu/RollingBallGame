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
				ret.X = (int)Math.Round(Position.X);
				ret.Y = (int)Math.Round(Position.Y);
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
		/// �����x��^���A�{�[����1�^�[�����ړ�������
		/// </summary>
		/// <param name="acceleration">�{�[���ɗ^��������x</param>
		public void Roll(Vector acceleration)
		{
			throw new NotImplementedException();
		}
	}
}

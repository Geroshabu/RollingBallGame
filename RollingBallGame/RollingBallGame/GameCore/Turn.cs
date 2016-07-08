using System;
using System.Windows;

namespace RollingBallGame.GameCore
{
	public class Turn
	{
		public Board Board { get; private set; }
		/// <summary>
		/// ���̃^�[���̎��s�O�̃{�[���̏��.
		/// </summary>
		public Ball BallBeforeExecute { get; private set; }
		/// <summary>
		/// ���̃^�[���̎��s��̃{�[���̏��.
		/// ���s����O��null.
		/// </summary>
		/// <seealso cref="Execute"/>
		public Ball BallAfterExecute { get; private set; }
		/// <summary>
		/// ���̃^�[�����ɗ^��������x.
		/// AI�����܂ł͂���ŊO����n���Ă��.
		/// AI���ł��������.
		/// </summary>
		public Vector InputAcceleration { get; set; }

		public Turn(Board board, Ball ball)
		{
			Board = board;
			BallBeforeExecute = (Ball)ball.Clone();
			BallAfterExecute = null;
		}

		/// <summary>
		/// ���̃^�[�������s����.
		/// ���s���, <see cref="BallAfterExecute"/>������s��̃{�[���̏�Ԃ��擾�\.
		/// �S�[�����Ă��邩, �{�[�������ɗ����Ă����ꍇ��, �{�[���̏�Ԃ͕ς��Ȃ�.
		/// </summary>
		public void Execute()
		{
			BallAfterExecute = BallBeforeExecute.Clone() as Ball;

			// Player thinking ...
			// �Ƃ肠����InputAcceleration�ŗ^����.

			BallAfterExecute.Roll(InputAcceleration);
			
			// �Ƃ肠�����\�������Ă݂�
			Console.WriteLine(BallAfterExecute.ToString());
			Cell current_cell = Board[BallAfterExecute.GridPosition.X, BallAfterExecute.GridPosition.Y];
			Console.WriteLine(current_cell.CellType);
		}
	}
}

using System;

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

		public Turn(Board board, Ball ball)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// ���̃^�[�������s����.
		/// ���s���, <see cref="BallAfterExecute"/>������s��̃{�[���̏�Ԃ��擾�\.
		/// </summary>
		public void Execute()
		{
			throw new NotImplementedException();
		}
	}
}

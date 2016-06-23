using System;

namespace RollingBallGame.GameCore
{
	public class Turn
	{
		public Board Board { get; private set; }
		/// <summary>
		/// このターンの実行前のボールの状態.
		/// </summary>
		public Ball BallBeforeExecute { get; private set; }
		/// <summary>
		/// このターンの実行後のボールの状態.
		/// 実行する前はnull.
		/// </summary>
		/// <seealso cref="Execute"/>
		public Ball BallAfterExecute { get; private set; }

		public Turn(Board board, Ball ball)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// このターンを実行する.
		/// 実行後は, <see cref="BallAfterExecute"/>から実行後のボールの状態が取得可能.
		/// </summary>
		public void Execute()
		{
			throw new NotImplementedException();
		}
	}
}

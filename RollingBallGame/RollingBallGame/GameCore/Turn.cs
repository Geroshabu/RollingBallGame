using System;
using System.Windows;

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
		/// <summary>
		/// このターン中に与える加速度.
		/// AIを作るまではこれで外から渡してやる.
		/// AIができたら消す.
		/// </summary>
		public Vector InputAcceleration { get; set; }

		public Turn(Board board, Ball ball)
		{
			Board = board;
			BallBeforeExecute = (Ball)ball.Clone();
			BallAfterExecute = null;
		}

		/// <summary>
		/// このターンを実行する.
		/// 実行後は, <see cref="BallAfterExecute"/>から実行後のボールの状態が取得可能.
		/// ゴールしているか, ボールが穴に落ちていた場合は, ボールの状態は変わらない.
		/// </summary>
		public void Execute()
		{
			throw new NotImplementedException();
		}
	}
}

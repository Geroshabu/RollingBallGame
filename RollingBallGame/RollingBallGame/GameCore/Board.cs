using System;
using System.Diagnostics;

namespace RollingBallGame.GameCore
{
	public class Board
	{
		private Cell[,] _Cells = null;

		public uint Width { get; private set; }
		public uint Height { get; private set; }

		/// <summary>
		/// この盤面を描画する.
		/// </summary>
		public void Draw()
		{
			Debug.Assert(_Cells != null);

			for (int r = 0; r < Height; r++)
			{
				for (int c = 0; c < Width; c++)
				{
					_Cells[r, c].Draw();
				}
				Console.WriteLine("");
			}
		}
	}
}

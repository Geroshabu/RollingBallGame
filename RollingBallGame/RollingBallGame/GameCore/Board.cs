using System;
using System.Diagnostics;

namespace RollingBallGame.GameCore
{
	public class Board
	{
		private Cell[,] _Cells = null;

		/// <summary>
		/// 指定した座標のマスを得る.
		/// </summary>
		/// <param name="x">x座標(0-based)</param>
		/// <param name="y">y座標(0-based)</param>
		/// <returns></returns>
		public Cell this[int x, int y]
		{
			get
			{
				return _Cells[x, y];
			}
		}

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

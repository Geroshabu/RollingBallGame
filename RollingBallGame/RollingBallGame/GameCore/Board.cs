using System;
using System.Diagnostics;

namespace RollingBallGame.GameCore
{
	public class Board
	{
		private Cell[,] _Cells = null;

		/// <summary>
		/// 指定した座標のマスを得る.
		/// 盤面からはみ出した座標を指定した場合, <see cref="HoleCell"/>を返す.
		/// </summary>
		/// <param name="x">x座標(0-based)</param>
		/// <param name="y">y座標(0-based)</param>
		/// <returns></returns>
		public Cell this[int x, int y]
		{
			get
			{
				return (x >= 0 && x < Width && y >= 0 && y < Height) ?_Cells[x, y] : new HoleCell();
			}
		}

		public uint Width { get; private set; }
		public uint Height { get; private set; }

		/// <summary>
		/// 縺薙�ｮ逶､髱｢繧呈緒逕ｻ縺吶ｋ.
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

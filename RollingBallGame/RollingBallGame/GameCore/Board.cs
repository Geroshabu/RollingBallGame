using System;
using System.Diagnostics;

namespace RollingBallGame.GameCore
{
	public class Board
	{
		private Cell[,] _Cells = null;

		/// <summary>
		/// �w�肵�����W�̃}�X�𓾂�.
		/// �Ֆʂ���͂ݏo�������W���w�肵���ꍇ, <see cref="HoleCell"/>��Ԃ�.
		/// </summary>
		/// <param name="x">x���W(0-based)</param>
		/// <param name="y">y���W(0-based)</param>
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

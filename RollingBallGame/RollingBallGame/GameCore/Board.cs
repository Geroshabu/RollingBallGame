using System;
using System.Diagnostics;

namespace RollingBallGame.GameCore
{
	public enum CellType
	{
		Floor,
		Hole
	}

	public class Board
	{
		private CellType[,] _Cells = null;

		public uint Width { get; private set; }
		public uint Height { get; private set; }

		/// <summary>
		/// ‚±‚Ì”Õ–Ê‚ð•`‰æ‚·‚é.
		/// </summary>
		public void Draw()
		{
			Debug.Assert(_Cells != null);

			for (int r = 0; r < Height; r++)
			{
				for (int c = 0; c < Width; c++)
				{
					Console.Write(_Cells[r, c] == CellType.Floor ? "¡" : "@");
				}
				Console.WriteLine("");
			}
		}
	}
}

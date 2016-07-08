using System;

namespace RollingBallGame.GameCore
{
	public enum CellType
	{
		Floor,
		Hole,
		Goal
	}

	public abstract class Cell
	{
		/// <summary>
		/// このマスの描画(標準出力)
		/// </summary>
		public abstract void Draw();
		
		public CellType CellType { get; private set; }

		protected Cell(CellType cellType)
		{
			CellType = cellType;
		}
	}
}

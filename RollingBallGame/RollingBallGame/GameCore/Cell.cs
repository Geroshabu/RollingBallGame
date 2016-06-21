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
		/// ���̃}�X�̕`��(�W���o��)
		/// </summary>
		public abstract void Draw();
		
		public CellType CellType { get; private set; }

		protected Cell(CellType cellType)
		{
			CellType = cellType;
		}
	}
}

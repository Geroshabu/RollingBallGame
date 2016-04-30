using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}

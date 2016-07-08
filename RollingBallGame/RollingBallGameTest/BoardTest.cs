using System;
using System.Reflection;
using RollingBallGame.GameCore;
using Xunit;

namespace RollingBallGameTest
{
	/// <summary>
	/// privateなメンバにアクセスするというチート用拡張メソッド
	/// </summary>
	internal static class BoardExtentions
	{
		public static void Set_Cells(this Board board, Cell[,] _cells)
		{
			FieldInfo field_info = board.GetType().GetField("_Cells",
				BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
			field_info.SetValue(board, _cells);
		}

		public static void SetWidth(this Board board, uint width)
		{
			PropertyInfo property_info = board.GetType().GetProperty("Width",
				BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);
			property_info.SetValue(board, width);
		}

		public static void SetHeight(this Board board, uint height)
		{
			PropertyInfo property_info = board.GetType().GetProperty("Height",
				BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);
			property_info.SetValue(board, height);
		}
	}

	public class BoardTest
	{
		[Fact(DisplayName = "インデクサの正常処理")]
		public void IndexerTest()
		{
			uint width = 3;
			uint height = 3;
			Cell[,] cells = {
								{ new FloorCell(), new FloorCell(), new FloorCell() },
								{ new FloorCell(), new HoleCell(),  new FloorCell() },
								{ new FloorCell(), new FloorCell(), new HoleCell()  }
							};
			Board board = new Board();
			board.Set_Cells(cells);
			board.SetWidth(width);
			board.SetHeight(height);

			for (int y = 0; y < board.Height; y++)
			{
				for (int x = 0; x < board.Width; x++)
				{
					Assert.Equal(cells[x, y], board[x, y]);
				}
			}
		}

		[Theory(DisplayName = "インデクサで盤面外を指定した場合")]
		[InlineData(-1, 1)]	// x最小値はみだし
		[InlineData(3, 1)]	// x最大値はみだし
		[InlineData(1, -1)]	// y最小値はみだし
		[InlineData(1, 3)]	// y最大値はみだし
		public void IndexerTest_OutOfBoard(int x, int y)
		{
			uint width = 3;
			uint height = 3;
			Cell[,] cells = {
								{ new FloorCell(), new FloorCell(), new FloorCell() },
								{ new FloorCell(), new HoleCell(),  new FloorCell() },
								{ new FloorCell(), new FloorCell(), new HoleCell()  }
							};
			Board board = new Board();
			board.Set_Cells(cells);
			board.SetWidth(width);
			board.SetHeight(height);

			Assert.Equal(CellType.Hole, board[x, y].CellType);
		}
	}
}

namespace Aoc2021.Day04;

public class Day04 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        IEnumerable<string> fileInput = inputProvider.Read();

        int[] bingoCalls = fileInput.First().Split(',').Select(int.Parse).ToArray();
        string[] boardInput = fileInput.Skip(2).ToArray();

        List<Board> bingoBoards = BingoGame.Setup(boardInput);

        return BingoGame.GetWinningBoardScore(bingoCalls, bingoBoards).ToString();
    }

    public string SolveTwo(IInputProvider inputProvider)
    {
        IEnumerable<string> fileInput = inputProvider.Read();

        int[] bingoCalls = fileInput.First().Split(',').Select(int.Parse).ToArray();
        string[] boardInput = fileInput.Skip(2).ToArray();

        List<Board> bingoBoards = BingoGame.Setup(boardInput);

        return BingoGame.GetLosingBoard(bingoCalls, bingoBoards).ToString();

    }
}

public class BingoGame
{
    public static List<Board> Setup(IEnumerable<string> boardInput)
    {
        int boardDelimiterCount = boardInput.Count(x => x == string.Empty);
        List<Board> result = new();
        for (int i = 0; i <= boardDelimiterCount; i++)
        {
            IEnumerable<string> boardLines = boardInput.Skip((i * 5) + i).Take(5);
            result.Add(new Board(boardLines));
        }

        return result;
    }

    public static int GetWinningBoardScore(int[] calls, List<Board> boards)
    {
        foreach (int number in calls)
        {
            boards.ForEach(x => x.BingoCall(number));
            Board? winningBoard = boards.FirstOrDefault(x => x.HasWon);
            if (winningBoard != null)
            {
                var total = winningBoard.Total;
                return total * number;
            }
        }

        return -1;
    }
    public static int GetLosingBoard(int[] calls, List<Board> boards)
    {
        Board? lastBoard = null;
    
        List<Board> playableBoards = new(boards);
    
        foreach (int number in calls)
        {
            if (lastBoard != null)
            {
                lastBoard.BingoCall(number);
                if (lastBoard.HasWon)
                {
                    return number * lastBoard.Total;
                }
            }
            else
            {
                playableBoards.ForEach(board => board.BingoCall(number));
                playableBoards = playableBoards.Where(x => !x.HasWon).ToList();
                if (playableBoards.Count() == 1)
                {
                    lastBoard = playableBoards.First();
                }
            }
        }
    
        return -1;
    }
}

public class Board
{
    public Board(IEnumerable<string> rows)
    {
        Rows = rows.Select(x => x
                .Split(' ')
                .Where(x => x != string.Empty)
                .Select(x => new BoardCell(x))
                .ToList()
            )
            .ToList();
    }

    public void BingoCall(int number)
    {
        foreach (var row in Rows)
        {
            foreach (var cell in row)
            {
                if (cell.Number == number)
                {
                    cell.Called = true;
                }
            }
        }
    }

    public bool HasWon => HasWinningRow || HasWinningColumn;

    public int Total => Rows.Sum(x => x.Where(y => !y.Called).Sum(z => z.Number));

    public List<List<BoardCell>> Rows { get; set; } = new();
    public bool HasWinningRow => Rows.Any(x => x.All(y => y.Called));

    public bool HasWinningColumn
    {
        get
        {
            for (int i = 0; i < ColumnCount; i++)
            {
                bool b = Rows.Select(x => x[i]).All(x => x.Called);
                if (b)
                {
                    return true;
                }
            }

            return false;
        }
    }

    private int ColumnCount => Rows.FirstOrDefault()?.Count ?? 0;
}

public class BoardCell
{
    public BoardCell(string number)
    {
        Number = Int32.Parse(number);
    }

    public int Number { get; set; }
    public bool Called { get; set; }
}

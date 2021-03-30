using System;

namespace Chess
{
    class GameManager
    {
        private Board board;
        private char[] delimiters;

        public GameManager(Board board, char[] delimiters)
        {
            this.board = board;
            this.delimiters = delimiters;
        }

        public void Run()
        {
            Console.WriteLine();

            while (true)
            {
                board.Print();
                Move currentMove = GetUserInput();
                MoveOutcome result = TryPerformMove(currentMove);

                switch (result)
                {
                    case MoveOutcome.BlackWins:
                        Console.WriteLine("Black wins");
                        return;

                    case MoveOutcome.WhiteWins:
                        Console.WriteLine("White wins");
                        return;

                    case MoveOutcome.Illegal:
                        Console.Clear();
                        Console.WriteLine("This move is not legal");
                        break;

                    case MoveOutcome.Success:
                        board.ChangeTurns();
                        Console.Clear();
                        Console.WriteLine();
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private MoveOutcome TryPerformMove(Move currentMove)
        {
            if (!AreCoordsAdequate(currentMove)
              || !IsMovingOwnPiece(currentMove)
              || IsTakingOwnPiece(currentMove))
            {
                return MoveOutcome.Illegal;
            }
            
            if (IsNewPositionEmpty(currentMove))
            {
                return board.TryMove(currentMove);
            }

            return board.TryTake(currentMove);
        }

        private bool IsNewPositionEmpty(Move currentMove)
        {
            return board[currentMove.NewRow, currentMove.NewCol] == null;
        }

        private bool IsTakingOwnPiece(Move move)
        { 
            return board[move.NewRow, move.NewCol] != null
                && board[move.NewRow, move.NewCol].Owner == board.PlayerOnTurn;
        }

        private bool AreCoordsAdequate(Move move)
        {
            return move.CurrentRow >= 0 
                && move.CurrentCol >= 0
                && move.CurrentRow < Board.boardSize
                && move.CurrentCol < Board.boardSize
                && move.NewRow >= 0
                && move.NewCol >= 0
                && move.NewRow < Board.boardSize
                && move.NewCol < Board.boardSize;
        }

        private bool IsMovingOwnPiece(Move move)
        {
            return board[move.CurrentRow, move.CurrentCol] != null 
                && board[move.CurrentRow, move.CurrentCol].Owner == board.PlayerOnTurn;
        }

        private Move GetUserInput()
        {
            Console.WriteLine($"{Environment.NewLine} On turn is {board.PlayerOnTurn}");
            Console.WriteLine("Enter coordinates of the piece to be moved:");

            string[] input;
            input = Console.ReadLine().Split(delimiters);

            int currentRow = int.Parse(input[0]);
            int currentCol = int.Parse(input[1]);

            Console.WriteLine();
            Console.WriteLine("Enter coordinates of the new position of the piece:");
            input = Console.ReadLine().Split(delimiters);

            int newRow = int.Parse(input[0]);
            int newCol = int.Parse(input[1]);

            return new Move( currentRow, currentCol, newRow, newCol);
        }
    }
}

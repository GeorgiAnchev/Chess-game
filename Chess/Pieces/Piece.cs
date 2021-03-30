using System;

namespace Chess
{
    abstract class Piece
    {
        public Piece (Player player)
        {
            Owner = player;
        }

        public char DisplayCharacter
        {
            get;
            protected set;
        }

        public Player Owner {
            get; 
            protected set; 
        }
        
        public abstract bool CanMoveTo(Move move, Board board);

        public abstract bool CanAttackPosition(Move move, Board board);

        protected static bool IsOnSameDiagonal(int rowDiff, int colDiff)
        {
            return colDiff == rowDiff;
        }

        protected static bool IsOnSameRow(int rowDiff, int colDiff)
        {
            return rowDiff == 0 && colDiff != 0;
        }

        protected static bool IsOnSameCol(int rowDiff, int colDiff)
        {
            return rowDiff != 0 && colDiff == 0;
        }

        protected static bool HasLineOfSight(Move move, Board board)
        {
            int numberOfSteps = Math.Max(move.RowDiff, move.ColDiff);

            for (int i = 1; i < numberOfSteps; i++)
            {
                int row = move.CurrentRow + i * move.RowDirection;
                int col = move.CurrentCol + i * move.ColDirection;

                if (board[row, col] != null)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return DisplayCharacter.ToString();
        }
    }
}

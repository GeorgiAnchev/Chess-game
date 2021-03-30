
using System;

namespace Chess
{
    public struct Move
    {
        public Move(int currentRow, int currentCol, int newRow, int newCol)
        {
            CurrentRow = currentRow;
            CurrentCol = currentCol;
            NewRow = newRow;
            NewCol = newCol;
        }

        public int CurrentRow { get; }

        public int CurrentCol { get; }

        public int NewRow { get; }

        public int NewCol { get; }

        public int ColDiff
        {
            get
            {
                return Math.Abs(NewCol - CurrentCol);
            }
        }

        public int RowDiff
        {
            get
            {
                return Math.Abs(NewRow - CurrentRow);
            }
        }

        public int RowDirection
        {
            get
            {
                return Math.Sign(NewRow - CurrentRow);
            }
        }

        public int ColDirection
        {
            get
            {
                return Math.Sign(NewCol - CurrentCol);
            }
        }
    }
}

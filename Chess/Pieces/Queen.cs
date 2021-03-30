using System;

namespace Chess.Pieces
{
    class Queen: Piece
    {
        public Queen(Player player) : base(player)
        {
            DisplayCharacter = 'Q';
        }

        public override bool CanAttackPosition(Move move, Board board)
        {
            return CanMoveTo(move, board);
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            if (!IsOnSameDiagonal(move.RowDiff, move.ColDiff)
                && !IsOnSameRow(move.RowDiff, move.ColDiff)
                && !IsOnSameCol(move.RowDiff, move.ColDiff))
            {
                return false;
            }

            return HasLineOfSight(move, board);
        }
    }
}

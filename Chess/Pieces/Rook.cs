using System;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Player player) : base(player)
        {
            DisplayCharacter = 'R';
        }

        public override bool CanAttackPosition(Move move, Board board)
        {
            return CanMoveTo(move, board);
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            if (!IsOnSameRow(move.RowDiff, move.ColDiff)
                && !IsOnSameCol(move.RowDiff, move.ColDiff))
            {
                return false;
            }

            return HasLineOfSight(move, board);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Bishop: Piece
    {
        public Bishop(Player player) : base(player)
        {
            DisplayCharacter = 'B';
        }

        public override bool CanAttackPosition(Move move, Board board)
        {
            return CanMoveTo(move, board);
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            if (!IsOnSameDiagonal(move.RowDiff, move.ColDiff))
            {
                return false;
            }

            return HasLineOfSight(move, board);
        }

    }
}

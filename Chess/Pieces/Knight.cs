using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Knight: Piece
    {
        public Knight(Player player) : base(player)
        {
            DisplayCharacter = 'H';
        }

        public override bool CanAttackPosition(Move move, Board board)
        {
            return CanMoveTo(move, board);
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            return (move.RowDiff == 1 && move.ColDiff == 2) 
                || (move.RowDiff == 2 && move.ColDiff == 1);
        }
    }
}

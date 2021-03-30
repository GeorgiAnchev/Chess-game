using System;

namespace Chess.Pieces
{
    class Pawn: Piece
    {
        private const int startingPawnRowWhite = 1;
        private const int startingPawnRowBlack = 6;

        public Pawn(Player player) : base(player)
        {
            DisplayCharacter = 'P';
        }

        public override bool CanAttackPosition(Move move, Board board)
        {
            if (Owner == Player.Black && CanAttackDownwards(move))
            {
                return true;
            }

            if (Owner == Player.White && CanAttackUpwards(move))
            {
                return true;
            }
            
            return false;
        }

        public override bool CanMoveTo(Move move, Board board)
        {
            //todo: implement promotion, en passant
            if (Owner == Player.Black
                && (CanMoveDownwards(move)
                    || CanDoubleMoveDownwards(move, board)))
            {
                return true;
            }

            if (Owner == Player.White
                && (CanMoveUpwards(move)
                   || CanDoubleMoveUpwards(move, board)))
            {
                return true;
            }

            return false;
        }

        private static bool CanAttackUpwards(Move move)
        {
            return move.NewRow == move.CurrentRow - 1 && move.ColDiff == 1;
        }

        private static bool CanAttackDownwards(Move move)
        {
            return move.NewRow == move.CurrentRow + 1 && move.ColDiff == 1;
        }

        private static bool CanMoveUpwards(Move move)
        {
            return move.NewRow == move.CurrentRow - 1 && move.ColDiff == 0;
        }

        private static bool CanMoveDownwards(Move move)
        {
            return move.NewRow == move.CurrentRow + 1 && move.ColDiff == 0;
        }

        private static bool CanDoubleMoveUpwards(Move move, Board board)
        {
            return move.CurrentRow == startingPawnRowBlack
                && move.NewRow == move.CurrentRow - 2
                && move.ColDiff == 0
                && board[move.CurrentRow - 1, move.CurrentCol] == null;
        }

        private static bool CanDoubleMoveDownwards(Move move, Board board)
        {
            return move.CurrentRow == startingPawnRowWhite
                && move.NewRow == move.CurrentRow + 2
                && move.ColDiff == 0
                && board[move.CurrentRow + 1, move.CurrentCol] == null;
        }
    }
}

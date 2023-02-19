using System;

public class Board {
        char[,] board;
        int width =3, length=3;
        //creating the bioard
        public Board() {
            this.board = new char[width, length];
        
        int r = 0;
        for (int i = 0; i < width; i++) {
                for (int j = 0; j < length; j++) {
                    board[i, j] = '.';
                r++;
            }
            }
        }
        
        public char GetPosition(int x, int y){
            return board[x, y];
        }

        public void UpdateBoard(int x, int y, char symbol) {
            board[x, y] = symbol;
        }
        public void DisplayBoard(){
        int r = 0;
        for (int i = 0; i < width; i++) {
                for (int j = 0; j < length; j++) {
                    int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9};
                    Console.Write("(" + arr[r] + ")");
                    Console.Write(board[i,j]);
                    r++;
                    if (j == length-1)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write(" | ");   
                    }
                
            }
            Console.WriteLine();
        }
        }
    }
class game : Board{
    int x, y;
    const int WIDTH = 3, LENGTH = 3;
    public void validmove(ref Board board ,string player, bool x){
        start1:
        int p1;
        Console.Write(player + " enter your position: ");
            p1=Convert.ToInt32(Console.ReadLine());
        int p2=0;
        if (p1 >= 1 && p1 <= 3 && board.GetPosition(0 , p1-1) == '.')
        {
            p2 = 0;
            if (x)
            {
                board.UpdateBoard(p2, p1-1, 'X');
                
            }
            else
            {
                board.UpdateBoard(p2, p1-1, 'O');
                
            }
        }
        else if (p1 >= 4 && p1 <= 6 && board.GetPosition(1 , p1-4) == '.')
        {
            p2 = 1;
            if (x)
            {
                board.UpdateBoard(p2, p1-4, 'X');
                
            }
            else
            {
                board.UpdateBoard(p2, p1-4, 'O');
                
            }
        }
        else if (p1 >= 7 && p1 <= 9 && board.GetPosition(2 , p1-7) == '.')
        {
            p2 = 2;
            if (x)
            {
                board.UpdateBoard(p2, p1-7, 'X');
                
            }
            else
            {
                board.UpdateBoard(p2, p1-7, 'O');
                
            }
        }
        else{
            Console.WriteLine("invalid input!");
            goto start1;
        }
        
    }

    public bool IsWinner(Board board) {
            for (int i = 0; i < LENGTH; i++) {
                if (board.GetPosition(i, 0) == board.GetPosition(i, 1) && board.GetPosition(i, 2) == board.GetPosition(i, 0) && board.GetPosition(i, 0) != '.') {
                    return true;
                }
                if (board.GetPosition(0, i) == board.GetPosition(1, i) && board.GetPosition(2, i) == board.GetPosition(0, i) && board.GetPosition(0, i) != '.') {
                    return true;
                }

            }
            if (board.GetPosition(0, 0) == board.GetPosition(1, 1) && board.GetPosition(2, 2) == board.GetPosition(0, 0) && board.GetPosition(0, 0) != '.') {
                return true;
            }
            if (board.GetPosition(2, 0) == board.GetPosition(1, 1) && board.GetPosition(0, 2) == board.GetPosition(2, 0) && board.GetPosition(2, 0) != '.') {
                return true;
            }

            return false;
        }

        public bool IsDraw(Board board) {
            int count = 0;
        for (int i = 0; i < LENGTH; i++)
        {
            for (int j = 0; j < WIDTH; j++)
            {
                if (board.GetPosition(i, j) != '.') count++;
            }
        }

        if (count == 9) return true;

            return false;
        }
        public void Run(){
        Board board = new Board();
        string player1, player2;
        bool x = true;
        Console.Write("player1 enter your name: ");
        player1=Console.ReadLine();
        Console.Write("player2 enter your name: ");
        player2=Console.ReadLine();
        while(true){
            int p1, p2;
            board.DisplayBoard();
            validmove(ref board,player1,x);
            if (IsWinner(board) && x == true)
            {
                board.DisplayBoard();
                Console.WriteLine(player1 + " win");
                break;
            }
            
            if (IsDraw(board))
            {
                board.DisplayBoard();
                Console.WriteLine("Draw!");
                break;
            }
            board.DisplayBoard();
            x = !x;
            validmove(ref board,player2,x);
            if (IsWinner(board) && x == false)
            {
                board.DisplayBoard();
                Console.WriteLine(player2 + " win");
                break;
            }
            if (IsDraw(board))
            {
                board.DisplayBoard();
                Console.WriteLine("Draw!");
                break;
            }
            x = !x;
        }
        }
}

namespace TestPtoject{
    class Program{
        static void Main(string [] arg){
            game XO = new game();
            XO.Run();
        }
    }
}
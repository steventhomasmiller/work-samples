{
    class Program
    {
        private Maze maze = new Maze();
        Hero curby = new Hero();

        public void Play()
        {
            Boolean play = true;

            do
            {
                Console.Clear();
                maze.Draw(curby);

                MoveHero();

                if (maze.IsEnd(curby.GetX(), curby.GetY()))
                {
                    if (maze.AreMoreLevels())
                    {
                        curby.Reset();
                        maze.NextLevel();
                    }

                    else play = false;
                }

            } while (play == true);

            Console.Clear();
            Goodbye();
            
        }

        public void MoveHero()
        {
            //setups ability to read the arrow keys
            ConsoleKeyInfo readKey = Console.ReadKey(true);

            if (readKey.Key == ConsoleKey.RightArrow &&
                maze.PointIsFree(curby.GetX() + 1, curby.GetY()))   //if they entered the right key
            {
                curby.MoveRight();
            }
            else if (readKey.Key == ConsoleKey.LeftArrow &&
                maze.PointIsFree(curby.GetX() - 1, curby.GetY()))
            {
                curby.MoveLeft();
            }
            else if (readKey.Key == ConsoleKey.UpArrow &&
                maze.PointIsFree(curby.GetX(), curby.GetY() - 1))
            {
                curby.MoveUp();
            }
            else if (readKey.Key == ConsoleKey.DownArrow &&
                maze.PointIsFree(curby.GetX(), curby.GetY() + 1))
            {
                curby.MoveDown();
            }
            else
            {
                Console.Beep();
                
                String bumpSound = @"smb3_bump.wav";
                var sound1 = new System.Media.SoundPlayer(bumpSound);
                sound1.PlaySync(); 
            }

            if (maze.PointIsMoney(curby.GetX(), curby.GetY()))
            {
                curby.AddScore();
                maze.RemoveMoney(curby.GetX(), curby.GetY());

                String coinSound = @"smb3_coin.wav";
               var sound2 = new System.Media.SoundPlayer(coinSound);
               sound2.PlaySync(); 
                
            }

        public void Goodbye()
        {
            Console.WriteLine("\nDid you ever know that you're my hero?");
            Console.WriteLine("\nAnd everything I would like to be?");
            Console.WriteLine("\nI can fly higher than a seagull.");
            Console.WriteLine("\nBecause you are the ... the ... the ...");
            Console.WriteLine("\nHuh, I forgot how that goes. Anyway, congrats on reaching the end of the game.");
            Console.WriteLine("\nHere's a smiley face for you troubles: :-)");
            Console.WriteLine("\nAnd I suppose you want to know your score as well.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou can tell your friends this is how well you did: " + curby.GetScore() + ", as in that many points.");   
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Play();
            Console.ReadLine();
        }
    }
}

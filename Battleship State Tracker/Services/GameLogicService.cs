using Battleship_State_Tracker.Models;

namespace Battleship_State_Tracker.Services
{
    public class GameLogicService
    {
        int[] numberArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        char[] lettersArray = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };


        public List<Boat> CreateStandardFloat()
        {
            /* Will be better with a builder patter */

            return new List<Boat>()
            {
                new Boat()
                {
                    Size =  2
                },
                new Boat()
                {
                    Size =  3
                },
                new Boat()
                {
                    Size =  3
                },
                new Boat()
                {
                    Size =  5
                },
            };
        }

        public Boat? CheckForHits(Position shootPosition, List<Boat> boats)
        {
            foreach (var boat in boats)
            {
                List<Position> positions = new List<Position>();

                // Means the boat is placed ---> direction
                if (boat.HeadPos.Number < boat.TailPos.Number)
                {
                    var headIndex = Array.IndexOf(numberArray, boat.HeadPos.Number);

                    for (int i = headIndex; i < headIndex + boat.Size; i++)
                    {
                        positions.Add(new Position() { Letter = boat.HeadPos.Letter, Number = i });
                    }
                }

                // Means the boat is placed <--- direction
                if (boat.HeadPos.Number > boat.TailPos.Number)
                {
                    var tailIndex = Array.IndexOf(numberArray, boat.TailPos.Number);

                    for (int i = tailIndex; i > tailIndex + boat.Size; i--)
                    {
                        positions.Add(new Position() { Letter = boat.HeadPos.Letter, Number = i });
                    }
                }
                // Means the boat is placed facing up to down direction.
                if (Array.IndexOf(lettersArray, boat.HeadPos.Letter) < Array.IndexOf(lettersArray, boat.TailPos.Letter))
                {
                    var headIndex = Array.IndexOf(lettersArray, boat.HeadPos.Letter);

                    for (int i = headIndex; i < headIndex + boat.Size; i++)
                    {
                        positions.Add(new Position() { Letter = boat.HeadPos.Letter, Number = i });
                    }
                }
                // Means the boat is placed facing down to up direction.

                if (Array.IndexOf(lettersArray, boat.HeadPos.Letter) > Array.IndexOf(lettersArray, boat.TailPos.Letter))
                {
                    var tailIndex = Array.IndexOf(numberArray, boat.TailPos.Number);

                    for (int i = tailIndex; i > tailIndex + boat.Size; i--)
                    {
                        positions.Add(new Position() { Letter = boat.HeadPos.Letter, Number = i });
                    }
                }


                if (positions.Contains(shootPosition))
                {
                    return boat;
                }
            }

            return null;
        }
    }
}

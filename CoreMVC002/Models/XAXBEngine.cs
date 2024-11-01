using System.Collections;

namespace CoreMVC002.Models
{
    public class XAXBEngine
    {
        public string Secret { get; set; }
        public string Guess { get; set; }
        public string Result { get; set; }
        public List<string> GuessHistory { get; set; }
        public int Count { get; set; } = 0;

        public XAXBEngine()
        {
            // TODO 0 - randomly 
            string randomSecret = "1234";
            //
            Secret = randomSecret;
            Guess = string.Empty;
            Result = string.Empty;
            GuessHistory = new List<string>();
        }

        public XAXBEngine(string secretNumber)
        {
            Secret = secretNumber;
            Guess = string.Empty;
            Result = string.Empty;
            GuessHistory = new List<string>();
        }
        //
        public int numOfA(string guessNumber)
        {
            // TODO 1
            return 0;
        }
        //
        public int numOfB(string guessNumber)
        {
            // TODO 2
            return 0;
        }
        //
        public bool IsGameOver(string guessNumber)
        {
            // TODO 3
            return false;
        }
    }

}

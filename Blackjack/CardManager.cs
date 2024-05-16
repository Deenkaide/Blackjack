namespace Blackjack
{
    class CardManager
    {
        public static int randomNumber;
        public static Random rand = new Random();
        public static int card;
        public static int cardNumber = 51;

        public static int[] cards = [2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11,
                                     2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11,
                                     2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11,
                                     2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11];

        public static void CardMixer()
        {
            Random.Shared.Shuffle(cards);
        }

        public static void CardDispenser()
        {
            card = cards[cardNumber];
            cardNumber -= 1;
        }
    }
}

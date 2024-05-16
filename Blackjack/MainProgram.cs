namespace Blackjack
{
    class MainProgram
    {
        public static bool isWork = true;

        public static int dealerSum;
        public static int playerSum;

        public static void Main()
        {
            Console.WriteLine("Приступим?\t(Да/Нет)");
            string answer;
            answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "да":
                    Hands();
                    break;
                case "нет":
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("Ошибка. Повторите"); Main();
                    break;
            }

            while (isWork)
            {
                Start();
            }
        }

        public static void Start()
        {
            dealerSum = 0;
            playerSum = 0;

            string answer;
            
            answer = Console.ReadLine().ToLower();

            switch (answer)
            {
                case "да":
                    Hands();
                    break;
                case "нет":
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("Ошибка. Повторите"); Start();
                    break;
            }
        }

        public static void Resume()
        {
            CardManager.cardNumber = 51;
            dealerSum = 0;
            playerSum = 0;

            Console.WriteLine("Желаете продолжить?\t(Да/Нет)");
            string answer;
            answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "да":
                    Console.Clear();

                    Hands();
                    break;
                case "нет":
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("Ошибка. Повторите"); Start();
                    break;
            }
        }



        public static void Hands()
        {
            CardManager.CardMixer();
            HandsStep1();
            HandsStep2();

            Console.WriteLine($"Подсчёт...\nВаша сумма карта: {playerSum}");

            MoreCard();


            if (dealerSum < 17)
            {
                int dealerCard;
                CardManager.CardDispenser();
                dealerCard = CardManager.card;
                dealerSum += dealerCard;
                Console.WriteLine($"Диллер добрал карту...");
            }


            Resault();
        }

        public static void HandsStep1()
        {
            int dealerCard1;
            int playerCard1;
            Console.WriteLine($"Раздача карт...");
            CardManager.CardDispenser();
            dealerCard1 = CardManager.card;
            dealerSum += dealerCard1;
            Console.WriteLine($"Первая карта Диллера: {dealerCard1}");

            CardManager.CardDispenser();
            playerCard1 = CardManager.card;
            playerSum += playerCard1;
            Console.WriteLine($"Первая ваша карта: {playerCard1} \n");
        }

        public static void HandsStep2()
        {
            int dealerCard2;
            int playerCard2;
            CardManager.CardDispenser();
            dealerCard2 = CardManager.card;
            dealerSum += dealerCard2;
            Console.WriteLine($"Вторая карта Диллера: X");

            CardManager.CardDispenser();
            playerCard2 = CardManager.card;
            playerSum += playerCard2;
            Console.WriteLine($"Вторая ваша карта: {playerCard2} \n");
        }

        public static void MoreCard()
        {
            string answer = "ошибка";
            Console.WriteLine($"Желаете взять ещё одну карту?\t(Да/Нет)");
            answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "да":
                    AddCard();
                    break;
                case "нет":
                    return;
                default:
                    Console.WriteLine("Ошибка. Повторите"); MoreCard();
                    break;
            }
        }

        public static void AddCard()
        {
            int playerCard3;
            CardManager.CardDispenser();
            playerCard3 = CardManager.card;
            playerSum += playerCard3;
            Console.WriteLine($"Ваша дополнительная карта: {playerCard3}");
        }



        public static void Resault()
        {
            Console.WriteLine($"Рука диллера: {dealerSum}");
            Console.WriteLine($"Рука игрока: {playerSum}");

            switch (playerSum)
            {
                case 21:
                    Console.WriteLine("Блек-джек");
                    break;
                case > 21:// dealerSum:
                    Console.WriteLine("Перебор");
                    break;
                default:
                    if (dealerSum > 21)
                    {
                        Console.WriteLine("Перебор диллера");
                    }
                    else if (dealerSum == 21)
                    {
                        Console.WriteLine("Блек-джек диллера");
                    }
                    else if (playerSum < dealerSum)
                    {
                        Console.WriteLine("Победа диллера");
                    }
                    else if (playerSum > dealerSum)
                    {
                        Console.WriteLine("Победа игрока");
                    }
                    else
                    {
                        Console.WriteLine("Ровно");
                    }

                    break;
            }
            Resume();
        }
    }
}



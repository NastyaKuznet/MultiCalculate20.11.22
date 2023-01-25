using System.Text;

namespace Homework
{
    public static class MultiCalculator
    {
        public static void Main()
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            string[] textMenu = new string[12] {"Программа написана Кузнецовой Анастасией При-101.", "\n",
                "\tКалькулятор для пятикласника", "\n",
                "Для выбора задачи напишите соответствующую цифру в консоль.",
                "1.   Перевод целых чисел из любой системы счисления в любую другую.",
                "2.   Перевод целых чисел в римскую систему счисления.",
                "3.   Сложение в произвольной системе счисления.",
                "4.   Вычитание в произвольной системе счисления.",
                "5.   Умножение в произвольной системе счисления.","Для выхода напишите цифру 7.", "\n"};

            for (int i = 0; i < textMenu.Length; i++)
            {
                Console.WriteLine(textMenu[i]);
            }

            ChooseTheNextAction(false);
        }
        public static void EraseScreen(int replay)
        {
            for (int i = 0; i < 20 * replay; i++)
            {
                Console.SetCursorPosition(0, i);
                for (int j = 0; j < 200; j++)
                {
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);
        }
        public static string FoolProof(string[] alphabet)
        {
            string command;
            while (true)
            {
                command = Console.ReadLine();
                if (Array.IndexOf(alphabet, command) != -1)
                {
                    return command;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("В консоль было введенно неверное значение. Повторите попытку:                    ");
                Console.SetCursorPosition(61, Console.CursorTop);
            }
        }
        public static string FoolProofAlfabetNumSS(char[] alphabet, int baze)
        {
            string command;

            while (true)
            {
                bool flag = true;
                command = Console.ReadLine();
                for (int i = 0; i < command.Length; i++)
                {
                    if (SymbolInNumber(command[i]) >= baze)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write("В консоль было введенно неверное значение. Повторите попытку:                        ");
                        Console.SetCursorPosition(61, Console.CursorTop);
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return command;
                }
            }
        }
        public static string FoolProofAlfabet(char[] alphabet)
        {
            string command;

            while (true)
            {
                bool flag = true;
                command = Console.ReadLine();
                for (int i = 0; i < command.Length; i++)
                {
                    if (Array.IndexOf(alphabet, command[i]) == -1)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write("В консоль было введенно неверное значение. Повторите попытку:                  ");
                        Console.SetCursorPosition(61, Console.CursorTop);
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return command;
                }
            }
        }
        public static int FoolProofInt(int start, int end)
        {
            string command;
            while (true)
            {
                command = Console.ReadLine();
                if (int.TryParse(command, out int result) && result >= start && result <= end)
                {
                    return result;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("В консоль было введенно неверное значение. Повторите попытку:                ");
                Console.SetCursorPosition(61, Console.CursorTop);
            }
        }

        public static char[] alfabet = AlfabetTask1();
        public static int SymbolInNumber(char num)
        {
            int digit = 0;
            if (num >= '0' && num <= '9')
            {
                digit = num - '0';
            }
            if (num >= 'A' && num <= 'Z')
            {
                digit = num - 55;
            }
            if (num >= 'a' && num <= 'n')
            {
                digit = num - 61;
            }
            return digit;
        }
        public static void Task1()
        {
            Console.WriteLine("\n1.   Перевод целых чисел из любой системы счисления в любую другую. \n\nДопустимый алфавит для введенного числа: ");
            PrintAlfabet(alfabet);
            Console.WriteLine("\nМаксимальное значение СС: 50");
            Console.WriteLine("Введите основание СС введенного числа: ");
            int baze0 = FoolProofInt(2, 50);
            Console.WriteLine("Введите основание СС для перевода: ");
            int baze1 = FoolProofInt(2, 50);
            Console.WriteLine("Введите число: ");
            string num = FoolProofAlfabetNumSS(alfabet, baze0);


            Translation(num, baze0, baze1, alfabet);
            ChooseTheNextAction(true);
        }
        public static char[] AlfabetTask1()
        {
            char[] alfabet = new char[50];
            for (int i = 0; i <= 9; i++)
            {
                alfabet[i] = (char)(i + 48);
            }
            for (int i = 10; i <= 35; i++)
            {
                alfabet[i] = (char)(i + 55);
            }
            for (int i = 36; i <= 49; i++)
            {
                alfabet[i] = (char)(i + 61);
            }
            return alfabet;
        }
        public static void PrintAlfabet(char[] alfabet)
        {
            foreach (char el in alfabet)
            {
                Console.Write(el);
            }
        }
        public static void Translation(string num, int baze0, int baze1, char[] alfabet)
        {
            string result = "";
            if (baze0 == 10)
            {
                result = TranslationFromTen(num, baze1, alfabet);
            }
            else
            {
                if (baze1 != 10)
                {
                    Console.WriteLine($"Для перевода числа из {baze0} сс в {baze1} сс нужно сперва перевести число в 10 сс (1), а потом уже в нужную сс (2).\n(1)");
                    result = TranslationInTen(num, baze0, alfabet);
                    Console.WriteLine("(2)");
                    result = TranslationFromTen(result, baze1, alfabet);
                }
                else
                {
                    result = TranslationInTen(num, baze0, alfabet);
                }
            }
            Console.WriteLine($"\nРезультат перевода равен: {result}");
        }
        public static string TranslationFromTen(string num, int baze, char[] alfabet)
        {
            Console.WriteLine($"Для перевода числа из 10 сс в {baze} сс нужно делить число {num} на основание нужной сс равное {baze}," +
                $" \nа остатки от деления записывать в новое число с конца.");

            StringBuilder result = new StringBuilder();
            int number = int.Parse(num);
            int remainder;
            while (number > 0)
            {
                //remainder - остаток
                remainder = number % baze;
                Console.WriteLine($"Остаток от деления числа равен {remainder}:   {number} % {baze} = {remainder};");
                result.Insert(0, alfabet[remainder]);
                Console.WriteLine($"Теперь введеное число равно {number / baze}:    {number} // {baze} = {number / baze}." +
                    $" \nА остаток от деления записываем в начало нового числа:   {result}.\n");
                number /= baze;
            }
            return result.ToString();
        }
        public static string TranslationInTen(string num, int baze, char[] alfabet)
        {
            Console.WriteLine($"Для перевода числа из {baze} сс в 10 сс сперва нужно обозначить позиции цифр в числе следующим образом справа налево.");
            PositionNumberForTask1(num);
            Console.WriteLine($"Теперь нам нужно каждую цифру умножать на основание сс равное {baze} в степени поцизии цифры. " +
                $"Итоговым числом ялвяется сумма этих произвежений.");
            int result = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int digit = SymbolInNumber(num[i]);
                Console.Write($"{digit} * {baze}^{num.Length - i - 1}");
                if (i != num.Length - 1)
                    Console.Write(" + ");
                else
                    Console.Write(" = ");
                result += (int)(digit * Math.Pow(baze, (num.Length - i - 1)));
            }
            Console.WriteLine(result);
            return result.ToString();
        }
        public static void PositionNumberForTask1(string number)
        {
            for (int i = 1; i <= number.Length; i++)
            {
                Console.Write(number.Length - i);
            }
            Console.WriteLine();
            Console.WriteLine(number);
        }

        public static void ChooseTheNextAction(bool needText)
        {
            if (needText)
            {
                Console.WriteLine("Для перехода на другое задание введите номер задания.\nДля выхода в главное меню напишите цифру 6.\nДля завершения программы в целом - 7");
            }
            string command = FoolProof(new string[] { "1", "2", "3", "4", "5", "6", "7" });
            EraseScreen(10);

            switch (command)
            {
                case ("1"):
                    Task1();
                    break;
                case ("2"):
                    Task2();
                    break;
                case ("3"):
                    Task3();
                    break;
                case ("4"):
                    Task4();
                    break;
                case ("5"):
                    Task5();
                    break;
                case ("6"):
                    MainMenu();
                    break;
                case ("7"):
                    Environment.Exit(0);
                    break;
            }
        }


        public static char[] alfabetRimFool = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
        public static string[] alfabetRim = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        public static int[] numTranslate = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        public static void Task2()
        {
            Console.WriteLine($"\n2.   Перевод целых чисел в римскую систему счисления. Перевод из римской системы счисления любых чисел. " +
                $"\n\nДопустим ввод чисел от 1 до 5000." +
                $"Алфавит римской сс: MDCLXVI.\n" +
                $"Для перевода из римской сс введените \"Rim\", для перевода из 10 сс \"10\".");

            string command = FoolProof(new string[] { "10", "Rim" });

            Console.Write("Введите число ");

            if (command == "10")
            {
                int num = FoolProofInt(1, 5000);
                TranslateInRim(num);
            }
            else if (command == "Rim")
            {
                string numst = FoolProofAlfabet(alfabetRimFool);
                TranslateFromRim(numst);
            }
            ChooseTheNextAction(true);
        }
        public static void TranslateInRim(int num)
        {
            Console.WriteLine($"Для перевода числа в римскую сс нужно разложить число на сумму определённых чисел,\n" +
                $"которые соотносятся с определнным знаком в римском алфавите.\n\n" +
                $"Оснновные символы римской сс: M - 1000, D - 500, C - 100, L - 50, X - 10, V - 5, I - 1.\n" +
                $"Для упрощения понимания также добавим такие символы: CM - 900, CD - 400, XC - 90, XL - 40, IX - 9, IV - 4,\n" +
                $"и будем сравнивать число с элементами алфавита.\n");

            StringBuilder result = new StringBuilder();
            int i = 0;
            while (num > 0)
            {
                Console.WriteLine($"Сравним текущее число со значением символа. {num} >= {numTranslate[i]}?\n");
                if (num >= numTranslate[i])
                {
                    num -= numTranslate[i];
                    result.Append(alfabetRim[i]);
                    Console.WriteLine($"Да. Вычтем это значение из числа, получив {num}, и запишем нужный символ в результат {result}.\n");
                }
                else
                {
                    Console.WriteLine($"Нет. Проверяем следующий символ.\n");
                    i++;
                }
            }
            Console.WriteLine($"Результат равен: {result}.");
        }
        public static void TranslateFromRim(string num)
        {
            Console.WriteLine($"Для перевода числа из римской сс нам достаточно суммировать цифры, соответствующие символам.\n" +
                $"Оснновные символы римской сс: M - 1000, D - 500, C - 100, L - 50, X - 10, V - 5, I - 1.\n" +
                $"Однако нужно общать внимание на такие символы: CM - 900, CD - 400, XC - 90, XL - 40, IX - 9, IV - 4.\n");
            int result = 0;
            int i = 0;
            while (i < num.Length)
            {
                if (i != num.Length - 1 && Array.IndexOf(alfabetRimFool, num[i]) > Array.IndexOf(alfabetRimFool, num[i + 1]))
                {
                    StringBuilder el = new StringBuilder();
                    el.Append(num[i]);
                    el.Append(num[i + 1]);
                    result += numTranslate[Array.IndexOf(alfabetRim, el.ToString())];
                    i += 2;
                    Console.WriteLine($"Текущая пара символов {el} = {numTranslate[Array.IndexOf(alfabetRim, el.ToString())]}, а результат = {result}.");
                }
                else
                {
                    result += numTranslate[Array.IndexOf(alfabetRim, num[i].ToString())];
                    Console.WriteLine($"Текущий символ {num[i]} = {numTranslate[Array.IndexOf(alfabetRim, num[i].ToString())]}, а результат = {result}.");
                    i++;
                }
            }
            Console.WriteLine($"Результат равен: {result}.");
        }

        public static void Task3()
        {
            Console.Write($"3.   Сложение в произвольной системе счисления.\n" +
                $"Введите основание сс: ");
            int baze = FoolProofInt(2, 50);

            Console.Write("Введите первое число: ");
            string num1 = FoolProofAlfabetNumSS(alfabet, baze);
            Console.Write("Введите второе число: ");
            string num2 = FoolProofAlfabetNumSS(alfabet, baze);

            Sum(baze, num1, num2);

            ChooseTheNextAction(true);
        }
        public static void Sum(int baze, string num1, string num2)
        {
            if (num1.Length < num2.Length)
            {
                string c = num2;
                num2 = num1;
                num1 = c;
            }
            Console.WriteLine($"Будем складывать цифры по разрядно начиная с конца.\n" +
                $" +{num1}\n" +
                $"  {EmptyHead(num1, num2)}");
            ColumnWidth(num1.Length);
            num2 = ZeroHeadDown(num1, num2);

            int CursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, CursorTop + 1);
            Console.WriteLine("Начнем сложение.");
            CursorTop = Console.CursorTop;

            char sumDigit;
            int next0 = 0;
            int next1 = 0;
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int num1i = SymbolInNumber(num1[i]);
                int num2i = SymbolInNumber(num2[i]);
                sumDigit = alfabet[(num1i + num2i + next0) % baze];
                next0 = (num1i + num2i + next0) / baze;
                Console.SetCursorPosition(i + 2, 8);
                Console.Write(sumDigit);
                Console.SetCursorPosition(0, CursorTop);
                if (next0 > 0)
                {
                    if (next1 > 0)
                    {
                        Console.WriteLine($"При сложении получилось число длинною больше, чем один символ: {num1[i]} + {num2[i]} + {next1} = {next0}{sumDigit}.\n" +
                        $"Правый символ записываем {sumDigit}. А левый запоминаем, его добавим к следующему разряду {next0}.");
                    }
                    else
                    {
                        Console.WriteLine($"При сложении получилось число длинною больше, чем один символ: {num1[i]} + {num2[i]} = {next0}{sumDigit}.\n" +
                            $"Правый символ записываем {sumDigit}. А левый запоминаем, его добавим к следующему разряду {next0}.");
                    }
                    CursorTop = Console.CursorTop;
                }
                else if (next1 != 0)
                {
                    Console.WriteLine($"Не забываем про число из прошлой операции: {num1[i]} + {num2[i]} + {next1} = {alfabet[num1i + num2i + next1]}.\n");
                    CursorTop = Console.CursorTop;
                }
                else
                {
                    Console.WriteLine($"При сложении следующих цифр получим: {num1[i]} + {num2[i]} = {alfabet[num1i + num2i]}");
                    CursorTop = Console.CursorTop;
                }
                next1 = next0;
            }
            if (next1 != 0)
            {
                Console.WriteLine($"Не забываем про число из прошлой операции, записываем его {next1}.\n");
                Console.SetCursorPosition(1, 8);
                Console.Write(next1);
            }
            Console.SetCursorPosition(0, CursorTop + 0);
        }
        public static string EmptyHead(string numup, string numdown)
        {
            StringBuilder empty = new StringBuilder();
            for (int i = 0; i < numup.Length - numdown.Length; i++)
            {
                empty.Append(" ");
            }
            empty.Append(numdown);
            return empty.ToString();
        }
        public static string ZeroHeadDown(string numup, string numdown)
        {
            StringBuilder zero = new StringBuilder();
            for (int i = 0; i < numup.Length - numdown.Length; i++)
            {
                zero.Append("0");
            }
            zero.Append(numdown);
            return zero.ToString();
        }
        public static void ColumnWidth(int num)
        {
            StringBuilder dash = new StringBuilder();
            dash.Append("  ");
            for (int i = 0; i < num; i++)
            {
                dash.Append('-');
            }
            Console.WriteLine(dash.ToString());
        }

        public static void Task4()
        {
            Console.Write($"4.   Вычитание в произвольной системе счисления.\n" +
                $"Введите основание сс: ");
            int baze = FoolProofInt(2, 50);

            Console.Write("Введите первое число: ");
            string num1 = FoolProofAlfabetNumSS(alfabet, baze);
            Console.Write("Введите второе число: ");
            string num2 = FoolProofAlfabetNumSS(alfabet, baze);

            Subtraction(baze, num1, num2);
            ChooseTheNextAction(true);
        }
        public static void Subtraction(int baze, string num1, string num2)
        {
            if (num1.Length < num2.Length)
            {
                string c = num2;
                num2 = num1;
                num1 = c;
            }
            Console.WriteLine($"Будем вычитать цифры по разрядно начиная с конца.\n\n" +
                $" -{num1}\n" +
                $"  {EmptyHead(num1, num2)}");
            ColumnWidth(num1.Length);
            num2 = ZeroHeadDown(num1, num2);

            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.WriteLine("Начнем вычитание.");

            char minusDigit;
            int next0 = 0;
            int next1 = 0;
            char[] loan = new char[num1.Length];
            StringBuilder columnResult = new StringBuilder();

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int num1i = SymbolInNumber(num1[i]);
                int num2i = SymbolInNumber(num2[i]);
                if (num1i >= num2i || loan[i] >= num2i)
                {
                    if (num1i >= num2i && loan[i] == 0)
                    {
                        minusDigit = alfabet[num1i - num2i];
                        Console.WriteLine($"Если цифра первого числа больше второго, то просто выполняем вычитание: {num1[i]} - {num2[i]} = {minusDigit}");
                        columnResult.Insert(0, minusDigit);
                    }
                    else
                    {
                        int loani = SymbolInNumber(loan[i]);
                        minusDigit = alfabet[loani - num2i];
                        Console.WriteLine($"Т.к. происходил заём, то вычитаем из {loan[i]}, а не из {num1[i]}.\n" +
                            $"Если цифра первого числа больше второго, то просто выполняем вычитание: {loan[i]} - {num2[i]} = {minusDigit}");
                        columnResult.Insert(0, minusDigit);
                    }
                }
                else
                {
                    Console.WriteLine($"Если цифра первого числа меньше второго, то нам нужно занять единичку у предыдущей цирфы первого числа.");
                    loan = Loan(baze, num1, num2i);
                    int withALoan = baze + SymbolInNumber(loan[i]);
                    minusDigit = alfabet[withALoan - num2i];
                    Console.WriteLine($"Теперь выполняем вычитание: 1{loan[i]} - {num2[i]} = {minusDigit}");
                    columnResult.Insert(0, minusDigit);
                }
            }
            PrintColumnResult(columnResult.ToString(), num1.Length, Console.CursorLeft, Console.CursorTop);
        }
        public static void PrintColumnResult(string result, int lenNum, int cursorLeft, int cursorTop)
        {
            result = result.TrimStart('0');
            if (result == "")
            {
                result = "0";
            }
            Console.SetCursorPosition(lenNum + 2 - result.Length, 9);
            Console.Write(result);
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }
        public static char[] Loan(int baze, string num, int digit)
        {
            int n;
            char[] status = new char[num.Length];
            for (int i = num.Length - 2; i >= 0; i--)
            {
                n = SymbolInNumber(num[i]);
                if (n > 0)
                {
                    status[i] = alfabet[n - 1];
                    Console.WriteLine($"Теперь число заема равно {status[i]}.");
                    if (i < num.Length - 2)
                    {
                        Console.WriteLine($"А все предыдущие цифры принимают значение равное {alfabet[baze - 1]}.");
                    }
                    return status;
                }
                Console.WriteLine("Занять у этой цифры мы не можем, т.к. оно рано 0. Для этого проверим следующую.");
                status[i] = alfabet[baze - 1];

            }
            return status;
        }

        public static void Task5()
        {
            Console.Write($"5.   Умножение в произвольной системе счисления.\n" +
               $"Введите основание сс: ");
            int baze = FoolProofInt(2, 50);

            Console.Write("Введите первое число: ");
            string num1 = FoolProofAlfabetNumSS(alfabet, baze);
            Console.Write("Введите второе число: ");
            string num2 = FoolProofAlfabetNumSS(alfabet, baze);
            Product1(baze, num1, num2);
            ChooseTheNextAction(true);
        }
        public static void Product1(int baze, string num1, string num2)
        {
            if (num1.Length < num2.Length)
            {
                string c = num2;
                num2 = num1;
                num1 = c;
            }
            Console.WriteLine($"Будем умножать цифры по разрядно начиная с конца.\n");

            Console.SetCursorPosition(0, Console.CursorTop + 5 + num2.Length);
            Console.WriteLine("Начнем умножение.");
            string[] intermediateResults = new string[num2.Length];

            for (int i = num2.Length - 1; i >= 0; i--)
            {
                int num2i = SymbolInNumber(num2[i]);

                int next0 = 0;
                int next1 = 0;

                StringBuilder interResult = new StringBuilder();

                for (int j = num1.Length - 1; j >= 0; j--)
                {
                    int num1i = SymbolInNumber(num1[j]);

                    char prodDigit = alfabet[(num1i * num2i + next0) % baze];
                    next0 = (num1i * num2i + next0) / baze;

                    interResult.Insert(0, prodDigit);

                    if (next0 > 0)
                    {
                        if (next1 > 0)
                        {
                            Console.WriteLine($"При умножении получилось число длинною больше, чем один символ: {num1[j]} * {num2[i]} + {alfabet[next1]} = {alfabet[next0]}{prodDigit}.\n" +
                            $"Правый символ записываем {prodDigit}. А левый запоминаем, его добавим к следующему разряду {alfabet[next0]}.");
                        }
                        else
                        {
                            Console.WriteLine($"При умножении получилось число длинною больше, чем один символ: {num1[j]} * {num2[i]} = {alfabet[next0]}{prodDigit}.\n" +
                                $"Правый символ записываем {prodDigit}. А левый запоминаем, его добавим к следующему разряду {alfabet[next0]}.");
                        }
                    }
                    else if (next1 != 0)
                    {
                        Console.WriteLine($"Не забываем про число из прошлой операции: {num1[j]} * {num2[i]} + {alfabet[next1]} = {prodDigit}.\n");
                    }
                    else
                    {
                        Console.WriteLine($"При умножении следующих цифр получим: {num1[j]} * {num2[i]} = {prodDigit}");
                    }
                    next1 = next0;
                }
                if (next1 != 0)
                {
                    Console.WriteLine($"Не забываем про число из прошлой операции, записываем его {alfabet[next1]}.\n");
                    interResult.Insert(0, alfabet[next1]);
                }
                Console.WriteLine($"Получем: {interResult.ToString()}.");
                intermediateResults[num2.Length - i - 1] = interResult.ToString();
            }
            string prodResult;
            if (intermediateResults.Length > 1)
            {
                prodResult = Product2(baze, intermediateResults);
            }
            else
            {
                prodResult = intermediateResults[0];
            }
            int CursorTop0 = Console.CursorTop;
            WritterProd(num1, num2, intermediateResults, prodResult, CursorTop0);
        }
        public static string Product2(int baze, string[] results)
        {
            string sum = SumPr(baze, results[0], ZeroHeadUp(results[1], 1));
            Console.WriteLine($"Получем: {sum}.");
            for (int i = 1; i < results.Length - 1; i++)
            {
                sum = SumPr(baze, sum, ZeroHeadUp(results[i], i + 1));
                Console.WriteLine($"Получем: {sum}.");
            }
            return sum;
        }
        public static string ZeroHeadUp(string num, int count)
        {
            StringBuilder zero = new StringBuilder();
            zero.Append(num);
            for (int i = 0; i < count; i++)
            {
                zero.Append("0");
            }

            return zero.ToString();
        }
        public static string SumPr(int baze, string num1, string num2)
        {
            if (num1.Length < num2.Length)
            {
                string c = num2;
                num2 = num1;
                num1 = c;
            }

            Console.WriteLine($"Начнем сложение чисел {num1} и {num2}.");

            num2 = ZeroHeadDown(num1, num2);


            char sumDigit;
            int next0 = 0;
            int next1 = 0;
            StringBuilder result = new StringBuilder();
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int num1i = SymbolInNumber(num1[i]);
                int num2i = SymbolInNumber(num2[i]);
                sumDigit = alfabet[(num1i + num2i + next0) % baze];
                next0 = (num1i + num2i + next0) / baze;
                result.Insert(0, sumDigit);
                if (next0 > 0)
                {
                    if (next1 > 0)
                    {
                        Console.WriteLine($"При сложении получилось число длинною больше, чем один символ: {num1[i]} + {num2[i]} + {next1} = {next0}{sumDigit}.\n" +
                        $"Правый символ записываем {sumDigit}. А левый запоминаем, его добавим к следующему разряду {next0}.");
                    }
                    else
                    {
                        Console.WriteLine($"При сложении получилось число длинною больше, чем один символ: {num1[i]} + {num2[i]} = {next0}{sumDigit}.\n" +
                            $"Правый символ записываем {sumDigit}. А левый запоминаем, его добавим к следующему разряду {next0}.");
                    }
                }
                else if (next1 != 0)
                {
                    Console.WriteLine($"Не забываем про число из прошлой операции: {num1[i]} + {num2[i]} + {next1} = {alfabet[num1i + num2i + next1]}.\n");
                }
                else
                {
                    Console.WriteLine($"При сложении следующих цифр получим: {num1[i]} + {num2[i]} = {alfabet[num1i + num2i]}");
                }
                next1 = next0;
            }
            if (next1 != 0)
            {
                Console.WriteLine($"Не забываем про число из прошлой операции, записываем его {next1}.");
                result.Insert(0, next1);
            }
            return result.ToString();
        }
        public static void WritterProd(string num1, string num2, string[] interResult, string result, int CursorTopEnd)
        {
            Console.SetCursorPosition(2 + result.Length - num1.Length - 1, 5);
            int CursorTop = Console.CursorTop;
            Console.Write($"*{num1}");
            Console.SetCursorPosition(2 + result.Length - num2.Length, CursorTop + 1);
            Console.Write(num2);
            Console.SetCursorPosition(result.Length - num1.Length, CursorTop + 2);
            ColumnWidth(num1.Length);
            CursorTop = Console.CursorTop;
            for (int i = 0; i < interResult.Length; i++)
            {
                Console.SetCursorPosition(2 + result.Length - interResult[i].Length - i, CursorTop);
                CursorTop += 1;
                Console.Write(interResult[i]);
                if (i == interResult.Length / 2)
                {
                    Console.SetCursorPosition(1, interResult.Length / 2 + 8);
                    Console.Write("+");
                }
            }
            Console.SetCursorPosition(0, CursorTop);
            ColumnWidth(result.Length);
            Console.SetCursorPosition(2, CursorTop + 1);
            Console.Write(result);
            Console.SetCursorPosition(0, CursorTopEnd);
        }
    }
}
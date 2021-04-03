using System;
using System.Text;

namespace TI
{
	class Program
	{
		static void Main(string[] args)
		{
			var chipher = new Chipher[] { new RailwayHedge(), new ColumnChipher("crypto"), new RailwayHedge(), new CaesarChipher() };
			while (true)
			{
				Console.WriteLine("Метод шифрования:\n1. Железнодорожная изгородь\n2. Столбцовый метод\n3. Метод поворачивающейся решётки\n4. Шифр Цезаря\n5. Выйти");
				int input;
				do
				{
					try
					{
						input = int.Parse(Console.ReadLine());
					}
					catch (InvalidCastException)
					{
						input = -1;
					}
				}
				while (!(input > 0 && input < 6));

				if (input == 6)
				{
					break;
				}

				int chipherIndex = input - 1;
				Console.Clear();
				Console.WriteLine("Введите ваше сообщение: ");
				var message = Console.ReadLine();
				Console.Clear();
				Console.WriteLine("1. Зашифровать\n2. Расшифровать");
				do
				{
					try
					{
						input = int.Parse(Console.ReadLine());
					}
					catch (InvalidCastException)
					{
						input = -1;
					}
				}
				while (!(input > 0 && input < 3));

				string answer = "";
				switch (input)
                {
					case 1:
						answer = chipher[chipherIndex].Encrypt(message);
						break;
					case 2:
						answer = chipher[chipherIndex].Decrypt(message);
						break;
				}

				Console.Clear();
				Console.WriteLine("Полученное сообщение:\n" + answer);
				Console.ReadKey();
				Console.Clear();
			}
		}
	}
}
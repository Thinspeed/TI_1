using System;
using System.Collections.Generic;
using System.Text;

namespace TI
{
	class Point
    {
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int x, int y)
        {
			X = x;
			Y = y;
        }
    }

	class RotattingLattice : Chipher
	{
		List<Point> key;
		int size;

		private void Rotate()
        {
			for (int i = 0; i < key.Count; i++)
            {
				int newX = size - key[i].Y - 1;
				key[i].Y = key[i].X;
				key[i].X = newX;
			}
        }

		private void Print()
        {
			for (int i = 0; i < size; i++)
            {
				for (int j = 0; j < size; j++)
                {
					bool found = false;
					for (int k = 0; k < size; k++)
                    {
						if (key[k].X == j && key[k].Y == i)
						{
							found = true;
							break;
						}
					}

					Console.Write(" {0} ", found ? 1 : 0);
                }
				Console.WriteLine();
            }
        }
		public RotattingLattice() : this(4)
		{ }

		public RotattingLattice(int size)
		{
			if (size % 2 != 0)
			{
				size++;
			}

			this.size = size;
			key = new List<Point>();
			key.Add(new Point(0, 0));
			key.Add(new Point(0, 2));
			key.Add(new Point(1, 2));
			key.Add(new Point(3, 2));
		}

		override public string Encrypt(string message)
		{
			var codedMessage = new StringBuilder(message);
			if (message.Length > 16)
            {
				message = message.Substring(0, 16);
            }

			int currentCell = 0;
			for (int i = 0; i < message.Length; i++)
            {
				codedMessage[key[currentCell].Y * size + key[currentCell].X] = message[i];
				currentCell++;
				if (currentCell == size)
                {
					Rotate();
					currentCell = 0;
				}
            }

			return codedMessage.ToString();
		}

		override public string Decrypt(string message)
        {
			int currentCell = 0;
			var decodedMessage = new StringBuilder();
			for (int i = 0; i < message.Length; i++)
            {
				decodedMessage.Append(message[key[currentCell].Y * size + key[currentCell].X]);
				currentCell++;
				if (currentCell == size)
				{
					Rotate();
					currentCell = 0;
				}
			}

			return decodedMessage.ToString();
        }
	}
}

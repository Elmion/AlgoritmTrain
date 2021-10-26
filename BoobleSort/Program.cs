using System;

namespace BoobleSort
{
	class Program
	{
		static Random rnd = new Random();
		static void Main(string[] args)
		{
			int[] sortingMassive = InitNewArray();
			var a1 = sortingMassive.Clone() as int[];
			var a2 = sortingMassive.Clone() as int[];
			var a3 = sortingMassive.Clone() as int[];
			Console.WriteLine(a1.GetHashCode() + "  " + a2.GetHashCode());
			var  t = new System.Diagnostics.Stopwatch();
			t.Start();
			BoobleSort(a1);
			t.Stop();
			Console.WriteLine($"Booble: {t.ElapsedTicks}");
			t.Restart();
			sortingMassive = InitNewArray();
			ShakerSort(a2);
			t.Stop();
			Console.WriteLine($"Shaker: {t.ElapsedTicks}");
			t.Restart();
			a3 = QuickSortRecurse(a3);
			t.Stop();
			Console.WriteLine($"Quick: {t.ElapsedTicks}");








		}

		static void BoobleSort(int[] sortingMassive)
		{
			bool unsorted;
			do
			{
				unsorted = false;
				for (int i = 0; i < sortingMassive.Length - 1; i++)
				{
					if (sortingMassive[i] > sortingMassive[i + 1])
					{
						Swap(sortingMassive, i, i + 1); unsorted = true;
					}
				}

			} while (unsorted);
		}
		private static int[] QuickSortRecurse(int[] sortingMassive)
		{
			if (sortingMassive.Length <= 1) return sortingMassive;
			int posPivot = rnd.Next(sortingMassive.Length );
			int pivot = sortingMassive[posPivot];
			int[] lower = new int[0];
			int[] hi = new int[0];
			for (int i = 0; i < sortingMassive.Length; i++)
			{
				if (posPivot == i) continue;
				if (pivot > sortingMassive[i])
				{

					Array.Resize(ref lower, lower.Length + 1);
					lower[lower.Length - 1] = sortingMassive[i];
				}
				else
				{
		
					Array.Resize(ref hi, hi.Length + 1);
					hi[hi.Length - 1] = sortingMassive[i];
				}
			}
			lower = QuickSortRecurse(lower);
			hi = QuickSortRecurse(hi);
			int[] combined = new int[lower.Length + 1 + hi.Length];
			Array.Copy(lower, combined, lower.Length);
			combined[lower.Length] = pivot;
			Array.Copy(hi, 0, combined, lower.Length+1, hi.Length);
			return combined;
		}
		static void ShakerSort(int[] myint)
		{
			int left = 0,
				right = myint.Length - 1,
				count = 0;

			while (left < right)
			{
				for (int i = left; i < right; i++)
				{
					count++;
					if (myint[i] > myint[i + 1])
						Swap(myint, i, i + 1);
				}
				right--;

				for (int i = right; i > left; i--)
				{
					count++;
					if (myint[i - 1] > myint[i])
						Swap(myint, i - 1, i);
				}
				left++;
			}
		}
		public static int[] InitNewArray()
		{
			int[] sortingMassive = new int[10000];
			for (int i = 0; i < 10000; i++)
				sortingMassive[i] = i;
			sortingMassive = Randomize(sortingMassive, 1000000);
			return sortingMassive;
		}

		public static int[] Randomize(int[] shaftArray, int countShaft)
		{
			for (int i = 0; i < countShaft; i++)
			{
				int outPlace = rnd.Next(100);
				int inPlace = rnd.Next(100); 
				while (inPlace == outPlace)
					inPlace = rnd.Next(100);
				shaftArray = Swap(shaftArray, outPlace, inPlace);
			}
			return shaftArray;
		}
		public static int[] Swap(int[] array, int pos1, int pos2)
		{
			int buff = array[pos2];
			array[pos2] = array[pos1];
			array[pos1] = buff;
			return array;
		}
	}
}

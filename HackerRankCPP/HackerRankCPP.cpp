// HackerRankCPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <vector>
#include <map>
#include <numeric>

struct Player {
	std::string name;
	int score;
};

int PartitionByScoreDesc(std::vector<Player>& array, int low, int high)
{
	int border = low + 1;
	for (int i = border; i <= high; i++)
	{
		if (array[i].score > array[low].score) {
			std::swap(array[i], array[border]);
			border++;
		}
	}

	std::swap(array[low], array[border - 1]);

	return border - 1;
}

int PartitionByNameAscend(std::vector<Player>& array, int low, int high)
{
	int border = low + 1;
	for (int i = border; i <= high; i++)
	{
		if (array[i].name < array[low].name) {
			std::swap(array[i], array[border]);
			border++;
		}
	}

	std::swap(array[low], array[border - 1]);

	return border - 1;
}

void QuickSort(std::vector<Player>& array, int low, int high, int (*partitionFunc)(std::vector<Player>&, int, int ))
{
	if (low >= high)
		return;

	int p = partitionFunc(array, low, high);
	QuickSort(array, low, p - 1, partitionFunc);
	QuickSort(array, p + 1, high, partitionFunc);
}

void QSort()
{
	
	Player p1;
	p1.score = 99;
	p1.name = "bill";

	Player p2;
	p2.score = 999;
	p2.name = "bobby";

	std::vector<Player> array{ p1, p2 };

	QuickSort(array, 0, array.size() - 1, PartitionByScoreDesc);

	int startIndex = 0;
	int currentScore = -1;
	for(int i = 0; i < array.size(); i++)
	{
		if(array[i].score != currentScore)
		{
			if (startIndex != i)
				QuickSort(array, startIndex, i - 1, PartitionByNameAscend);

			startIndex = i;
			currentScore = array[i].score;
		}
	}
}

int OddManOut(std::vector<int> &array)
{
	auto odd = std::accumulate(array.begin(), array.end(), 0, [&](int a, int b) {return a ^ b; });
	int accumulator = 0;
	for(int i = 0; i < array.size(); i++)
	{
		accumulator ^= array[i];
	}

	return accumulator;
}

int main()
{
	QSort();
	std::vector<int> array{ 3, 1, 34, 1, 2, 2, 3 };

	int unpairedInt = OddManOut(array);
	return 0;
}


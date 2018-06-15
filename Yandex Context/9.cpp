
#include <iostream>
#include <string>
#include <ctype.h>
#include <algorithm>
using namespace std;

int main()
{
	int Q;
	string S;
	bool changing = false;

	cin >> S;
	cin >> Q;

	int  *interval = new int[2];
	bool *changeInterval = new bool[S.length() + 1]{ false };

	for (int i = 0; i < Q; i++)
	{
		cin >> interval[0];
		cin >> interval[1];
		if (interval[0] != interval[1])
		{
			if (interval[0] > interval[1]) {
				int temp = interval[0];
				interval[0] = interval[1];
				interval[1] = temp;
			}

			interval[0]--;
			changeInterval[interval[0]] = !changeInterval[interval[0]];
			changeInterval[interval[1]] = !changeInterval[interval[1]];
		}
		else
		{
			interval[1]--;
			//char c = S[interval[0]];
			if (isupper(S[interval[1]]))
				S[interval[1]] = tolower(S[interval[1]]);
			else if (islower(S[interval[1]]))
				S[interval[1]] = toupper(S[interval[1]]);
		}
	}
	for (int i = 0; i < S.length(); i++)
	{
		if (changeInterval[i])
			changing = !changing;
		if (changing)
		{
			if (isupper(S[i]))
				S[i] = tolower(S[i]);
			else
				S[i] = toupper(S[i]);
		}
	}
	cout << S;
	system("pause");
}

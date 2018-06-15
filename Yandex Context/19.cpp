
#include "iostream"
#include "string"
using namespace std;

int n;
int* A;

void CopyArray(int* temp, int leftBorder, int rightBorder) {
	int i = leftBorder;
	while (i < rightBorder + 1)
	{
		A[i] = temp[i];
		i++;
	}
	delete[] temp;
}

unsigned long int MergeMethod(int leftBorder, int rightBorder, unsigned long int result)
{
	int* temp = new int[n];
	// center / first / last
	int pos[] = { (leftBorder + rightBorder) / 2, leftBorder, (leftBorder + rightBorder) / 2 + 1 };

	int i = leftBorder;
	while (i < rightBorder + 1)
	{
		if (pos[1] <= pos[0])
		{
			if (pos[2] > rightBorder || A[pos[1]] < A[pos[2]]) {
				temp[i] = A[pos[1]];
				pos[1]++;
			}
			else {
				temp[i] = A[pos[2]];
				pos[2]++;
				result = result + pos[0] - pos[1] + 1;
			}
		}
		else
		{
			temp[i] = A[pos[2]];
			pos[2]++;
			result = result +  pos[0] - pos[1] + 1;
		}
		i++;
	}
	CopyArray(temp, leftBorder, rightBorder);
	return result;
}

unsigned long int Task(int leftBorder, int rightBorder, unsigned long int result)
{
	if (leftBorder < rightBorder)
	{
		result = Task(leftBorder, (leftBorder + rightBorder) / 2, result);
		result = Task((leftBorder + rightBorder) / 2 + 1, rightBorder, result);
		result = MergeMethod(leftBorder, rightBorder, result);
	}
	return result;
}


int main()
{
	cin >> n;
	A = new int[n];
	for (int i = 0; i < n; i++) {
		cin >> A[i];
	}
	unsigned long int answer = Task(0,n-1,0);
	cout << answer;
}

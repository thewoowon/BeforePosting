#include <iostream>
#include <conio.h>
#include <windows.h>
using namespace std;
bool gameOver;
const int width = 50;
const int height = 20;
int x, y, fruitX, fruitY, score;
int tailX[100], tailY[100];
int nTail;
enum class eDirecton { STOP = 0, LEFT, RIGHT, UP, DOWN };
eDirecton dir;
void Setup()
{
    gameOver = false; // �ϴ� ���ӿ����� �ƴ�
    dir = eDirecton::STOP; // ���� ����
    x = width / 2; // ���� �޴´�. 10
    y = height / 2; // ���� �޴´�. 10
    fruitX = rand() % width; // ���� 'F'�� x��ġ�� �����Լ��� �޴´�. -> �������� �޴´�.
    fruitY = rand() % height; // ���� 'F'�� y��ġ�� �����Լ��� �޴´�. -> �������� �޴´�.
    score = 0; //���� ���� 0�̰�
}
void Draw()
{
    system("cls"); //system("clear");
    for (int i = 0; i < width + 2; i++) // ���η� '#'�� ��� -> 22���� ���
        cout << "#";
    cout << endl; // �ٹٲ� �ϱ�

    for (int i = 0; i < height; i++) // ���δ� �ϴ� ������� ���� 
    {
        for (int j = 0; j < width; j++) // ���� for�� -> ������ ���̸� ������. ������ ���� ������ ������ ������ �ϴ� ������ ��?
        {
            if (j == 0) // ó�� ������ ��-> �ϴ� ���� �ٲپ��� -> ����� ����
                cout << "#";
            if (i == y && j == x) //10�� 10�� �� 
                cout << "O"; // �����ϴ� �������� �Ӹ� ��ġ
            else if (i == fruitY && j == fruitX) // ���� ���ĺ� ����
                cout << "F"; 
            else // �׿ܴ� �簢�� �׸���
            {
                bool print = false; 
                for (int k = 0; k < nTail; k++) //������ ������ ���� ���� ����  -> ó���� null
                {
                    if (tailX[k] == j && tailY[k] == i) // 
                    {
                        cout << "o";
                        print = true;
                    }
                }
                if (!print)
                    cout << " ";
            }


            if (j == width - 1)
                cout << "#";
        }
        cout << endl;
    }

    for (int i = 0; i < width + 2; i++)
        cout << "#";
    cout << endl;
    cout << "Score:" << score << endl;
}
void Input()
{
    if (_kbhit())
    {
        switch (_getch())
        {
        case 'a':
            dir = eDirecton::LEFT;
            break;
        case 'd':
            dir = eDirecton::RIGHT;
            break;
        case 'w':
            dir = eDirecton::UP;
            break;
        case 's':
            dir = eDirecton::DOWN;
            break;
        case 'x':
            gameOver = true;
            break;
        }
    }
}
void Logic()
{
    int prevX = tailX[0]; // ���� ���� ��ġ
    int prevY = tailY[0]; // ���� ���� ��ġ
    int prev2X, prev2Y;
    tailX[0] = x; // ������ x���� ���� ������ // �ֳ��ϸ� 0�� �Ӹ��̱� ������ ������ ��ǥ�� ��ġ
    tailY[0] = y; // ������ y���� ���� ������ // ���� �Ӹ��� ��ǥ
    for (int i = 1; i < nTail; i++) //ó������ ���� ����. 0���� �ڵ� �ʱ�ȭ -> 0�� �Ӹ��� 1���� ����
    {
        prev2X = tailX[i]; // 
        prev2Y = tailY[i];
        tailX[i] = prevX;
        tailY[i] = prevY;
        prevX = prev2X;
        prevY = prev2Y;
    }
    switch (dir)
    {
    case eDirecton::LEFT:
        x--;
        break;
    case eDirecton::RIGHT:
        x++;
        break;
    case eDirecton::UP:
        y--;
        break;
    case eDirecton::DOWN:
        y++;
        break;
    default:
        break;
    }
    //if (x > width || x < 0 || y > height || y < 0)
    //  gameOver = true;
    if (x >= width) x = 0; else if (x < 0) x = width - 1;
    if (y >= height) y = 0; else if (y < 0) y = height - 1;

    for (int i = 0; i < nTail; i++)
        if (tailX[i] == x && tailY[i] == y)
            gameOver = true;

    if (x == fruitX && y == fruitY)
    {
        score += 10;
        fruitX = rand() % width;
        fruitY = rand() % height;
        nTail++;
    }
}
void Draw1()
{
    system("cls"); //system("clear");
    for (int i = 0; i < width + 2; i++) // ���η� '#'�� ��� -> 22���� ���
        cout << "#";
    cout << endl; // �ٹٲ� �ϱ�

    for (int i = 0; i < height; i++) // ���δ� �ϴ� ������� ���� 
    {
        for (int j = 0; j < width; j++) // ���� for�� -> ������ ���̸� ������. ������ ���� ������ ������ ������ �ϴ� ������ ��?
        {
            if (j == 0) // ó�� ������ ��-> �ϴ� ���� �ٲپ��� -> ����� ����
                cout << "#";
            if (i == y && j == x) //10�� 10�� �� 
                cout << "O"; // �����ϴ� �������� �Ӹ� ��ġ
            else if (i == fruitY && j == fruitX) // ���� ���ĺ� ����
                cout << "F";
            else // �׿ܴ� �簢�� �׸���
            {
                bool print = false;
                for (int k = 0; k < nTail; k++) //������ ������ ���� ���� ����  -> ó���� null
                {
                    if (tailX[k] == j && tailY[k] == i) // 
                    {
                        cout << "o";
                        print = true;
                    }
                }
                if (!print)
                    cout << " ";
            }


            if (j == width - 1)
                cout << "#";
        }
        cout << endl;
    }

    for (int i = 0; i < width + 2; i++)
        cout << "#";
    cout << endl;
    cout << "Score:" << score << endl;
}

int main()
{
    Setup();
    while (!gameOver)
    {
        //Draw();
        Draw1();
        //Input();
        //Logic();
        //Sleep(10); //sleep(10);
    }
    return 0;
}
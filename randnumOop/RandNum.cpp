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
    gameOver = false; // 일단 게임오버는 아님
    dir = eDirecton::STOP; // 정지 상태
    x = width / 2; // 몫을 받는다. 10
    y = height / 2; // 몫을 받는다. 10
    fruitX = rand() % width; // 과일 'F'의 x위치는 랜덤함수로 받는다. -> 나머지를 받는다.
    fruitY = rand() % height; // 과일 'F'의 y위치는 랜덤함수로 받는다. -> 나머지를 받는다.
    score = 0; //현재 점수 0이고
}
void Draw()
{
    system("cls"); //system("clear");
    for (int i = 0; i < width + 2; i++) // 가로로 '#'을 출력 -> 22개를 출력
        cout << "#";
    cout << endl; // 줄바꿈 하기

    for (int i = 0; i < height; i++) // 세로는 일단 갯수대로 진행 
    {
        for (int j = 0; j < width; j++) // 이중 for문 -> 가로의 길이를 돌린다. 가로의 길이 정보를 가지고 돌려야 하는 정보는 왜?
        {
            if (j == 0) // 처음 시작할 때-> 일단 줄을 바꾸었음 -> 기억자 형태
                cout << "#";
            if (i == y && j == x) //10과 10일 때 
                cout << "O"; // 시작하는 지렁이의 머리 위치
            else if (i == fruitY && j == fruitX) // 과일 알파벳 생성
                cout << "F"; 
            else // 그외는 사각형 그리기
            {
                bool print = false; 
                for (int k = 0; k < nTail; k++) //꼬리의 개수를 담은 변수 생성  -> 처음은 null
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
    int prevX = tailX[0]; // 고리의 이전 위치
    int prevY = tailY[0]; // 고리의 이전 위치
    int prev2X, prev2Y;
    tailX[0] = x; // 현재의 x값을 저장 시켜줌 // 왜냐하면 0은 머리이기 때문에 현재의 좌표와 일치
    tailY[0] = y; // 현재의 y값을 저장 시켜줌 // 현재 머리의 좌표
    for (int i = 1; i < nTail; i++) //처음에는 값이 없다. 0으로 자동 초기화 -> 0은 머리라서 1부터 시작
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
    for (int i = 0; i < width + 2; i++) // 가로로 '#'을 출력 -> 22개를 출력
        cout << "#";
    cout << endl; // 줄바꿈 하기

    for (int i = 0; i < height; i++) // 세로는 일단 갯수대로 진행 
    {
        for (int j = 0; j < width; j++) // 이중 for문 -> 가로의 길이를 돌린다. 가로의 길이 정보를 가지고 돌려야 하는 정보는 왜?
        {
            if (j == 0) // 처음 시작할 때-> 일단 줄을 바꾸었음 -> 기억자 형태
                cout << "#";
            if (i == y && j == x) //10과 10일 때 
                cout << "O"; // 시작하는 지렁이의 머리 위치
            else if (i == fruitY && j == fruitX) // 과일 알파벳 생성
                cout << "F";
            else // 그외는 사각형 그리기
            {
                bool print = false;
                for (int k = 0; k < nTail; k++) //꼬리의 개수를 담은 변수 생성  -> 처음은 null
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
#include<bits/stdc++.h>
using namespace std;
typedef long long ll;





int main()
{
    cout << "WELCOME NUMBER GUESSING GAME" << "\n";
    cout << "Pick a number between 1 and 100 and see if your lucky!" << "\n";
    int num;
   
    int secret = rand()%100;
    int points = 70;
    cout << secret << "\n";

    while(1)
    {
        if(points<=0)cout << "You loose!" << "\n";
        cin >> num;
        if(num == secret){
            cout << "Congratulations, you guessed correct number , you won " << points << "  points" << "\n";
            break;  
        }
            if(num < secret){
                cout << "Number is greater than secret" <<"\n";
            }else{
                cout << "Number is smaller than secret" <<"\n";
            }

            points = points - 2;

    }



   return 0;
}

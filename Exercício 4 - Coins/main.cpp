/*
Problem #4

In Brazil, there are coins with face value 1, 5, 10, 20, 25 and 50 cents. Assuming there are available
coins to you in infinite quantities, the proposed problem is to calculate the number of ways to compose
a given amount (combination of coins).

Function Description
Implement the function getNumberOfCombinations to calculate the number of ways to compose a given amount
with the available coins.

Input Format
Parameter: Amount in number of cents (integer)

Output Format
Number of combinations (integer)
*/

#include<iostream>
#include<vector>


int getNumberOfCombinations( int n )
{
    //declaration of the vector of coins to be used, as given from the exercise and the other variables
    //(length and a vector of possibilities)
    std::vector<int> availableCoins = {1,5, 10, 20, 25, 50};

    int length = availableCoins.size();

    std::vector<int> possibilities(n+1,0);

    // if the value informed by the user is 0, 1 will be adressed.
    possibilities[0] = 1;

    // keep updating the values and return the number of combinations (will be printed in the main function)
    for(int i=0; i<length; i++)
        for(int j=availableCoins[i]; j<=n; j++)
            possibilities[j] += possibilities[j-availableCoins[i]];

    return possibilities[n];
}


int main()
{
    //main function that receives and input from the user, calls the function of combinations and print it.
    int entry_user = 0;
    std::cout << "Please, enter the number you want to check the combinations: ";
    std::cin >> entry_user;
    std::cout << getNumberOfCombinations(entry_user) << std::endl;
    return 0;
}

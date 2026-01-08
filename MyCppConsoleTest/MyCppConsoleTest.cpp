// MyCppConsoleTest.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <stack>
#include <mutex>

std::stack<int> s;
std::mutex s_mutex;
void push_value(int v)
{
    std::lock_guard<std::mutex> lock(s_mutex);
    s.push(v);
}
int pop_value()
{
    std::lock_guard<std::mutex> lock(s_mutex);
    int out = s.top();
    s.pop();
    return out;
}


int main()
{
	push_value(1);
	push_value(4);
    std::cout << "size: " << s.size() << std::endl;
	std::cout << pop_value() << std::endl;
    std::cout << "size: " << s.size() <<  std::endl;

    std::cout << pop_value() << std::endl;
    std::cout << "size: " << s.size() << std::endl;
}



// Lab5.cpp : Defines the entry point for the console application.
//
#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include "stdafx.h"
#include <iostream>
#include <WinSock2.h>
#include <IPHlpApi.h>
#include <IcmpAPI.h>
#include <cstdlib>
#include <Windows.h>


#pragma comment(lib,"iphlpapi.lib")
#pragma comment(lib, "ws2_32.lib")

using namespace std;
void IPCheck();

int main()
{
	int k;
	
	do
	{
		cout << endl << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
		cout << "Menu" << endl;
		cout << "1 - IPCheck" << endl;
		cout << "0 - Exit" << endl;
		cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl << endl;
		cout << "Enter number " << endl;
		cin >> k;
		if (k == 1)
		{
			IPCheck();
		}
		else if (k == 0)
		{
			break;
		}
		else
		{
			cout << "Enter a valid number" << endl;
			cin >> k;
		}

	} while (k != 0);
}



void IPCheck()
{
	char ADDRESS[20];
	HANDLE hICMPFile;
	hICMPFile = IcmpCreateFile();
	if (hICMPFile == INVALID_HANDLE_VALUE)
	{
		cout << "Error " << WSAGetLastError() << endl;
	}

	cout << "Enter IP address: " << endl;
	cin >> ADDRESS;

	unsigned long ipAddress = inet_addr(ADDRESS);
	char dataSent[50] = "Data has been sent";
	LPVOID replyBuffer = NULL;
	DWORD replySize = 0;

	replySize = sizeof(ICMP_ECHO_REPLY) + sizeof(dataSent);

	replyBuffer = (VOID*)malloc(replySize);
	if (replyBuffer == NULL)
	{
		cout << "Cannot allocate memory" << endl;
	}

	

	DWORD dwRetVal = IcmpSendEcho(hICMPFile, ipAddress, dataSent, sizeof(dataSent), NULL, replyBuffer, replySize, 1000);

	if (dwRetVal != 0)
	{
		PICMP_ECHO_REPLY pEchoReply = (PICMP_ECHO_REPLY)replyBuffer;
		struct in_addr replyAddr;
		replyAddr.S_un.S_addr = pEchoReply->Address;
		cout << "Message sent to " << ADDRESS << endl;

		if (dwRetVal > 1)
		{
			cout << "Reply #" << dwRetVal << endl;
		}
		else
		{
			cout << "Reply #" << dwRetVal << endl;
			cout << "INFO:" << endl;
			cout << "Recieved from: " << inet_ntoa(replyAddr) << endl;
			cout << "Status: " << pEchoReply->Address << endl;
			cout << "Response time: " << pEchoReply->RoundTripTime << endl;
		}
	}
	else
	{
		cout << "Finished with error: " << WSAGetLastError() << endl;
	}

	BOOL bRetVal;

	bRetVal = IcmpCloseHandle(hICMPFile);
	if (bRetVal)
	{
		cout << "Handle closed" << endl;
	}
	else
	{
		cout << "Finished with error: " << WSAGetLastError() << endl;
	}
}

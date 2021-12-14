#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS



#include <iostream>
#include <winsock2.h>
#include <iphlpapi.h>
#include <icmpapi.h>
#pragma comment(lib, "iphlpapi.lib")//директивы для подключения библиотек, содержащих cтруктуры
#pragma comment(lib, "ws2_32.lib")// и функции, предоставляемые Windows Sockets API (WSA)ws2_32.lib и IP helper APIIphlpapi.lib

#define IP_STATUS_BASE 11000
#define IP_SUCCESS 0
#define IP_DEST_NET_UNREACHABLE 11002
#define IP_DEST_HOST_UNREACHABLE 11003
#define IP_DEST_PROT_UNREACHABLE 11004
#define IP_DEST_PORT_UNREACHABLE 11005
#define IP_REQ_TIMED_OUT 11010
#define IP_BAD_REQ 11011
#define IP_BAD_ROUTE 11012
#define IP_TTL_EXPIRED_TRANSIT 11013



void Ping(const char* cHost, unsigned int Timeout, unsigned int RequestCount)
{
	//Создать файл сервиса
	HANDLE hIP = IcmpCreateFile();//Возвращаем манипулятор
	if (hIP == INVALID_HANDLE_VALUE)
	{
		WSACleanup();
		return;
	}
	char SendData[32] = "Data for ping";//буфер для передачи
	int LostPacketsCount = 0; // кол-во потерянных пакетов
	unsigned int MaxMS = 0;// максимальное время ответа (мс)
	int MinMS = -1; // минимальное время ответа (мс)

	// Выделяем память под пакет – буфер ответа
	PICMP_ECHO_REPLY pIpe = (PICMP_ECHO_REPLY)GlobalAlloc(GHND, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData));
	if (pIpe == 0)
	{
		IcmpCloseHandle(hIP);
		WSACleanup();
		return;
	}
	pIpe->Data = SendData;
	pIpe->DataSize = sizeof(SendData);
	unsigned long ipaddr = inet_addr(cHost);
	IP_OPTION_INFORMATION option =
	{
	255,// Поле «Время жизни» в заголовке пакета IPv4.
	0, // Поле типа службы в заголовке IPv4. Этот член в настоящее время игнорируется.
	0, // Поле "Флаги". В IPv4 это поле Flags в заголовке IPv4. В IPv6 это поле представлено заголовками параметров.
	// IP_FLAG_REVERSE - Это значение заставляет IP - пакет добавлять заголовок IP - маршрутизации с источником. Это значение применимо только в Windows Vista и более поздних версиях.
	// IP_FLAG_DF - Это значение указывает, что пакет не следует фрагментировать.
	0, // Размер опций в байтах
	0 // Указатель на данные опций.
	};

	for (unsigned int c = 0; c < RequestCount; c++)
	{
		// количество полученных эхо - ответов
		int dwStatus = IcmpSendEcho //отправляет ICMP эхо-запрос по указанному IP-адресу и возвращает любые ответы, полученные в пределах заданного времени
		(
			hIP,
			ipaddr,
			SendData,
			sizeof(SendData),
			(PIP_OPTION_INFORMATION)&option,
			pIpe,
			sizeof(ICMP_ECHO_REPLY) + sizeof(SendData),
			Timeout
		);
		if (dwStatus > 0)
		{
			for (int i = 0; i < dwStatus; i++)
			{
				unsigned char* pIpPtr = (unsigned char*)&pIpe->Address;
				std::cout
					« "Ответ от " «(int) * (pIpPtr)
					« "." «(int) * (pIpPtr + 1)
					« "." «(int) * (pIpPtr + 2)
					« "." «(int) * (pIpPtr + 3)
					« ": число байт = " « pIpe->DataSize
					« " время = " « pIpe->RoundTripTime
					« "мс TTL = " «(int)pIpe->Options.Ttl
					« std::endl;

				MaxMS = (MaxMS > pIpe->RoundTripTime) ?
					MaxMS : pIpe->RoundTripTime;
				MinMS = (MinMS < (int)pIpe->RoundTripTime&& MinMS >= 0) ?
					MinMS : pIpe->RoundTripTime;
			}
		}
		else
		{
			if (pIpe->Status)
			{
				LostPacketsCount++;
				switch (pIpe->Status) {
				case IP_DEST_NET_UNREACHABLE:
				case IP_DEST_HOST_UNREACHABLE:
				case IP_DEST_PROT_UNREACHABLE:
				case IP_DEST_PORT_UNREACHABLE:
					std::cout « "Remote host may be down." « std::endl;
					break;
				case IP_REQ_TIMED_OUT:
					std::cout « "Request timed out." « std::endl;
					break;
				case IP_TTL_EXPIRED_TRANSIT:
					std::cout « "TTL expired in transit." « std::endl;
					break;
				default:
					std::cout « "Error code: %ld"
						« pIpe->Status « std::endl;
					break;
				}
			}
		}
	}
	if (MinMS < 0) MinMS = 0;
	unsigned char* pByte = (unsigned char*)&pIpe->Address;
	std::cout
		« "Статистика Ping "
		«(int) * (pByte)
		« "." «(int) * (pByte + 1)
		« "." «(int) * (pByte + 2)
		« "." «(int) * (pByte +
			3) « std::endl;

	std::cout
		« "\tПакетов: отправлено = " « RequestCount
		« ", получено = " « RequestCount - LostPacketsCount
		« ", потеряно = " « LostPacketsCount
		« "<" «(int)(100 / (float)RequestCount) *
		LostPacketsCount
		« " % потерь>, " « std::endl;

	std::cout
		« "Приблизительное время приема-передачи:"
		« std::endl « "Минимальное = " « MinMS
		« "мс, Максимальное = " « MaxMS
		« "мс, Среднее = " «(MaxMS + MinMS) / 2
		« "мс" « std::endl;
	IcmpCloseHandle(hIP);
	WSACleanup();
}

int main(int argc, char** argv)
{
	setlocale(LC_ALL, "RUS");

	unsigned int Timeout = 60;
	unsigned int RequestCount = 10;

	if (argc > 1)
	{
		if (argc > 2)
		{
			Timeout = atoi(argv[2]);
		}
		if (argc > 3)
		{
			RequestCount = atoi(argv[3]);
		}
		Ping(argv[1], Timeout, RequestCount);
	}
	else
	{
		Ping("81.19.70.2", Timeout, RequestCount);
	}

	//Ping(host, Timeout, RequestCount);
	//system("pause");
	return 0;
}
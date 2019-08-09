#ifdef ZINTERP_DLL
		#ifdef ZINTERP_IMPLEMENTATION
			#define ZINTERP_API __declspec(dllexport)
		#else
			#define ZINTERP_API __declspec(dllimport)
		#endif
	#else
		#define ZINTERP_API extern
	#endif

ZINTERP_API void print();

ZINTERP_API char* ReturnDynamicStr();

ZINTERP_API int ReturnInt();

void print()
{
    printf("Yeah boi");
}

int ReturnInt()
{
	return 0xBABE;
}
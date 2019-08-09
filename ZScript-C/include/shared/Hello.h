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

void print()
{
    printf("Yeah boi");
}
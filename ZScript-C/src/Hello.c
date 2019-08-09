#include <stdio.h>

#include "shared/Hello.h"

char* ReturnDynamicStr()
{       
    char* str = CoTaskMemAlloc(512);
    strcpy_s(str, 512, "Dynamic string");
    return str;
}
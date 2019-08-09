#include <stdio.h>
#include <string.h>
#include <combaseapi.h>

#include "shared/Hello.h"

char* ReturnDynamicStr()
{       
    char* str = (char*)CoTaskMemAlloc(512);
    strcpy_s(str, 512, "Dynamic string");
    return str;
}
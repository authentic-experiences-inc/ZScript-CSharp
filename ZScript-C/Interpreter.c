#define PLUGINEX(rtype) UNITY_INTERFACE_EXPORT rtype UNITY_INTERFACE_API

extern "C" {
 
    PLUGINEX(bool) AcceptStr(LPCSTR pStr)
    {
        return !strcmp(pStr, "FOO");
    }
    PLUGINEX(LPSTR) ReturnDynamicStr()
    {       
        LPSTR str = (LPSTR)CoTaskMemAlloc(512);
        strcpy_s(str, 512, "Dynamic string");
        return str;
    }
 
    PLUGINEX(LPCSTR) ReturnConstStr()
    {       
        return "Constant string";
    }
}
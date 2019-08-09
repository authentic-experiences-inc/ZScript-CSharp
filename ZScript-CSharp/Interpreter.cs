using System;
using System.Runtime.InteropServices;

namespace AuthenticExperiences.ZScriptCSharp
{
    public class Interpreter
    {
        public void Interpret(string Input)
        {
            
        }
    }

    internal static class NativeImport
    {
        #if __IOS__ || UNITY_IOS && !UNITY_EDITOR
			private const string nativeLibrary = "__Internal";
		#else
			private const string nativeLibrary = "ZScript";
		#endif

		[DllImport(nativeLibrary, CallingConvention = CallingConvention.Cdecl)]
		internal static extern int enet_initialize();
    }
}

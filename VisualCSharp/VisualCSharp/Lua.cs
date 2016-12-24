using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;



namespace VisualCSharp
{
    static class win32
    {
        [DllImport("kernel32.dll")]
        public static extern bool SetDllDirectory(string lpPathName);

        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        public extern static IntPtr LoadLibrary(string librayName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi)]
        public extern static IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        public extern static bool FreeLibrary(int hModule);
    }

    static class Constants
    {
        public const int LUA_MULTRET = -1;

        public const int LUA_OK = 0;


        public const int LUA_TBOOLEAN = 1;

        public const int LUA_TRUE = 1;
        public const int LUA_FALSE = 0;
    }

    static class Lua
    {
        [UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl‌​)]
        [return: MarshalAs(UnmanagedType.I4)]
        public delegate int LuaFunction(IntPtr pLuaState);

        [DllImport("lua53", EntryPoint = "luaL_newstate", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr luaL_newstate();

        [DllImport("lua53", EntryPoint = "lua_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_close(IntPtr lua_State);


        [DllImport("lua53", EntryPoint = "luaL_loadfilex", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_loadfilex(IntPtr lua_State, string pszPath, string mode);

        [DllImport("lua53", EntryPoint = "lua_pcallk", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pcallk(IntPtr lua_State, int nArgs, int nResults, int errFunc, int ctx, LuaFunction func);

        [DllImport("lua53", EntryPoint = "lua_tolstring", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_tolstring(IntPtr pLuaState, int nStack, int nSize);

        [DllImport("lua53", EntryPoint = "lua_getglobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getglobal(IntPtr lua_State, string szName);

        [DllImport("lua53", EntryPoint = "lua_setglobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_setglobal(IntPtr lua_State, string szName);

        [DllImport("lua53", EntryPoint = "lua_isstring", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isstring(IntPtr lua_State, int nStack);

        [DllImport("lua53", EntryPoint = "lua_pushstring", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pushstring(IntPtr lua_State, string szName);

        [DllImport("lua53", EntryPoint = "lua_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_type(IntPtr lua_State, int nStack);

        [DllImport("lua53", EntryPoint = "lua_toboolean", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_toboolean(IntPtr lua_State, int nStack);

        [DllImport("lua53", EntryPoint = "lua_pushboolean", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pushboolean(IntPtr lua_State, int nValue);

        [DllImport("lua53", EntryPoint = "lua_gettop", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gettop(IntPtr lua_State);

        [DllImport("lua53", EntryPoint = "luaL_openlibs", CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_openlibs(IntPtr lua_State);

        [DllImport("lua53", EntryPoint = "lua_isnumber", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isnumber(IntPtr lua_State, int nStack);

        [DllImport("lua53", EntryPoint = "lua_pushcclosure", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushcclosure(IntPtr lua_State, LuaFunction pFunction, int nValue);

        [DllImport("lua53", EntryPoint = "lua_tonumberx", CallingConvention = CallingConvention.Cdecl)]
        public static extern float lua_tonumberx(IntPtr lua_State, int nStack, IntPtr pisNumber);

        [DllImport("lua53", EntryPoint = "lua_pushnumber", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pushnumber(IntPtr lua_State, double nNumber);

        [DllImport("lua53", EntryPoint = "lua_pushinteger", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pushinteger(IntPtr lua_State, int nNumber);

        [DllImport("lua53", EntryPoint = "luaopen_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_string(IntPtr lua_State);



        public static int luaL_loadfile(IntPtr pLuaState, string pszPath)
        {
            int nSuccess = 0;
            nSuccess = luaL_loadfilex(pLuaState, pszPath, null);
            return nSuccess;
        }

        public static int luaL_dofile(IntPtr pLuaState, string pszPath)
        {
            int nSuccess = 0;

            nSuccess = luaL_loadfile(pLuaState, pszPath);
            if (Constants.LUA_OK != nSuccess) return nSuccess;
            nSuccess = lua_pcall(pLuaState, 0, Constants.LUA_MULTRET, 0);
            return nSuccess;
        }

        public static int lua_pcall(IntPtr pLuaState, int nargs, int nresults, int errfunc)
        {
            return lua_pcallk(pLuaState, (nargs), (nresults), (errfunc), 0, null);
        }

        public static string lua_tostring(IntPtr pLuaState, int nStack)
        {
            int nSize = 0;
            IntPtr pString = lua_tolstring(pLuaState, nStack, 0);

            while (0 != Marshal.ReadByte(pString, nSize))
            {
                nSize++;
            }

            byte[] byteArray = new byte[nSize];

            System.Runtime.InteropServices.Marshal.Copy(pString, byteArray, 0, nSize);

            return UTF8Encoding.UTF8.GetString(byteArray);
        }

        public static int lua_isboolean(IntPtr pLuaState, int nStack)
        {
            if (lua_type(pLuaState, (nStack)) == Constants.LUA_TBOOLEAN) return 1;
            return 0;
        }

        public static void lua_pushcfunction(IntPtr pLuaState, LuaFunction pFunction)
        {
            lua_pushcclosure(pLuaState, (pFunction), 0);
        }

        public static void lua_register(IntPtr pLuaState, string szFname, LuaFunction pFunction)
        {
            lua_pushcclosure(pLuaState, (pFunction), 0);
            lua_setglobal(pLuaState, (szFname));
        }

        public static float lua_tonumber(IntPtr pLuaState, int nStack)
        {
            return lua_tonumberx(pLuaState, (nStack), IntPtr.Zero);
        }
    }

}

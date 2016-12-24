using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;


namespace LuaAPI
{
    class Lua
    {
        [DllImport("lua53", EntryPoint = "lua_gettop", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gettop(IntPtr lua_State);

        [DllImport("lua53", EntryPoint = "lua_isstring", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isstring(IntPtr lua_State, int nStack);

        [DllImport("lua53", EntryPoint = "lua_tolstring", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_tolstring(IntPtr pLuaState, int nStack, int nSize);
        public static string lua_tostring(IntPtr pLuaState, int nStack)
        {
            IntPtr pString = lua_tolstring(pLuaState, nStack, 0);

            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(pString);
        }

        [DllImport("lua53", EntryPoint = "lua_isnumber", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isnumber(IntPtr lua_State, int nStack);

        public static float lua_tonumber(IntPtr pLuaState, int nStack)
        {
            return lua_tonumberx(pLuaState, (nStack), IntPtr.Zero);
        }

        [DllImport("lua53", EntryPoint = "lua_tonumberx", CallingConvention = CallingConvention.Cdecl)]
        public static extern float lua_tonumberx(IntPtr lua_State, int nStack, IntPtr pisNumber);

        [DllImport("lua53", EntryPoint = "lua_pushnumber", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pushnumber(IntPtr lua_State, double nNumber);
    }
}

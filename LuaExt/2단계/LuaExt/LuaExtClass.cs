using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;

using LuaAPI;


namespace LuaExt
{
    public class LuaExtClass
    {
        [DllExport("luaopen_LuaExt", CallingConvention = CallingConvention.Cdecl)]
        public static int luaopen_LuaExt(IntPtr pLuaState)
        {
            Lua.lua_register(pLuaState, "DbgString", DbgString);
            Lua.lua_register(pLuaState, "SumAndAverage", SumAndAverage);

            return 0;
        }

        //[DllExport("DbgString", CallingConvention = CallingConvention.Cdecl)]
        public static int DbgString(IntPtr pLuaState)
        {
            int nTop;

            string szDbgString;

            nTop = Lua.lua_gettop(pLuaState);
            if (1 != nTop) return 0;

            if (1 != Lua.lua_isstring(pLuaState, nTop)) return 0;

            szDbgString = Lua.lua_tostring(pLuaState, nTop);

            System.Diagnostics.Trace.WriteLine(szDbgString);

            return 0;
        }

        //[DllExport("SumAndAverage", CallingConvention = CallingConvention.Cdecl)]
        public static int SumAndAverage(IntPtr pLuaState)
        {
            int nTop;
            int nStartVar = 0;
            int nStopVar = 0;
            int nSum = 0;
            int nAverage = 0;

            nTop = Lua.lua_gettop(pLuaState);
            if (2 != nTop) return 0;

            if (1 != Lua.lua_isnumber(pLuaState, nTop)) return 0;
            if (1 != Lua.lua_isnumber(pLuaState, nTop - 1)) return 0;

            nStopVar = Convert.ToInt32(Lua.lua_tonumber(pLuaState, nTop));
            nStartVar = Convert.ToInt32(Lua.lua_tonumber(pLuaState, (nTop - 1)));

            for (int nIndex = nStartVar; nIndex <= nStopVar; nIndex++)
            {
                nSum += nIndex;
            }

            nAverage = nSum / (nStopVar - nStartVar + 1);

            Lua.lua_pushnumber(pLuaState, nSum);
            Lua.lua_pushnumber(pLuaState, nAverage);

            return 2;
        }
    }
}

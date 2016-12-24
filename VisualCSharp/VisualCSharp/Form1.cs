using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;


namespace VisualCSharp
{
    public partial class Form1 : Form
    {
     public Form1()
        {
            InitializeComponent();

            win32.SetDllDirectory("C:/Script/Lua");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr pLuaState = IntPtr.Zero;
            int nSuccess = 0;
            string szPath = "./Script/Sample01.lua";
            
            try {
                pLuaState = Lua.luaL_newstate();
                if (IntPtr.Zero == pLuaState) return;

                nSuccess = Lua.luaL_dofile(pLuaState, szPath);
                if (Constants.LUA_OK != nSuccess)
                {
                    string szError = Lua.lua_tostring(pLuaState, -1);
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + szError);
                }
            }
            finally
            {
                if(IntPtr.Zero != pLuaState)
                {
                    Lua.lua_close(pLuaState);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr pLuaState = IntPtr.Zero;
            int nSuccess = 0;
            string szPath = "./Script/Sample02.lua";

            try
            {
                pLuaState = Lua.luaL_newstate();
                if (IntPtr.Zero == pLuaState) return;

                nSuccess = Lua.luaL_dofile(pLuaState, szPath);
                if (Constants.LUA_OK != nSuccess)
                {
                    string szError = Lua.lua_tostring(pLuaState, -1);
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + szError);
                }

                // Lua의 전역 변수 읽어 오기
                Lua.lua_getglobal(pLuaState, "szWelcomMessage");
                Lua.lua_getglobal(pLuaState, "szWhoamI");

                if (1 != Lua.lua_isstring(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("`szWhoAmI' should be a string\n");
                    return;
                }
                string szWhoamI = Lua.lua_tostring(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("`szWelcomMessage' should be a string\n");
                    return;
                }
                string szWelcomMessage = Lua.lua_tostring(pLuaState, -2);

                System.Diagnostics.Trace.WriteLine("\n\n**** Lua 전역 변수 변경 전****");
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWhoamI의 값은 ? " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWelcomMessage의 값은 ? " + szWelcomMessage);

                // Lua의 전역 변수 변경하기
                Lua.lua_pushstring(pLuaState, "I am Sample02.lua");
                Lua.lua_setglobal(pLuaState, "szWhoamI");
                Lua.lua_pushstring(pLuaState, "Hello World^^");
                Lua.lua_setglobal(pLuaState, "szWelcomMessage");

                // Lua의 전역 변수 읽어 오기
                Lua.lua_getglobal(pLuaState, "szWelcomMessage");
                Lua.lua_getglobal(pLuaState, "szWhoamI");

                if (1 != Lua.lua_isstring(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("`szWhoAmI' should be a string\n");
                    return;
                }
                szWhoamI = Lua.lua_tostring(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("`szWelcomMessage' should be a string\n");
                    return;
                }
                szWelcomMessage = Lua.lua_tostring(pLuaState, -2);

                System.Diagnostics.Trace.WriteLine("\n\n**** Lua 전역 변수 변경 후****");
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWhoamI의 값은 ? " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWelcomMessage의 값은 ? " + szWelcomMessage);

            }
            finally
            {
                if (IntPtr.Zero != pLuaState)
                {
                    Lua.lua_close(pLuaState);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IntPtr pLuaState = IntPtr.Zero;
            int nSuccess = 0;
            string szPath = "./Script/Sample03.lua";

            try
            {
                pLuaState = Lua.luaL_newstate();
                if (IntPtr.Zero == pLuaState) return;

                nSuccess = Lua.luaL_dofile(pLuaState, szPath);
                if (Constants.LUA_OK != nSuccess)
                {
                    string szError = Lua.lua_tostring(pLuaState, -1);
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + szError);
                }

                ////////////////////////////////////////////////////////////////////////////////////////////
                //
                // 인자와 리턴값이 없는 함수 호출하기
                //
                Lua.lua_getglobal(pLuaState, "myfunc_1");

                //DumpLuaStack(pLuaState);

                if (Lua.lua_pcall(pLuaState, 0, 0, 0) != 0)
                {
                    string szError = Lua.lua_tostring(pLuaState, -1);
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + szError);
                    return;
                }


                Lua.lua_getglobal(pLuaState, "szWelcomMessage");
                Lua.lua_getglobal(pLuaState, "szWhoamI");


                if (1 != Lua.lua_isstring(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("`szWhoAmI' should be a string\n");
                    return;
                }
                string szWhoamI = Lua.lua_tostring(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("`szWelcomMessage' should be a string\n");
                    return;
                }
                string szWelcomMessage = Lua.lua_tostring(pLuaState, -2);

                System.Diagnostics.Trace.WriteLine("\n****Lua 함수 func_1 호출 후****\n");
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWhoamI의 값은 ? " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWelcomMessage의 값은 ? " + szWelcomMessage);



                ////////////////////////////////////////////////////////////////////////////////////////////
                //
                // 인자는 없지만 리턴값이 하나인 함수 호출하기
                //
                Lua.lua_getglobal(pLuaState, "myfunc_2");

                if (Lua.lua_pcall(pLuaState, 0, 1, 0) != 0)
                {
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + Lua.lua_tostring(pLuaState, -1));
                    return;
                }

                if (1 != Lua.lua_isstring(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("Return Value' should be a string\n");
                }
                string szReturn1 = Lua.lua_tostring(pLuaState, -1);

                Lua.lua_getglobal(pLuaState, "szWelcomMessage");
                Lua.lua_getglobal(pLuaState, "szWhoamI");


                if (1 != Lua.lua_isstring(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("`szWhoAmI' should be a string\n");
                    return;
                }
                szWhoamI = Lua.lua_tostring(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("`szWelcomMessage' should be a string\n");
                    return;
                }
                szWelcomMessage = Lua.lua_tostring(pLuaState, -2);


                System.Diagnostics.Trace.WriteLine("\n****Lua 함수 func_2 호출 후****\n");
                System.Diagnostics.Trace.WriteLine("Lua의 함수 func_3의 리턴값은 ?  " + szReturn1);
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWhoamI의 값은 ? " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWelcomMessage의 값은 ? " + szWelcomMessage);



                ////////////////////////////////////////////////////////////////////////////////////////////
                //
                // 인자는 없지만 리턴값이 여러개인 함수 호출하기
                //
                Lua.lua_getglobal(pLuaState, "myfunc_3");

                if (Lua.lua_pcall(pLuaState, 0, 2, 0) != 0)
                {
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + Lua.lua_tostring(pLuaState, -1));
                    return;
                }

                if (1 != Lua.lua_isboolean(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("Return Value' should be a boolean\n");
                }
                int bReturn2 = Lua.lua_toboolean(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("Return Value' should be a string\n");
                }
                szReturn1 = Lua.lua_tostring(pLuaState, -2);




                Lua.lua_getglobal(pLuaState, "szWelcomMessage");
                Lua.lua_getglobal(pLuaState, "szWhoamI");


                if (1 != Lua.lua_isstring(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("`szWhoAmI' should be a string\n");
                    return;
                }
                szWhoamI = Lua.lua_tostring(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("`szWelcomMessage' should be a string\n");
                    return;
                }
                szWelcomMessage = Lua.lua_tostring(pLuaState, -2);

                System.Diagnostics.Trace.WriteLine("\n****Lua 함수 func_3 호출 후****\n");
                System.Diagnostics.Trace.WriteLine("Lua의 함수 func_3의 리턴값은 ? " + szReturn1 + " , " + bReturn2.ToString());
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWhoamI의 값은 ? " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWelcomMessage의 값은 ? " + szWelcomMessage);





                ////////////////////////////////////////////////////////////////////////////////////////////
                //
                // 인자는 하나 리턴값이 여러개인 함수 호출하기
                //


                Lua.lua_getglobal(pLuaState, "myfunc_4");
                Lua.lua_pushstring(pLuaState, "myfunc_4");
                
                if (Lua.lua_pcall(pLuaState, 1, 2, 0) != 0)
                {
                    System.Diagnostics.Trace.WriteLine("error running function `f':" + Lua.lua_tostring(pLuaState, -1));
                    return;
                }

                if (1 != Lua.lua_isboolean(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("Return Value' should be a boolean\n");
                }
                bReturn2 = Lua.lua_toboolean(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("Return Value' should be a string\n");
                }
                szReturn1 = Lua.lua_tostring(pLuaState, -2);



                Lua.lua_getglobal(pLuaState, "szWelcomMessage");
                Lua.lua_getglobal(pLuaState, "szWhoamI");

                szWhoamI = Lua.lua_tostring(pLuaState, -1);
                if (1 != Lua.lua_isstring(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("`szWhoAmI' should be a string\n");
                    return;
                }
                szWhoamI = Lua.lua_tostring(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("`szWelcomMessage' should be a string\n");
                    return;
                }
                szWelcomMessage = Lua.lua_tostring(pLuaState, -2);

                System.Diagnostics.Trace.WriteLine("\n****Lua 함수 func_4 호출 후****\n");
                System.Diagnostics.Trace.WriteLine("Lua의 함수 func_4의 리턴값은 ? " + szReturn1 + " , " + bReturn2.ToString());
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWhoamI의 값은 ?  " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWelcomMessage의 값은 ? " + szWelcomMessage);




                ////////////////////////////////////////////////////////////////////////////////////////////
                //
                // 인자와 리턴값이 여러개인 함수 호출하기
                //

                Lua.lua_getglobal(pLuaState, "myfunc_5");
                Lua.lua_pushstring(pLuaState, "myfunc_5");
                Lua.lua_pushboolean(pLuaState, Constants.LUA_FALSE);

                //DumpLuaStack(pLuaState);
                if (Lua.lua_pcall(pLuaState, 2, 2, 0) != 0)
                {
                    System.Diagnostics.Trace.WriteLine("error running function `f': %s\n", Lua.lua_tostring(pLuaState, -1));
                    return;
                }

                if (1 != Lua.lua_isboolean(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("Return Value' should be a boolean\n");
                }
                bReturn2 = Lua.lua_toboolean(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("Return Value' should be a string\n");
                }
                szReturn1 = Lua.lua_tostring(pLuaState, -2);




                Lua.lua_getglobal(pLuaState, "szWelcomMessage");
                Lua.lua_getglobal(pLuaState, "szWhoamI");


                if (1 != Lua.lua_isstring(pLuaState, -1))
                {
                    System.Diagnostics.Trace.WriteLine("`szWhoAmI' should be a string\n");
                    return;
                }
                szWhoamI = Lua.lua_tostring(pLuaState, -1);

                if (1 != Lua.lua_isstring(pLuaState, -2))
                {
                    System.Diagnostics.Trace.WriteLine("`szWelcomMessage' should be a string\n");
                    return;
                }
                szWelcomMessage = Lua.lua_tostring(pLuaState, -2);

                System.Diagnostics.Trace.WriteLine("\n****Lua 함수 func_5 호출 후****\n");
                System.Diagnostics.Trace.WriteLine("Lua의 함수 func_5의 리턴값은 ?  " + szReturn1 + " , " + bReturn2.ToString());
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWhoamI의 값은 ?  " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("Lua의 전역 변수 szWelcomMessage의 값은 ? " + szWelcomMessage);
            }
            finally
            {
                if (IntPtr.Zero != pLuaState)
                {
                    Lua.lua_close(pLuaState);
                }
            }
            
        }


        public static int MyDbgString1(IntPtr pLuaState)
        {
            System.Diagnostics.Trace.WriteLine("MyDbgString 호출됨");

            return 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            IntPtr pLuaState = IntPtr.Zero;
            int nSuccess = 0;
            string szPath = "./Script/Sample04.lua";

            try
            {
                pLuaState = Lua.luaL_newstate();
                if (IntPtr.Zero == pLuaState) return;

                Lua.lua_register(pLuaState, "DbgString", MyDbgString1);

                nSuccess = Lua.luaL_dofile(pLuaState, szPath);
                if (Constants.LUA_OK != nSuccess)
                {
                    string szError = Lua.lua_tostring(pLuaState, -1);
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + szError);
                }
            }
            finally
            {
                if (IntPtr.Zero != pLuaState)
                {
                    Lua.lua_close(pLuaState);
                }
            }
        }




        public static int MyDbgString2(IntPtr pLuaState)
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

        public static int MySum(IntPtr pLuaState)
        {
            int nTop;
            int nStartVar = 0;
            int nStopVar = 0;
            int nSum = 0;


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

            Lua.lua_pushnumber(pLuaState, nSum);

            return 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IntPtr pLuaState = IntPtr.Zero;
            int nSuccess = 0;
            string szPath = "./Script/Sample05.lua";

            try
            {
                pLuaState = Lua.luaL_newstate();
                if (IntPtr.Zero == pLuaState) return;

                Lua.luaL_openlibs(pLuaState);
                //Lua.luaopen_string(pLuaState);

                Lua.lua_register(pLuaState, "DbgString", MyDbgString2);
                Lua.lua_register(pLuaState, "Sum", MySum);

                nSuccess = Lua.luaL_dofile(pLuaState, szPath);
                if (Constants.LUA_OK != nSuccess)
                {
                    string szError = Lua.lua_tostring(pLuaState, -1);
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + szError);
                }
            }
            finally
            {
                if (IntPtr.Zero != pLuaState)
                {
                    Lua.lua_close(pLuaState);
                }
            }
        }


        public static int MyDbgString3(IntPtr pLuaState)
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

        public static int MySumAndAverage(IntPtr pLuaState)
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

        private void button6_Click(object sender, EventArgs e)
        {
            IntPtr pLuaState = IntPtr.Zero;
            int nSuccess = 0;
            string szPath = "./Script/Sample06.lua";

            try
            {
                pLuaState = Lua.luaL_newstate();
                if (IntPtr.Zero == pLuaState) return;

                Lua.luaL_openlibs(pLuaState);

                Lua.lua_register(pLuaState, "DbgString", MyDbgString3);
                Lua.lua_register(pLuaState, "SumAndAverage", MySumAndAverage);

                nSuccess = Lua.luaL_dofile(pLuaState, szPath);
                if (Constants.LUA_OK != nSuccess)
                {
                    string szError = Lua.lua_tostring(pLuaState, -1);
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + szError);
                }
            }
            finally
            {
                if (IntPtr.Zero != pLuaState)
                {
                    Lua.lua_close(pLuaState);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IntPtr pLuaState = IntPtr.Zero;
            int nSuccess = 0;
            Lua.LuaFunction DbgString;
            Lua.LuaFunction SumAndAverage;
            string szPath = "./Script/Sample07.lua";

            try
            {
                IntPtr pFuncAddr = IntPtr.Zero;
                string szLuaExt = Directory.GetCurrentDirectory();


                szLuaExt += "\\Script\\LuaExt.dll";
                IntPtr hLuaExt = win32.LoadLibrary(szLuaExt);

                if (IntPtr.Zero == hLuaExt) return;

                pFuncAddr = win32.GetProcAddress(hLuaExt, "DbgString");
                if (IntPtr.Zero == pFuncAddr) return;
                DbgString = (Lua.LuaFunction)Marshal.GetDelegateForFunctionPointer(pFuncAddr, typeof(Lua.LuaFunction));


                pFuncAddr = win32.GetProcAddress(hLuaExt, "SumAndAverage");
                if (IntPtr.Zero == pFuncAddr) return;
                SumAndAverage = (Lua.LuaFunction)Marshal.GetDelegateForFunctionPointer(pFuncAddr, typeof(Lua.LuaFunction));


                pLuaState = Lua.luaL_newstate();
                if (IntPtr.Zero == pLuaState) return;

                Lua.luaL_openlibs(pLuaState);

                Lua.lua_register(pLuaState, "DbgString", DbgString);
                Lua.lua_register(pLuaState, "SumAndAverage", SumAndAverage);

                nSuccess = Lua.luaL_dofile(pLuaState, szPath);
                if (Constants.LUA_OK != nSuccess)
                {
                    string szError = Lua.lua_tostring(pLuaState, -1);
                    System.Diagnostics.Trace.WriteLine("error running function `f': " + szError);
                }
            }
            finally
            {
                if (IntPtr.Zero != pLuaState)
                {
                    Lua.lua_close(pLuaState);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

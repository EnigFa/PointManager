using System;
using System.Runtime.InteropServices;

class Program
{
    const string DllPath = "PointManagerDll.dll";

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr CreatePointManager();

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    static extern void DestroyPointManager(IntPtr pm);

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    static extern void PointManager_AddPoint(IntPtr pm, int x, int y);

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    static extern void PointManager_RemovePoint(IntPtr pm, int index);

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    static extern int PointManager_GetPoint(IntPtr pm, int index, out int x, out int y);

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    static extern int PointManager_Count(IntPtr pm);

    static void Main(string[] args)
    {

        IntPtr pm = CreatePointManager();
       
        PointManager_AddPoint(pm, 10, 20); // Додаємо точку
        PointManager_AddPoint(pm, 30, 40); // Додаємо точку
        PointManager_AddPoint(pm, 50, 60); // Додаємо точку

        Console.WriteLine("Кількість точок: " + PointManager_Count(pm));

        int count = PointManager_Count(pm);
        for (int i = 0; i < count; i++)
        {
            int x, y;
            int result = PointManager_GetPoint(pm, i, out x, out y);
            if (result == 1)
            {
                Console.WriteLine($"Точка {i}: ({x}, {y})");
            }
        }

        Console.WriteLine("\nВидаляємо точку з індексом 1...");
        PointManager_RemovePoint(pm, 1);

        Console.WriteLine("Кількість точок після видалення: " + PointManager_Count(pm));

        count = PointManager_Count(pm);
        for (int i = 0; i < count; i++)
        {
            int x, y;
            int result = PointManager_GetPoint(pm, i, out x, out y);
            if (result == 1)
            {
                Console.WriteLine($"Точка {i}: ({x}, {y})");
            }
        }

        DestroyPointManager(pm);

        Console.WriteLine("\nГотово!");
        Console.ReadLine();
    }
}
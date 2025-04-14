// See https://aka.ms/new-console-template for more information
using HotelManager.View;
using System.Runtime.CompilerServices;

namespace HotelManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Display display = new Display();
            await display.ShowMenu();
        }
    }
}

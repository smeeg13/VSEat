using System;
using DAL;

namespace VSEat_Project
{
    public class Program
    {
            static void Main(string[] args)
            {
            var menu = new Menu
                {
                    Id_Menu = 1,
                    Name_Menu = "test",
                    Price_Menu = 10,
                    Image_Menu = 0,
                    Ingredients_Menu = "ail, ...",
                    Status_Menu = "123"

                };

                Console.WriteLine(menu);

            }
    }
}

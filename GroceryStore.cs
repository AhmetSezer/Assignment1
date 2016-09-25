/*GoceryStore.cs
 *
 * Made by: Ahmet Sezer 2016-09-13
 * Changed: Ahmet Sezer 2016-09-18, lagt till fler kommentarer
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore
{
    /// <summary>
    /// 
    /// Konsol applikation som tar  emot information om en produkt och printar ut det.
    /// Den här klassen, innehåller Main, som använder sig av en annan klass, Product. 
    /// </summary>

    class GrocProg
    {
        static void Main(string[] args) //Main, startar programmet
        {
            Console.Title = "Apu's Supermarket"; //sätter titeln på fönstret/konsolen

            Product productObj = new Product(); //skapar ett nytt objekt av klassen Product
            
            productObj.WhatDoYouHave();         //anropar objektets publika metod som innehåller flera andra metoder
            
            Console.WriteLine("Press Enter to exit!");  
            
            Console.ReadLine();
        }
    }
}

/*Product.cs
 * 
 * Made by: Ahmet Sezer 2016-09-13
 * Changed by: Ahmet Sezer 2016-09-18, lagt till fler kommentarer etc.
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
    /// Klass som tar emot information om en produkt 
    /// och printar ut all inmatning.	
    /// Innehåller alla metoder och variabler
    /// 
    /// NOTE: I min dator funkar det enbart med kommatecken (,) när man matar en double.    
    /// </summary>
    public class Product //public-åtkomst
    {
        //Här kommer variabler

        private string productName;       //deklarerar varibeln som ska ta emot en vara av typen string
        private int amount;              //tar emot antalet/mängd av varan
        private double unitPrice;       //enhetspris eller styckpris
        private bool foodItem;          //Kollar om det mat
        private double totalNetValue;   //värdet av total summan sätts i denna variabel
        private double includingVat;    //momsen
        private double vat1;            //momsen i procent-form (%)

        private const double foodVATRate = 0.12, otherVATRate = 0.25;  //olika moms variabler som är konstant

        //Nu Ska vi göra: 1. Fråga användare produktnamn, pris, om det är mat, antal/mängd
        //                2. Beräkna olika momssatser beroende användarinmatning
        //                3. Visa/printa allt inmatat som ett kvitto  
        public void WhatDoYouHave() //En större metod som innehåller flera små, som anropas från Main
        {
            ReadInput();    //innehåller flera mindre metoder som läser av inmatningar

            CalculateValues();  //beräknar totalsumma med olika momssatser

            PrintReceipt();     //Skriver ut inmatat info samt beräkningar

        }

        private void ReadInput()        //läser inmatning från användaren mha flera andra metoder i sig
        {
            ReadProductName();

            ReadUnitPrice();

            ReadFoodItem();

            ReadAmount();

        }
        private void ReadProductName()
        {
            Console.Clear();        //rensar fönstret/console
            Console.Write("Enter the product name: ");  //printar ut och frågar användaren om produkt
            productName = Console.ReadLine();           //läser in inmatningen i variabeln 

        }
        private void ReadUnitPrice() // tar mot enhetspris/styckpris
        {
            Console.Write("Net unit price: ");
            unitPrice = double.Parse(Console.ReadLine());   //Console.Readline() läser in sträng och därför omvandlar vi det till double
                                                            //fungerar enbart med kommatecken(,) i min dator, ej punkt (.)
        }
        private void ReadFoodItem()         //frågar efter om varan är mat eller ej, för att senare välja rätt momssats
        {
            Console.Write("Food item (y/n): ");

            char answer = char.Parse(Console.ReadLine());   //gör om inmatningen från sträng till tecken

            if ((answer == 'y') || (answer == 'Y'))         //om y eller Y då är foodItem sant annars falsk
                foodItem = true;
            else
                foodItem = false;

        }
        private void ReadAmount() //tar emot inmatning antal/mängd fr användaren
        {
            Console.Write("Amount: ");
            amount = int.Parse(Console.ReadLine()); //gör om så den kan läsa av int 

        }
        private void CalculateValues() //en räknarmetod som inngehåller 3 andra metoder i sig
        {
            IncVat();
            TotalVat();
            VatPercent();
        }
        private void IncVat() //Räknar den inkluderande momsen 
        {
            if (foodItem == true)   //om inmatning y/Y 12% moms annars 25% 
                includingVat = amount * unitPrice * foodVATRate; //antal*enhetspris*matmomsen
            else
                includingVat = amount * unitPrice * otherVATRate;// annars antal*enhetspris*annan moms
        }
        private void TotalVat() //Räknar totala summan
        {
            totalNetValue = includingVat + (amount * unitPrice); //sätter summan i variabeln totalNetValue

        }
        private void VatPercent() //metod som visar i % beroende på använadrens svar
        {
            if (foodItem == true)
                vat1 = 100 * foodVATRate;
            else
                vat1 = 100 * otherVATRate;
        }
        private void PrintReceipt() //metoden som printar ut allt

        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*********************** WELCOME TO APU'S SUPERMARKET *****************");
            Console.WriteLine("***");
            Console.WriteLine("{0,-25}{1,30}", "*** Name of the product:", productName);
            Console.WriteLine("{0,-25}{1,30}", "*** Qantity:", amount);
            Console.WriteLine("{0,-25}{1,30}", "*** Unit price:", unitPrice);
            Console.WriteLine("{0,-25}{1,30}", "*** Food item:", foodItem);
            Console.WriteLine("***");
            Console.WriteLine("{0,-25}{1,30}", "*** Total amount to pay:", totalNetValue);
            Console.WriteLine("{0,-25}{1,30}", "*** Including VAT at " + vat1 + " %", includingVat);
            Console.WriteLine("***");
            Console.WriteLine("*** This program has been developed by: Ahmet Sezer ***");
            Console.WriteLine("*************************PLEASE COME AGAIN!****************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}

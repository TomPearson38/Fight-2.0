using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
        /*Name:Encasement FIght
        *Author: Tom Pearson
        *Date:14/10/19
        *Known Issues:None
        *Inputs: Move Select
        *Output: Damage, death, victory, run
        */

            int HeroStrength = 10;
            int VillanStrength = 10;
            Random random = new Random();
            int HeroDice = 0;
            int VillanDice = 0;
            string Move = "";
            bool NotEven = false;
            bool escape = false;
            Console.WriteLine("You see what seems to be another human! Calling out to them seems to return no response.");
            Console.WriteLine("Upon approaching them their skin seems to be green and giving off a putrid odour.");
            Console.WriteLine("They turn around, looking straight into your soul with a deathly stare.");
            Console.WriteLine("Sadly, you can`t do the same. As the only thing you see is dialated pupils.");
            Console.WriteLine("Their encasement however, didn`t share in this death and was still carrying the lifeless");
            Console.WriteLine("carcass of the deceased around, welded to its bone.");
            Console.WriteLine("UNKNOWN ENTITY ACTIVATING DEFENCE PROTOCOL");


            Console.ForegroundColor = ConsoleColor.Cyan;
            while ((HeroStrength >= 1 && VillanStrength >= 1) && (escape != true)) //While the enemy hasn`t been killed and the hero is unable to run it will loop
            {
                Console.WriteLine("Your health: " + HeroStrength + Environment.NewLine + "Carcass Health: " + VillanStrength);
                Console.WriteLine("Would you like to:");
                Console.WriteLine("[1] Fight");
                if (HeroStrength <= 3) //When the hero`s health is less than or equal to 3 they will be able to try to run away
                {
                    Console.WriteLine("[2] Run");
                } //Display run if

                Move = Console.ReadLine();

                if ((Move == "fight") || (Move == "Fight") || (Move == "1")) //If the fight input has been selected it will run this section of code
                {
                    do
                    {
                        HeroDice = random.Next(1, 6);
                        VillanDice = random.Next(1, 6);
                        if (HeroDice > VillanDice)
                        {
                            VillanStrength = VillanStrength - (HeroDice % VillanDice);
                            NotEven = true;
                            Console.WriteLine("You hit for " + HeroDice % VillanDice);
                        }
                        else if (VillanDice > HeroDice)
                        {
                            HeroStrength = HeroStrength - (VillanDice % HeroDice);
                            NotEven = true;
                            Console.WriteLine("They hit for " + VillanDice % HeroDice);
                        }
                    } while (NotEven == false); //If the numbers generated are the same, it will loop again
                    NotEven = false; //Resets for the next run through
                    Move = ""; //Resets for next input
                }
                else if ((HeroStrength <= 3) && ((Move == "run") || (Move == "Run") || (Move == "2"))) //If the user is able to select run (health is 3 or less) and they select it, it will run this portion of the code
                {
                    do
                    {
                        HeroDice = random.Next(1, 6);
                        VillanDice = random.Next(1, 6);
                        if (HeroDice > VillanDice)
                        {
                            Console.WriteLine("You got away!");
                            escape = true;
                            NotEven = true;
                        }
                        else if (VillanDice > HeroDice)
                        {
                            Console.WriteLine("You couldn`t escape!");
                            HeroStrength = HeroStrength - (VillanDice % HeroDice);
                            NotEven = true;
                            Console.WriteLine("They hit for " + VillanDice % HeroDice);
                        }
                    } while (NotEven == false); //If the numbers generated are the same, it will loop again
                    NotEven = false; //Resets for the next run through
                    Move = ""; //Resets for next input
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value, please try again!"); //If the other paths were not followed, the input must be incorrect and therefore the user will have to re-enter a value on the next run through of the loop
                }
            }
            if (HeroStrength <= 0)
            {
                Console.WriteLine("You died");
            }
            else if (VillanStrength <= 0)
            {
                Console.WriteLine("You Won!");
            }
            //Placed here so that it doesn`t need to be run every time the loop is followed through, only ran after the fight is over
            Console.ReadLine();
                   
        }
    }
}

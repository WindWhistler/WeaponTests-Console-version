using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Token selectedToken = null;
            List<Token> tokens = new List<Token>();

            //Create some Data
            List<Magazine> tmp = new List<Magazine>();
            tmp.Add(new Magazine("Short magazine",
                                 10,
                                 new Ammo("Default bullet",
                                          20,
                                          1,
                                          0)));
            tmp.Add(new Magazine("Short magazine",
                                 10,
                                 new Ammo("AntiArmour bullet",
                                          15,
                                          2,
                                          0)));
            tokens.Add(new Token("John Doe",
                                 100,
                                 0,
                                 new Weapon("Some Rifle",
                                            1,
                                            0,
                                            null,
                                            new Magazine("Short magazine",
                                                         10,
                                                         new Ammo("Default bullet",
                                                                  20,
                                                                  1,
                                                                  0))),
                                 null,
                                 null,
                                 tmp));
            tmp = null;
            //Show possible actions

            //View Tokens
            Console.WriteLine("0: View all tokens");
            //Select Token (*marked actions require this)
            Console.WriteLine("1: Select token");
            //View details of weapon*
            Console.WriteLine("2: View weapon");
            //View details of magazines*
            Console.WriteLine("3: View stored magazines");
            //Load one ammo to weapon*
            Console.WriteLine("4: Send one ammo from magazine to weapon");
            //Change magazine*
            Console.WriteLine("5: Change magazine in weapon");
            //Shoot*
            Console.WriteLine("6: Shoot another token");

            while (true)
            {
                //Pick action
                int action = int.Parse(Console.ReadLine());
                //Do actions
                switch (action)
                {
                    case (0):
                        for (int i = 0; i < tokens.Count; i++)
                        {
                            Console.WriteLine(i + ": " + tokens[i].ToString());
                        }
                        break;
                    case (1):
                        Console.WriteLine("Enter number of desirable token");
                        int tokenId = int.Parse(Console.ReadLine());
                        if (tokenId < tokens.Count && tokenId >= 0)
                        {
                            selectedToken = tokens[tokenId];
                            Console.WriteLine("You've picked " + selectedToken.ToString());
                        }
                        else
                        {
                            Console.WriteLine("There's no such token");
                        }
                        break;
                    case (2):
                        if (selectedToken == null)
                            Console.WriteLine("Pick token first");
                        else
                        {
                            Console.WriteLine(selectedToken.WeaponToString());
                        }
                        break;
                    case (3):
                        if (selectedToken == null)
                            Console.WriteLine("Pick token first");
                        else
                        {
                            Console.WriteLine(selectedToken.MagazinesToString());
                        }
                        break;
                    case (4):
                        if (selectedToken == null)
                            Console.WriteLine("Pick token first");
                        else
                        {
                            selectedToken.LoadAmmo();
                        }
                        break;
                    case (5):
                        if (selectedToken == null)
                            Console.WriteLine("Pick token first");
                        else
                        {
                            Console.WriteLine("Enter number of new magazine");
                            int magazineId = int.Parse(Console.ReadLine());
                            if (magazineId < selectedToken.InventorySize() && magazineId >= 0)
                            {
                                selectedToken.ChangeMagazine(magazineId);
                            }
                        }
                        break;
                    case (6):
                        if (selectedToken == null)
                            Console.WriteLine("Pick token first");
                        else
                        {
                            Console.WriteLine("Enter number of target token");
                            int TargetId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Pick where to shoot:\n" +
                                              "0 - Body\n" +
                                              "1 - Arms or Legs\n" +
                                              "2 - Head");
                            int bodyPart = int.Parse(Console.ReadLine());
                            if (TargetId < tokens.Count && TargetId >= 0
                                && bodyPart >= 0 && bodyPart <= 2)
                            {
                                selectedToken.Shoot(tokens[TargetId], bodyPart);
                                Console.WriteLine(tokens[TargetId].ToString());
                            }
                        }
                        break;
                    default:
                        return;
                }
            }
            
        }
    }
}

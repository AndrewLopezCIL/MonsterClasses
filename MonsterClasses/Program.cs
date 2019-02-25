using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterClasses
{

    class Program
    {
        static SeaMonster seamonster;
        static SpaceMonster spacemonster;
        static LandMonster landmonsters;
        static List<SeaMonster> seaMonsterList = new List<SeaMonster>();
        static List<SpaceMonster> spaceMonsterList = new List<SpaceMonster>();
        static List<LandMonster> landMonsterList = new List<LandMonster>();
        static void Main(string[] args)
        {
            DisplayWelcomeScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }
        static SeaMonster InitializeSeaMonster()
        {
            return new SeaMonster()
            {
                Id = 34,
                Name = "Suzie",
                Age = 473,
                HasGills = true,
                HomeSea = "Baltic Sea"
            };

        }

        static SpaceMonster InitializeSpaceMonster()
        {
            return new SpaceMonster
            {
                Id = 56,
                Name = "Sid",
                Age = 18,
                Galaxy = "Andromeda"
            };

        }
        static LandMonster IntializeLandMonster()
        {
            return new LandMonster
            {
                Id = 1,
                Name = "Mark",
                Age = 15,
                MothersName = "Teresa",
                Ancestor = "Ken",
                AttackType = "Slash",
                CanFly = true,
                HasFood = true,
                NumberOfKids = 33
            };
        }

        private static void DisplayMenu()
        {
            bool exitMenu = false;
            int menuSelection;
            SeaMonster mySeaMonster;
            SpaceMonster mySpaceMonster;
            LandMonster myLandMonster;
            mySeaMonster = InitializeSeaMonster();
            mySpaceMonster = InitializeSpaceMonster();
            myLandMonster = IntializeLandMonster();
            seaMonsterList.Add(mySeaMonster);
            spaceMonsterList.Add(mySpaceMonster);
            landMonsterList.Add(myLandMonster);
            do
            {
                Console.Clear();
                DisplayHeader("Menu");
                Console.WriteLine("1) Display Monsters");
                Console.WriteLine("2) Edit Monsters");
                Console.WriteLine("3) Create Land Monster");
                Console.WriteLine("4) Exit");
                Console.WriteLine("Enter Selection");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out menuSelection))
                    { 
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You did not enter a valid selection number, please try again.");
                    }

                }

                switch (menuSelection)
                {
                    case 1:
                        DisplayMonsterInfoScreen(mySeaMonster, mySpaceMonster, myLandMonster, landMonsterList, seaMonsterList, spaceMonsterList);
                        break;
                    case 2:
                        DisplayEditSeaMonster(seaMonsterList,spaceMonsterList,landMonsterList);
                        break;
                    case 3:
                       LandMonster monster = DisplayCreateMonster();
                        landMonsterList.Add(monster);
                       break;
                    case 4:
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a proper selection");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!exitMenu);
        }
        private static LandMonster DisplayCreateMonster()
        { 
            LandMonster landMonster = new LandMonster();
            Console.WriteLine("What would you like to name your monster?");
            string userResponse = Console.ReadLine();

            landMonster.Name = userResponse;

            Console.WriteLine("What is your monster's ID?");

            while (true)
            {
                int id;
                userResponse = Console.ReadLine();
                if (int.TryParse(userResponse, out id))
                {
                    landMonster.Id = id;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer for the ID.");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Please enter the age of your monster.");
            while (true)
            {
                int age;
                userResponse = Console.ReadLine();
                if (int.TryParse(userResponse, out age))
                {
                    landMonster.Age = age;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer for the age of your monster.");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Enter your monster's ancestor.");
            string ancestor = Console.ReadLine();
            landMonster.Ancestor = ancestor;
            Console.WriteLine();
            Console.WriteLine("Please enter whether or not your monster can fly. <TRUE> or <FALSE>");
            while (true)
            {
                bool canfly;
                userResponse = Console.ReadLine().ToLower();
                if (bool.TryParse(userResponse, out canfly))
                {
                    landMonster.CanFly = canfly;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter TRUE or FALSE.");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the attack type of your monster");
            userResponse = Console.ReadLine();
            landMonster.AttackType = userResponse;

            Console.WriteLine("Please enter the name of your monster's mother.");
            userResponse = Console.ReadLine();
            landMonster.MothersName = userResponse;
            Console.WriteLine("How many kids does your monster have?");
            while (true)
            {
                int kids;
                userResponse = Console.ReadLine();
                if (int.TryParse(userResponse, out kids))
                {
                    landMonster.NumberOfKids = kids;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter an integer for the amount of kids.");
                }
               
            }
            Console.WriteLine("Does your monster have food?");
            while (true)
            {
                bool food;
                userResponse = Console.ReadLine().ToLower();
                if (bool.TryParse(userResponse, out food))
                {
                    landMonster.HasFood = food;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter TRUE or FALSE");
                }
            }

            return landMonster;
        }
        private static void DisplayEditSeaMonster(List<SeaMonster> seaMonsterList, List<SpaceMonster> spaceMonsterList, List<LandMonster> landMonsterList)
        {
            Console.WriteLine("What monster would you like to edit?");
            Console.WriteLine("Please enter one of the monster name's below:\n");
            foreach (SeaMonster seaMonster in seaMonsterList)
            {
                Console.WriteLine(seaMonster.Name + "\n");
            }
              
        foreach (SpaceMonster spaceMonster in spaceMonsterList)
	        {
                Console.WriteLine(spaceMonster.Name + "\n");
            }
            foreach (LandMonster landMonster in landMonsterList)
            {
                Console.WriteLine(landMonster.Name + "\n");
            }
            bool runningMainLoop=true;
            while (runningMainLoop)
            {
                string monster = Console.ReadLine();
                bool monsterFound = false;
                string monsterType = "";
               
                foreach(SeaMonster seaMonsters in seaMonsterList)
                {
                    if (seaMonsters.Name.ToLower() == monster.ToLower())
                    {
                        Console.WriteLine("Found in seaMonsterList");
                        monsterFound = true;
                        monsterType = "seaMonster";
                        seamonster = seaMonsters;
                        break;
                    } 
                }
                if (!monsterFound) {
                    foreach (SpaceMonster spaceMonsters in spaceMonsterList)                     
                    {
                        if (spaceMonsters.Name.ToLower() == monster.ToLower())
                        {
                            Console.WriteLine("Found in spaceMonsterList");
                            monsterFound = true;
                            monsterType = "spaceMonster";
                            spacemonster = spaceMonsters;
                            break;
                        }

                    }
                    if (!monsterFound)
                    {
                        foreach (LandMonster landM in landMonsterList)
                        {
                            if (landM.Name.ToLower() == monster.ToLower())
                            {
                                Console.WriteLine("Found in landMonsterList");
                                monsterFound = true;
                                monsterType = "landMonster";
                                landmonsters = landM;
                                break;
                            }
                        }
                    }
                } 

                if (monsterFound)
                {
                    
                    if (monsterType == "seaMonster")
                    {
                        Console.WriteLine("What would you like to edit for the monster: "+ monster);
                        bool editProp = true;
                        displayEditableProperties("seamonster");
                        while (editProp)
                        {
                            
                            string userResponse = Console.ReadLine().ToUpper();
                            switch (userResponse)
                            {
                                case "ID":
                                    seamonster.Id = editID();
                                    Console.WriteLine("You have changed " + monster + "'s ID to " + seamonster.Id);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear(); 
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("seamonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "NAME":
                                    seamonster.Name = editName();
                                    Console.WriteLine("You have changed " + monster + "'s Name to " + seamonster.Name);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear(); 
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("seamonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "AGE":
                                    seamonster.Age = editAge();
                                    Console.WriteLine("You have changed " + monster + "'s Age to " + seamonster.Age);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("seamonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "HASGILLS":
                                    seamonster.HasGills = editHasGills();
                                    Console.WriteLine("You have changed " + monster + "'s Happiness to " + seamonster.IsHappy());
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("seamonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break; 
                                case "HOMESEA":
                                    seamonster.HomeSea = editHomeSea();
                                    Console.WriteLine("You have changed " + monster + "'s HOMESEA to " + seamonster.HomeSea);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("seamonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                default:
                                    Console.Clear();
                                    displayEditableProperties("seaMonster");
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid entry, what would you like to edit?");
                                    break;
                            }
                        }

                    }
                   else if (monsterType == "landMonster")
                    {
                        Console.WriteLine("What would you like to edit for the monster: " + monster);
                        bool editProp = true;
                        displayEditableProperties("landMonster");
                        while (editProp)
                        {

                            string userResponse = Console.ReadLine().ToUpper();
                            switch (userResponse)
                            {
                                case "ID":
                                    landmonsters.Id = editID();
                                    Console.WriteLine("You have changed " + monster + "'s ID to " + landmonsters.Id);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "NAME":
                                    landmonsters.Name = editName();
                                    Console.WriteLine("You have changed " + monster + "'s Name to " + landmonsters.Name);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "AGE":
                                    landmonsters.Age = editAge();
                                    Console.WriteLine("You have changed " + monster + "'s Age to " + landmonsters.Age);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "HASFOOD":
                                    landmonsters.HasFood = editHasFood();
                                    Console.WriteLine("You have changed " + monster + "'s Happiness to " + landmonsters.IsHappy());
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "NUMBEROFKIDS":
                                    landmonsters.NumberOfKids = editNumberOfKids();
                                    Console.WriteLine("You have changed " + monster + "'s NUMBER OF KIDS to " + landmonsters.NumberOfKids);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "ANCESTOR":
                                    landmonsters.Ancestor = editAncestor();
                                    Console.WriteLine("You have changed " + monster + "'s ANCESTOR to " + landmonsters.Ancestor);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "CANFLY":
                                    landmonsters.CanFly = editCanFly();
                                    Console.WriteLine("You have changed " + monster + "'s CAN FLY to " + landmonsters.CanFly);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "MOTHERSNAME":
                                    landmonsters.MothersName = editMothersName();
                                    Console.WriteLine("You have changed " + monster + "'s Mother's Name to " + landmonsters.MothersName);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "ATTACKTYPE":
                                    landmonsters.AttackType = editAttackType();
                                    Console.WriteLine("You have changed " + monster + "'s Attack Type to " + landmonsters.AttackType);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("landMonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                default:
                                    Console.Clear();
                                    displayEditableProperties("landMonster");
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid entry, what would you like to edit?");
                                    break;
                            }
                        }

                    }
                    else if (monsterType == "spaceMonster")
                    {
                        Console.WriteLine("What would you like to edit for the monster: " + monster);
                        bool editProp = true;
                        displayEditableProperties("spacemonster");
                        while (editProp)
                        {

                            string userResponse = Console.ReadLine().ToUpper();
                            switch (userResponse)
                            {
                                case "ID":
                                    spacemonster.Id = editID();
                                    Console.WriteLine("You have changed " + monster + "'s ID to " + spacemonster.Id);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear(); 
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("spacemonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "NAME":
                                    spacemonster.Name = editName();
                                    Console.WriteLine("You have changed " + monster + "'s Name to " + spacemonster.Name);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear(); 
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("spacemonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "AGE":

                                    spacemonster.Age = editAge();
                                    Console.WriteLine("You have changed " + monster + "'s Age to " + spacemonster.Age);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("spacemonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break; 
                                case "HASFOOD":
                                    spacemonster.HasFood = editIsHappy();
                                    Console.WriteLine("You have changed " + monster + "'s Happiness to " + spacemonster.IsHappy());
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("spacemonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                case "GALAXY":
                                    spacemonster.Galaxy = editGalaxy();
                                    Console.WriteLine("You have changed " + monster + "'s GALAXY to " + spacemonster.Galaxy);
                                    if (editAgain())
                                    {
                                        editProp = true;
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("What else would you like to edit?");
                                        displayEditableProperties("spacemonster");
                                    }
                                    else
                                    {
                                        editProp = false;
                                        runningMainLoop = false;
                                    }
                                    break;
                                default:
                                    Console.Clear();
                                    displayEditableProperties("spaceMonster");
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid entry, what would you like to edit?");
                                    break;
                            }
                        }
                    }
                    }
                   
                else
                {
                    Console.WriteLine("Monster by the name of " + monster + ", please try again.");
                }
            }
        }
        private static string editAttackType()
        {
            Console.WriteLine("What would you like to set your monster's attack type to?");
            string userResponse = Console.ReadLine();

            return userResponse;
        }
        private static string editMothersName()
        {
            Console.WriteLine("What would you like to set your monster's mother's name to?");
            string userResponse = Console.ReadLine();
            return userResponse;
        }
        private static bool editCanFly()
        {
            bool fly;
            Console.WriteLine("What would you like to set your monster's fly ability to? <TRUE> or <FALSE>");
            while (true)
            {
            string userResponse = Console.ReadLine();

            if (bool.TryParse(userResponse, out fly))
            {
                    Console.WriteLine("Fly ability set.");
                    Console.WriteLine();
                    break;
            }
                else
                {
                    Console.WriteLine("Invalid entry, please enter TRUE or FALSE");
                }
            }
            return fly;
        }
        private static void displayEditableProperties(string monsterType)
        {
            if (monsterType.ToLower() == "seamonster")
            {
                Console.WriteLine("ID");
                Console.WriteLine("NAME");
                Console.WriteLine("AGE");
                Console.WriteLine("HASGILLS"); 
                Console.WriteLine("HOMESEA");
            }
            else if (monsterType.ToLower() == "spacemonster")
            {
                Console.WriteLine("ID");
                Console.WriteLine("NAME");
                Console.WriteLine("AGE");
                Console.WriteLine("GALAXY");
                Console.WriteLine("HASFOOD");
            }
            else if (monsterType.ToLower() == "landmonster")
            {
                Console.WriteLine("ID");
                Console.WriteLine("NAME");
                Console.WriteLine("AGE");
                Console.WriteLine("ANCESTOR");
                Console.WriteLine("HASFOOD");
                Console.WriteLine("NUMBEROFKIDS"); 
                Console.WriteLine("MOTHERSNAME");
                Console.WriteLine("ATTACKTYPE");
                Console.WriteLine("CANFLY");
            }
        }
        private static string editAncestor()
        {
            Console.WriteLine("Who is your monster's ancestor?");
            string userResponse = Console.ReadLine();
            return userResponse;
        }
        private static string editGalaxy()
        {
            string galaxy;

            Console.WriteLine("What would you like to change GALAXY to? (Entry has to be a name)");
            while (true)
            {
                galaxy= Console.ReadLine();
                if (galaxy != "")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter a name for the new galaxy.");
                }
            }
            return galaxy;
        }
         private static bool editAgain()
        {
            bool editAgain;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to edit anything else? <YES> or <NO>");
                string userResponse = Console.ReadLine();
                if (userResponse.ToLower() == "yes")
                {
                    editAgain = true;
                    break;
                }
                else if (userResponse.ToLower() == "no")
                {
                    editAgain = false;
                    Console.WriteLine("Returning to menu, press any key to continue..");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no.");
                }
            }
            return editAgain;
        }
        private static string editHomeSea()
        {
            string homesea; 

            Console.WriteLine("What would you like to change HOMESEA to? (Entry has to be a name)");
            while (true)
            {
                homesea = Console.ReadLine();
                if (homesea != "")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter a name for the new homesea.");
                }
            }
            return homesea;
        }
        private static string editName()
        {
            string name; 

            Console.WriteLine("What would you like to change NAME to?");
            while (true)
            {
                name = Console.ReadLine();
                if (name != "") {
                    break;
                }
            }
            return name;
        }
        private static bool editHasFood()
        {
            string option;
            bool isHappy;

            Console.WriteLine("What would you like to change HAS FOOD to? (Entry has to be TRUE or FALSE)");
            while (true)
            {
                option = Console.ReadLine();

                if (bool.TryParse(option, out isHappy))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please enter TRUE or FALSE.");
                }
            }
            return isHappy;
        }
        private static bool editIsHappy()
        {
            string option;
            bool isHappy;

            Console.WriteLine("What would you like to change IsHappy to? (Entry has to be TRUE or FALSE)");
            while (true)
            {
                option = Console.ReadLine();
                 
                if (bool.TryParse(option, out isHappy))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please enter TRUE or FALSE.");
                }
            }
            return isHappy;
        }
        private static bool editHasGills()
        {
            string option;
            bool gills;

            Console.WriteLine("What would you like to change HasGills to? (Entry must be TRUE or FALSE)");
            while (true)
            {
                option = Console.ReadLine();
                if (bool.TryParse(option.ToLower(), out gills))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please enter TRUE or FALSE.");
                }
            }
            return gills;
        }
        private static int editNumberOfKids()
        {

            string option;
            int num;

            Console.WriteLine("What would you like to change Number of Kids to? (Entry has to be an integer)");
            while (true)
            {
                option = Console.ReadLine();
                if (int.TryParse(option, out num))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                }
            }
            return num;
        }
        private static int editAge()
        {
            string option;
            int num;

            Console.WriteLine("What would you like to change AGE to? (Entry has to be an integer)");
            while (true)
            {
                option = Console.ReadLine();
                if (int.TryParse(option, out num))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                }
            }
            return num;
        }
         private static int editID()
        {
            string option; 
            int num;
            
            Console.WriteLine("What would you like to change ID to? (Entry has to be an integer)");
            while (true)
            {
                option = Console.ReadLine();
                if (int.TryParse(option, out num))
                { 
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please try again."); 
                }
            }
            return num;
        }
        private static void DisplayMonsterInfoScreen(SeaMonster seaMonster, SpaceMonster spaceMonster, LandMonster landMonster, List<LandMonster> landMonsterList, List<SeaMonster> seaMonsterList, List<SpaceMonster> spaceMonsterList)
        {

            Console.WriteLine("What type of monsters would you like to see? <SEAMONSTER> <LANDMONSTER> <SPACEMONSTER> or <ALL>");
            while (true)
            {
                string userResponse = Console.ReadLine();
                if (userResponse.ToLower() == "seamonster")
                {
                    DisplayHeader("Seamonster Info"); 
                    DisplaySeaMonsterInfo(seaMonsterList);
                    Console.WriteLine("Press any key to continue.."); 
                    Console.ReadLine();
                    break;
                }
                else if (userResponse.ToLower() == "landmonster")
                {
                    DisplayHeader("Landmonster Info");
                    DisplayLandMonsterInfo(landMonsterList);
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadLine();
                    break;
                }
                else if (userResponse.ToLower() == "spacemonster")
                {
                    DisplayHeader("Spacemonster Info");
                    DisplaySpaceMonsterInfo(spaceMonsterList);
                    Console.WriteLine("Press any key to continue.."); 
                    Console.ReadLine();
                    break;
                }
                else if (userResponse.ToLower() == "all")
                {
                    DisplayHeader("Seamonster Info");
                    DisplaySeaMonsterInfo(seaMonsterList);
                    DisplayHeader("Landmonster Info");
                    DisplayLandMonsterInfo(landMonsterList);
                    DisplayHeader("Spacemonster Info");
                    DisplaySpaceMonsterInfo(spaceMonsterList);
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter one of the following: SEAMONSTER or LANDMONSTER or SPACEMONSTER or ALL");
                }
            }

             
         
        }
        private static void DisplayLandMonsterInfo(List<LandMonster> landMonsterList)
        {
            foreach (LandMonster landmonster in landMonsterList) {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"id: {landmonster.Id}");
                Console.WriteLine($"Name: {landmonster.Name}");
                Console.WriteLine($"Age: {landmonster.Age}");
                Console.WriteLine($"Ancestor: {landmonster.Ancestor}");
                Console.WriteLine($"AttackType: {landmonster.AttackType}");
                Console.WriteLine($"HasFood: {landmonster.HasFood}");
                Console.WriteLine($"NumberOfKids: {landmonster.NumberOfKids}");
                Console.WriteLine($"NumberOfKids: {landmonster.CanFly}");
                Console.WriteLine($"NumberOfKids: {landmonster.MothersName}");
                Console.WriteLine($"Is happy: {(landmonster.IsHappy() ? "yes" : "no")}");
            }

        }
         private static void DisplaySpaceMonsterInfo(List<SpaceMonster> spaceMonsterList)
         {
            foreach (SpaceMonster spaceMonster in spaceMonsterList)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"id: {spaceMonster.Id}");
                Console.WriteLine($"Name: {spaceMonster.Name}");
                Console.WriteLine($"Age: {spaceMonster.Age}");
                Console.WriteLine($"Galaxy: {spaceMonster.Galaxy}");
                Console.WriteLine($"Is happy: {(spaceMonster.IsHappy() ? "yes" : "no")}");
                Console.WriteLine($"You attacked {spaceMonster.Name} and they {spaceMonster.MonsterBattleRepsonse()}");
            } }
        private static void DisplaySeaMonsterInfo(List<SeaMonster> seaMonsterList)
        {
            foreach (SeaMonster seaMonster in seaMonsterList)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Has gills: {seaMonster.HasGills}");
                Console.WriteLine($"Home sea: {seaMonster.HomeSea}");
                Console.WriteLine($"Id: {seaMonster.Id}");
                Console.WriteLine($"Age: {seaMonster.Age}");
                Console.WriteLine($"Name: {seaMonster.Name}");
                Console.WriteLine($"Is happy: {seaMonster.IsHappy()}");
            }
        }



        private static void DisplayHeader(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
        }

        //
        // Display the continue prompt
        //
        static void DisplayContinuePrompt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        //
        // Display the message you want to output.
        //
        static void OutputMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("");
        }
        //
        // Display the welcome screen.
        //
        static void DisplayWelcomeScreen()
        {
            Console.WriteLine("\t\tWelcome to My App");
        }
        //
        // Display the closing screen.
        //
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using my App!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        static void DisplayOurLocation(string location)
        {
            DisplayHeader();
            Console.WriteLine(location);
            DisplayContinuePrompt();
        }
        static void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("Our Location");
            Console.WriteLine();
        }
        static void DisplayOurFavoriteDonut()
        {
            DisplayHeader();

            Console.WriteLine("Chocolate Donuts");

            DisplayContinuePrompt();
        }
    }
}
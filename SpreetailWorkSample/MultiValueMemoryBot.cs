using System;
using System.Collections.Generic;

namespace SpreetailWorkSample
{
    public class MultiValueMemoryBot
    {
        Dictionary<string, List<string>> memoryStorage = new Dictionary<string, List<string>>();

        public void RunMultiValueMemoryBot()
        {
            string[] addInputList;
            do
            {
                Console.WriteLine("<");

                string addInput = Console.ReadLine();
                addInputList = addInput.Split(" ");
                switch (addInputList[0])
                {
                    case "ADD":
                        {
                            if (addInputList.Length != 3)
                            {
                                Console.WriteLine("Please enter a key and a value. \n");
                            }
                            try
                            {
                                List<string> values;
                                memoryStorage.TryGetValue(addInputList[1], out values);
                                if (memoryStorage.ContainsKey(addInputList[1]) && values.Contains(addInputList[2]))
                                {
                                    Console.WriteLine(") Value already exists. \n");
                                }
                                else
                                {
                                    if (memoryStorage.ContainsKey(addInputList[1]))
                                    {
                                        memoryStorage.GetValueOrDefault(addInputList[1]).Add(addInputList[2]);
                                    }
                                    else
                                    {
                                        memoryStorage.Add(addInputList[1], new List<string> { addInputList[2] });
                                    }
                                    Console.WriteLine(") Added \n");
                                }

                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("An error occurred. " + ex.Message);
                            }
                            break;
                        }
                    case "MEMBERS":
                        {
                            if (addInputList.Length != 2)
                            {
                                Console.WriteLine("Please provide correct number of arguments");
                            }
                            else
                            {
                                try
                                {
                                    if (memoryStorage == null || memoryStorage.Count == 0 || !memoryStorage.ContainsKey(addInputList[1]))
                                    {
                                        Console.WriteLine("Key does not exist");
                                    }
                                    else
                                    {
                                        List<string> memberValues = memoryStorage.GetValueOrDefault(addInputList[1]);

                                        int counter = 1;

                                        memberValues.ForEach(mv => Console.WriteLine(string.Format("{0}) {1}" + "\n", counter++, mv)));
                                    }


                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }

                            break;
                        }
                    case "KEYS":
                        {
                            if (addInputList.Length != 1)
                            {
                                Console.WriteLine("Please provide correct number of arguments.");
                            }
                            else
                            {
                                try
                                {
                                    if (memoryStorage.Keys == null || memoryStorage.Keys.Count == 0)
                                    {
                                        Console.WriteLine("The dictionary doesn't have any keys in it.");
                                    }
                                    else
                                    {
                                        List<string> keys = new List<string> (memoryStorage.Keys);

                                        int counter = 1;

                                        keys.ForEach(mv => Console.WriteLine(string.Format("{0}) {1}" + "\n", counter++, mv)));
                                    }


                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }
                            break;
                        }
                    case "REMOVE":
                        {
                            if (addInputList.Length != 3)
                            {
                                Console.WriteLine("Please provide correct number of arguments.");
                            }
                            else
                            {
                                try
                                {
                                    if (!memoryStorage.ContainsKey(addInputList[1]))
                                    {
                                        Console.WriteLine("The given key doesn't exist.");
                                    }
                                    else if(!memoryStorage.GetValueOrDefault(addInputList[1]).Contains(addInputList[2]))
                                    {
                                        Console.WriteLine("The value for the given key doesn't exist.");
                                    }
                                    else
                                    {
                                        if (memoryStorage.GetValueOrDefault(addInputList[1]).Count > 1)
                                        {
                                            memoryStorage.GetValueOrDefault(addInputList[1]).Remove(addInputList[2]);
                                        }
                                        else
                                        {
                                            memoryStorage.Remove(addInputList[1]);
                                        }
                                        Console.WriteLine(") Removed \n");
                                    }


                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }
                            break;
                        }
                    case "REMOVEALL":
                        {
                            if (addInputList.Length != 2)
                            {
                                Console.WriteLine("Please provide correct number of arguments.");
                            }
                            else
                            {
                                try
                                {
                                    if (!memoryStorage.ContainsKey(addInputList[1]))
                                    {
                                        Console.WriteLine("The given key doesn't exist.");
                                    }
                                    else
                                    {
                                       memoryStorage.Remove(addInputList[1]);
                                        
                                       Console.WriteLine(") Removed \n");
                                    }


                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }
                            break;
                        }
                    case "CLEAR":
                        {
                            if (addInputList.Length != 1)
                            {
                                Console.WriteLine("Please provide correct number of arguments.");
                            }
                            else
                            {
                                try
                                {
                                    if (memoryStorage != null)
                                    {
                                        memoryStorage.Clear();

                                        Console.WriteLine(") Cleared \n");
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }
                            break;
                        }
                    case "KEYEXISTS":
                        {
                            if (addInputList.Length != 2)
                            {
                                Console.WriteLine("Please provide correct number of arguments.");
                            }
                            else
                            {
                                try
                                {
                                    if (memoryStorage == null || memoryStorage.Count == 0)
                                    {
                                        Console.WriteLine(") False \n");
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format(") {0}", memoryStorage.ContainsKey(addInputList[1])));
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }
                            break;
                        }
                    case "VALUEEXISTS":
                        {
                            if (addInputList.Length != 3)
                            {
                                Console.WriteLine("Please provide correct number of arguments.");
                            }
                            else
                            {
                                try
                                {
                                    if (memoryStorage == null || memoryStorage.Count == 0 || !memoryStorage.ContainsKey(addInputList[1]))
                                    {
                                        Console.WriteLine(") False \n");
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format(") {0}", memoryStorage.GetValueOrDefault(addInputList[1]).Contains(addInputList[2])));
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }
                            break;
                        }
                    case "ALLMEMBERS":
                        {
                            if (addInputList.Length != 1)
                            {
                                Console.WriteLine("Please provide correct number of arguments.");
                            }
                            else
                            {
                                try
                                {
                                    if (memoryStorage == null || memoryStorage.Count == 0 || memoryStorage.Keys == null || memoryStorage.Keys.Count == 0)
                                    {
                                        Console.WriteLine(") Empty Set \n");
                                    }
                                    else
                                    {
                                        int counter = 1;
                                        List<string> keys = new List<string>(memoryStorage.Keys);

                                        keys.ForEach(k => memoryStorage.GetValueOrDefault(k).ForEach(member => Console.WriteLine(string.Format("{0}) {1}" + "\n", counter++, member))));
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }
                            break;
                        }
                    case "ITEMS":
                        {
                            if (addInputList.Length != 1)
                            {
                                Console.WriteLine("Please provide correct number of arguments.");
                            }
                            else
                            {
                                try
                                {
                                    if (memoryStorage == null || memoryStorage.Count == 0)
                                    {
                                        Console.WriteLine(") Empty Set \n");
                                    }
                                    else
                                    {
                                        int counter = 1;
                                        List<string> keys = new List<string>(memoryStorage.Keys);

                                        keys.ForEach(k => memoryStorage.GetValueOrDefault(k).ForEach(member => Console.WriteLine(string.Format("{0}) {1} : {2}" + "\n", counter++,k, member))));
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("An error occurred. " + ex.Message);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            } while (addInputList[0] != "EXIT");

            
        }
    }
}

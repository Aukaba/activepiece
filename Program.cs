namespace file_h
{
    class CRUD
    {
        public void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    Console.WriteLine("File created successfully.");
                }
            }

        }
        public void ReadFile(string filePath)
        {
            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    string? line;
                    Console.WriteLine("File Content: ");
                    bool contentFound = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        contentFound = true;
                    }
                    if (!contentFound)
                    {
                        Console.WriteLine("--");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Failed to read file.");
            }
        }
        public void UpdateFile(string filePath)
        {
            try
            {
                string? content = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(content))

                {
                clear:
                    Console.Write("Clear Content? [y/n]: ");
                    string? input = Console.ReadLine();
                    while (true)
                    {
                        try
                        {
                            if (input == "y")
                            {
                                File.WriteAllText(filePath, string.Empty);
                                break;
                            }
                            else if (input == "n")
                            {
                                break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid choice input. Only yes [y] or no [n].");
                            goto clear;
                        }

                    }
                }
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    Console.WriteLine("Input text: ");
                    writer.WriteLine(Console.ReadLine());
                }
                Console.WriteLine("File has been updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Failed to update file.");
            }
        }
        public void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
                Console.WriteLine("File has been deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Failed to delete file.");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUD crud = new CRUD();
            Console.Write("Enter name file: ");
            string? name = Console.ReadLine();
            string FilePath = $"Z:\\L65X12W19\\Reambonanza\\Personal\\file\\{name}.txt";
            while (true)
            {
                start:
                crud.CreateFile(FilePath);
                crud.ReadFile(FilePath);
                crud.UpdateFile(FilePath);
                delete:
                Console.Write($"Delete {name}.txt file? [y/n]: ");
                string? input = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        if (input == "y")
                        {
                            crud.DeleteFile(FilePath);
                            Console.WriteLine("Thank you for using the file handler.");
                            break;
                        }
                        else if (input == "n")
                        {
                            Console.WriteLine("Understood, saving file...");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid choice input. Only yes [y] or no [n].");
                        goto delete;
                    }
                }
                Console.WriteLine("\nWould you like to use the handler again? [y/n]: ");
                string? inputb = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        if (input == "y")
                        {
                            goto start;
                        }
                        else if (input == "n")
                        {
                            Console.WriteLine("Understood, thank you for using the file handler.");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid choice input. Only yes [y] or no [n].");
                        goto delete;
                    }
                }

            }
        }
    }
}

#region requirements

//Task 1
//Create a folder named "Files".
//Create a file name "names.txt"

//Task 2
//Read the file created in the previous task named "names.txt"
//Ask the user to enter some names and save these names in the file that we previously created.

//Task 3
//Read the file created in the previous task name "names.txt"
//Go thru the file content and filter out all the names that start with A. 
//If there are any names create a new file named "namesStartingWith_A.txt" that will contains the filtered content and if there is no names that start with A do nothing.
//Do this for all the letters in the alphabet.

//Task 4
//Redo Task 3 but if the file already exists add the new names in the file and keep the already existing names.

#endregion

using Class09.Homework;

//simple check
string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine($"Current Directory: {currentDirectory}");

//Task1
string filesFolderPath = @"..\..\..\Files";
string fileName = "names.txt";

bool filesFolderExists = Directory.Exists(filesFolderPath);
bool fileExists = File.Exists(fileName);

//combine the folder and the file
string combineFileToFolder = Path.Combine(filesFolderPath, fileName);

Console.WriteLine("The folder 'Files' exists: {0}", filesFolderExists);

//Create Folder 
if (!filesFolderExists)
{
    Directory.CreateDirectory(filesFolderPath);
    ConsoleHelper.WriteInColor("Succesfully created folder Files", ConsoleColor.Green);
}
else
{
    ConsoleHelper.WriteInColor("Files folder already exists", ConsoleColor.DarkYellow);
}

//Create File
if (!fileExists)
{
    File.Create(combineFileToFolder);
    ConsoleHelper.WriteInColor($"The file {fileName} has been successfully created", ConsoleColor.Green);
}
else
{
    ConsoleHelper.WriteInColor("File already exists.", ConsoleColor.DarkYellow);
}

using DungeonCrawler;
using System.Xml.Linq;


string currentDirectory = Directory.GetCurrentDirectory();

string projectRoot = Path.GetFullPath(Path.Combine(currentDirectory, @".\Levels"));
string filePath = Path.Combine(projectRoot, "Level1.txt");

LevelData level = new LevelData();
level.Load(filePath);

level.Draw();


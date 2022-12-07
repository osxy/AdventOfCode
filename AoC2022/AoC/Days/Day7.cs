using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AoC2022.Days
{

    public class Day7 : IDays
    {

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }

        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var tree = parseInputToFileTree(input);


            return tree.Where(x => x.FileSize <= 100000 && x.ContentType == ConType.Folder).Sum(x => x.FileSize);
        }

        public int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var tree = parseInputToFileTree(input);

            var currentTotal = tree.Where(x => x.Name == "/").Select(x => x.FileSize).Sum();
            var amountToFreeUp = 30000000 - 70000000 + currentTotal;

            return tree.Where(x => x.FileSize >= amountToFreeUp && x.ContentType == ConType.Folder).OrderBy(x => x.FileSize).FirstOrDefault().FileSize;
        }


        public List<FileTreeContent> parseInputToFileTree(string[] input)
        {

            var tree = new List<FileTreeContent>();
            tree.Add(new FileTreeContent{ Name = "/", ContentType = ConType.Folder});
            var currentTreeId = tree.Where(x => x.Name == "/").Select(x => x.id).FirstOrDefault();

            for(var y = 1; y < input.Length; y++)
            {
                var lineArray = input[y].Split(' ');
                if (IsCommand(lineArray))
                {
                    switch (lineArray[1])
                    {
                        case "cd":
                            switch (lineArray[2])
                            {
                                case "..":
                                    var parentTreeId = tree.Where(x => x.id == currentTreeId).Select(x => x.parentId).FirstOrDefault();
                                    currentTreeId = tree.Where(x => x.id == parentTreeId).Select(x => x.id).FirstOrDefault();
                                    break;
                                default:
                                    currentTreeId = tree.Where(x => x.parentId == currentTreeId && x.Name == lineArray[2]).Select(x => x.id).FirstOrDefault();
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {

                    switch(lineArray[0])
                    {
                        case "dir":
                            tree.Add(new FileTreeContent { Name = lineArray[1], ContentType = ConType.Folder, parentId = currentTreeId });
                            break;
                        default:
                            tree.Add(new FileTreeContent { Name = lineArray[1], ContentType = ConType.File, FileSize = int.Parse(lineArray[0]), parentId = currentTreeId });
                            Guid? deeperId = currentTreeId;
                            do
                            {

                                tree.Where(x => x.id == deeperId).First().FileSize += int.Parse(lineArray[0]);
                                deeperId = tree.Where(x => x.id == deeperId).Select(x => x.parentId).FirstOrDefault();


                            } while (deeperId != Guid.Empty);
                            break;
                    }


                }


            }

            return tree;
        }

        private bool IsCommand(string[] input) => input[0] == "$";

        public class FileTreeContent
        {
            public string Name { get; set; }
            [DefaultValue(ConType.File)]
            public ConType ContentType { get; set; }
            [DefaultValue(0)]
            public int FileSize { get; set; }
            public Guid parentId { get; set; }
            public Guid id { get; set; } = Guid.NewGuid();
        }

        public enum ConType
        {
            File,
            Folder
        }

    }
}

namespace AoC2020.Days
{

    public class Day12 : IDays
    {

        const char North = 'N';
        const char South = 'S';
        const char East = 'E';
        const char West = 'W';
        const char Left = 'L';
        const char Right = 'R';
        const char Forward = 'F';

        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }


        public int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            return 0;
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var shipLocation = new Location { x = 0, y = 0, orientation = Orientation.East };

            foreach(string instruction in input)
            {
                shipLocation = ProcessInstruction(shipLocation, instruction);
            }


            var x = shipLocation.x < 0 ? shipLocation.x * -1 : shipLocation.x;
            var y = shipLocation.y < 0 ? shipLocation.y * -1 : shipLocation.y;

            return x+y;
        }

        public Location ProcessInstruction(Location location, string instruction)
        {
            var amount = int.Parse(instruction[1..]);
            Orientation moveOrientation = Orientation.East;
            bool move = false;

            switch (instruction[0])
            {
                case North:
                    moveOrientation = Orientation.North;
                    move = true;
                    break;
                case South:
                    moveOrientation = Orientation.South;
                    move = true;
                    break;
                case East:
                    moveOrientation = Orientation.East;
                    move = true;
                    break;
                case West:
                    moveOrientation = Orientation.West;
                    move = true;
                    break;
                case Forward:
                    moveOrientation = location.orientation;
                    move = true;
                    break;
                case Left:
                    location = ProcesRotation(location, Rotate.Left, amount);
                    break;
                case Right:
                    location = ProcesRotation(location, Rotate.Right, amount);
                    break;
            }

            if (move)
            {
                location = ProcesMovement(location, amount, moveOrientation);
            }

            return location;

        }

        public Location ProcesMovement(Location location, int amount, Orientation orientation)
        {
            
            switch (orientation)
            {
                case Orientation.East:
                    location.x = location.x + amount;
                    break;
                case Orientation.South:
                    location.y = location.y - amount;
                    break;
                case Orientation.West:
                    location.x = location.x - amount;
                    break;
                case Orientation.North:
                    location.y = location.y + amount;
                    break;
            }


            return location;
        }

        public Location ProcesRotation(Location location, Rotate rotate, int amount)
        {
            var steps = (amount % 360) / 90;
            if (rotate == Rotate.Left)
            {
                location.orientation = ((int)location.orientation - steps) < 0 ? (Orientation)((int)location.orientation - steps + 4) : (Orientation)((int)location.orientation - steps);
            } else if (rotate == Rotate.Right)
            {
                location.orientation = ((int)location.orientation + steps) > 3 ? (Orientation)((int)location.orientation + steps - 4) : (Orientation)((int)location.orientation + steps);
            }

            return location;

        }


        public struct Location
        {
            public int x;
            public int y;
            public Orientation orientation;
        }

        public enum Orientation
        {
            East = 0,
            South = 1,
            West = 2,
            North = 3
        }

        public enum Rotate
        {
            Left,
            Right
        }

    }

}

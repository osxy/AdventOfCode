using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{

    public class Day11 : IDays
    {

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
            var input = Helpers.General.GetDataFromInputFileAsString(inputFile);





            return 0;
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsString(inputFile);
            List<SeatInfo> seatInfo = new List<SeatInfo>();
            int seatsOccupied = 0;
            bool layoutChanged = true;
            seatInfo = ReadSeatLayout(input);


            while (layoutChanged == true)
            {
                (seatInfo, layoutChanged) = UpdateSeatLayout(seatInfo);

            }

            seatsOccupied = seatInfo.Count(seat => seat.State == SeatInfo.SeatState.occupied);


            return seatsOccupied;


        }

        public (List<SeatInfo>, bool) UpdateSeatLayout(List<SeatInfo> seatInfo)
        {
            List<SeatInfo> newSeatInfo = new List<SeatInfo>();
            SeatInfo newSeat = new SeatInfo();


            int xMin = 0;
            int xMax = 0;
            int yMin = 0;
            int yMax = 0;
            int nrOfSeatsAdjacentOccupied = 0;
            bool layoutChanged = false;

            foreach (SeatInfo seat in seatInfo)
            {
                newSeat.X = seat.X;
                newSeat.Y = seat.Y;
                newSeat.State = seat.State;

                if (seat.State > 0)
                {
                    xMin = seat.X - 1;
                    xMax = seat.X + 1;
                    yMin = seat.Y - 1;
                    yMax = seat.Y + 1;

                    nrOfSeatsAdjacentOccupied = seatInfo.Count(s => s.X <= xMax && s.X >= xMin && s.Y <= yMax && s.Y >= yMin && s.State == SeatInfo.SeatState.occupied);

                    //If seat is empty and No occupied seats adjacent to it ==> Seat becomes occupied
                    if (seat.State == SeatInfo.SeatState.empty && nrOfSeatsAdjacentOccupied == 0)
                    {
                        layoutChanged = true;
                        newSeat.State = SeatInfo.SeatState.occupied;
                    }

                    //If seat is occupied  and 4 or more seats adjacent to it are occupied ==> Seat becomes empty
                    if (seat.State == SeatInfo.SeatState.occupied && nrOfSeatsAdjacentOccupied > 4) //Included this seat so no >=
                    {
                        layoutChanged = true;
                        newSeat.State = SeatInfo.SeatState.empty;
                    }
                }
                newSeatInfo.Add(newSeat);
            }

            return (newSeatInfo, layoutChanged);
        }

        public List<SeatInfo> ReadSeatLayout(string input)
        {
            List<SeatInfo> seatInfo = new List<SeatInfo>();
            int x = 0;
            int y = 0;
            SeatInfo.SeatState state;
            SeatInfo oneSeat = new SeatInfo();

            //Convert input to array of integers.
            string[] lines = input.Split(Environment.NewLine);

            foreach (string line in lines)
            {
                x = 0;
                foreach (char seat in line)
                {
                    switch (seat)
                    {
                        case '.':
                            state = SeatInfo.SeatState.floor;
                            break;

                        case 'L':
                            state = SeatInfo.SeatState.empty;
                            break;
                        case '#':
                            state = SeatInfo.SeatState.occupied;
                            break;

                        default:
                            state = SeatInfo.SeatState.unknown;
                            break;
                    }

                    oneSeat.X = x;
                    oneSeat.Y = y;
                    oneSeat.State = state;

                    seatInfo.Add(oneSeat);

                    x++;
                }

                y++;
                // break;
            }
            return seatInfo;

        }

        public struct SeatInfo
        {
            public int X;
            public int Y;
            public SeatState State; 

            public enum SeatState
            {
                floor,
                empty,
                occupied,
                unknown = 999
            }
        }



    }
}

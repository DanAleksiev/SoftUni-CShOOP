﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
    {
    public class Race : IRace
        {
        private string raceName;
        private int numberOfLaps;
        private readonly List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
            {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;

            pilots = new List<IPilot>();
            }

        public string RaceName
            {
            get => raceName;
            private set
                {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                    }
                raceName = value;
                }
            }

        public int NumberOfLaps
            {
            get => numberOfLaps;
            private set
                {
                if (value < 1)
                    {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                    }
                numberOfLaps = value;
                }
            }

        public ICollection<IPilot> Pilots => pilots;
        public bool tookPlace
            {
            get;
            set;
            }

        public void AddPilot(IPilot pilot)
            {
            pilots.Add(pilot);
            }

        public string RaceInfo()
            {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {raceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {numberOfLaps}");
            string yesNo;
            if (tookPlace)
                {
                yesNo = "Yes";
                }
            else
                {
                yesNo = "No";
                }
            sb.AppendLine($"Took place: {yesNo}");

            return sb.ToString().Trim();
            }
        }
    }

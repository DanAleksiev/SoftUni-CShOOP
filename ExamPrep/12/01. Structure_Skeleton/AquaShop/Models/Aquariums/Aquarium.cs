﻿using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AquaShop.Models.Aquariums
    {
    public abstract class Aquarium : IAquarium
        {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishes;

        protected Aquarium(string name, int capacity)
            {
            Name = name;
            Capacity = capacity;

            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
            }

        public string Name
            {
            get => name;
            private set
                {
                if (string.IsNullOrWhiteSpace(value))
                    {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                    }
                name = value;
                }
            }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fishes;

        public void AddFish(IFish fish)
            {
            fishes.Add(fish);
            }

        public bool RemoveFish(IFish fish) => fishes.Remove(fish);

        public void AddDecoration(IDecoration decoration)
            {
            decorations.Add(decoration);
            }

        public void Feed()
            {
            foreach (var fish in fishes)
                {
                fish.Eat();
                }
            }

        public string GetInfo()
            {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{name} ({GetType().Name}):");
            sb.Append($"Fish: ");
            List<string> names = new List<string>();
            foreach (var fish in fishes)
                {
                names.Add(fish.Name);
                }
            if (fishes.Count > 0)
                {
                sb.AppendLine(string.Join(", ", names));
                }
            else
                {
                sb.AppendLine("none");
                }

            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().Trim();
            }
        }
    }

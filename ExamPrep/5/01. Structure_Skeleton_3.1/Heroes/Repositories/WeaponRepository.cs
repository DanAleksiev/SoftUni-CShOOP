﻿using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
    {
    public class WeaponRepository : IRepository<IWeapon>
        {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
            {
            this.weapons = new List<IWeapon>();
            }

        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void Add(IWeapon model)
            {
            weapons.Add(model);
            }

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(x => x.Name == name);

        public bool Remove(IWeapon model) => this.weapons.Remove(model);
        }
    }

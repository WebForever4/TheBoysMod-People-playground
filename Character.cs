using System;
using System.Collections.Generic;

namespace TheBoysMod
{
    /// <summary>
    /// Base character class for The Boys mod
    /// </summary>
    public abstract class Character
    {
        public string Name { get; set; }
        public string CharacterType { get; set; }
        public float Health { get; set; }
        public float MaxHealth { get; set; }
        public float Speed { get; set; }
        public float Strength { get; set; }
        public string SpriteKey { get; set; }
        public List<Ability> Abilities { get; set; }

        protected Character(string name, string characterType, float maxHealth, float speed, float strength, string spriteKey)
        {
            Name = name;
            CharacterType = characterType;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Speed = speed;
            Strength = strength;
            SpriteKey = spriteKey;
            Abilities = new List<Ability>();
        }

        public virtual void AddAbility(Ability ability)
        {
            Abilities.Add(ability);
        }

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public virtual void Heal(float amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
        }

        public virtual bool IsAlive()
        {
            return Health > 0;
        }

        public abstract void UseSpecialAbility();
    }
}

using System;

namespace TheBoysMod
{
    /// <summary>
    /// Represents a special ability for characters
    /// </summary>
    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Cooldown { get; set; }
        public float CurrentCooldown { get; set; }
        public float ManaCost { get; set; }
        public float Damage { get; set; }

        public Ability(string name, string description, float cooldown, float manaCost, float damage)
        {
            Name = name;
            Description = description;
            Cooldown = cooldown;
            CurrentCooldown = 0;
            ManaCost = manaCost;
            Damage = damage;
        }

        public bool IsReady()
        {
            return CurrentCooldown <= 0;
        }

        public void Use()
        {
            CurrentCooldown = Cooldown;
        }

        public void Update(float deltaTime)
        {
            if (CurrentCooldown > 0)
            {
                CurrentCooldown -= deltaTime;
            }
        }
    }
}

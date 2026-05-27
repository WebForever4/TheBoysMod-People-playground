using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheBoysMod
{
    /// <summary>
    /// Combat system for handling ability usage and damage
    /// </summary>
    public class CombatSystem
    {
        private static CombatSystem instance;
        public static CombatSystem Instance => instance ?? (instance = new CombatSystem());

        private List<DamageEvent> pendingDamage = new List<DamageEvent>();

        public class DamageEvent
        {
            public Character Attacker { get; set; }
            public Character Defender { get; set; }
            public Ability Ability { get; set; }
            public float Damage { get; set; }
            public float Timestamp { get; set; }
        }

        /// <summary>
        /// Initialize the combat system
        /// </summary>
        public void Initialize()
        {
            Console.WriteLine("[CombatSystem] Combat system initialized");
        }

        /// <summary>
        /// Use an ability against a target
        /// </summary>
        public bool UseAbility(Character attacker, Character target, Ability ability)
        {
            if (ability == null || target == null)
                return false;

            if (!ability.IsReady())
            {
                Console.WriteLine($"[CombatSystem] {ability.Name} is on cooldown");
                return false;
            }

            try
            {
                ability.Use();
                
                float actualDamage = CalculateDamage(attacker, target, ability);
                target.TakeDamage(actualDamage);

                var damageEvent = new DamageEvent
                {
                    Attacker = attacker,
                    Defender = target,
                    Ability = ability,
                    Damage = actualDamage,
                    Timestamp = Time.time
                };
                
                pendingDamage.Add(damageEvent);

                Console.WriteLine($"[CombatSystem] {attacker.Name} used {ability.Name} on {target.Name} for {actualDamage} damage");
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CombatSystem] Error using ability: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Calculate actual damage based on stats
        /// </summary>
        private float CalculateDamage(Character attacker, Character target, Ability ability)
        {
            float baseDamage = ability.Damage;
            float strengthModifier = attacker.Strength / 100f;
            float defenseModifier = 1f - (target.Strength / 200f);
            
            float finalDamage = baseDamage * strengthModifier * defenseModifier;
            return Mathf.Max(1f, finalDamage);
        }

        /// <summary>
        /// Process AOE damage in an area
        /// </summary>
        public void DamageArea(Character attacker, Vector2 center, float radius, Ability ability)
        {
            Console.WriteLine($"[CombatSystem] AOE damage from {attacker.Name} at {center} with radius {radius}");
        }

        /// <summary>
        /// Get damage history
        /// </summary>
        public List<DamageEvent> GetDamageHistory()
        {
            return new List<DamageEvent>(pendingDamage);
        }

        /// <summary>
        /// Clear old damage events
        /// </summary>
        public void ClearOldEvents(float maxAge = 30f)
        {
            float currentTime = Time.time;
            pendingDamage.RemoveAll(e => currentTime - e.Timestamp > maxAge);
        }
    }
}

namespace TheBoysMod.Characters
{
    /// <summary>
    /// The Deep - Aquatic supe with gills and marine creature control
    /// </summary>
    public class TheDeep : Character
    {
        public TheDeep() : base(
            name: "The Deep",
            characterType: "Supe",
            maxHealth: 120f,
            speed: 6.5f,
            strength: 70f,
            spriteKey: "thedeep_sprite"
        )
        {
            InitializeAbilities();
        }

        private void InitializeAbilities()
        {
            // Summon sea creatures
            AddAbility(new Ability(
                name: "Summon Sea Creature",
                description: "Call a sea creature to attack enemies",
                cooldown: 3f,
                manaCost: 35f,
                damage: 40f
            ));

            // Aquatic adaptation - increased speed in water
            AddAbility(new Ability(
                name: "Aquatic Dash",
                description: "Dash through water with incredible speed",
                cooldown: 2f,
                manaCost: 20f,
                damage: 20f
            ));

            // Water manipulation
            AddAbility(new Ability(
                name: "Water Jet",
                description: "Launch pressurized water at enemies",
                cooldown: 1.5f,
                manaCost: 18f,
                damage: 28f
            ));
        }

        public override void UseSpecialAbility()
        {
            if (Abilities.Count > 0 && Abilities[0].IsReady())
            {
                Abilities[0].Use();
                // Sea creature summon logic would go here
            }
        }
    }
}

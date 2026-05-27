namespace TheBoysMod.Characters
{
    /// <summary>
    /// Homelander - The main antagonist with laser vision and flight
    /// </summary>
    public class Homelander : Character
    {
        public Homelander() : base(
            name: "Homelander",
            characterType: "Supe",
            maxHealth: 150f,
            speed: 8f,
            strength: 95f,
            spriteKey: "homelander_sprite"
        )
        {
            InitializeAbilities();
        }

        private void InitializeAbilities()
        {
            // Laser Vision - his signature ability
            AddAbility(new Ability(
                name: "Laser Vision",
                description: "Shoots powerful red laser beams from eyes",
                cooldown: 2f,
                manaCost: 30f,
                damage: 45f
            ));

            // Super Strength punch
            AddAbility(new Ability(
                name: "Super Punch",
                description: "Delivers a devastating punch with superhuman strength",
                cooldown: 1.5f,
                manaCost: 15f,
                damage: 35f
            ));

            // Flight ability
            AddAbility(new Ability(
                name: "Flight",
                description: "Takes to the air at high speed",
                cooldown: 0.5f,
                manaCost: 10f,
                damage: 0f
            ));
        }

        public override void UseSpecialAbility()
        {
            if (Abilities.Count > 0 && Abilities[0].IsReady())
            {
                Abilities[0].Use();
                // Laser vision damage logic would go here
            }
        }
    }
}

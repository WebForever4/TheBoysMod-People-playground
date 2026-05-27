namespace TheBoysMod.Characters
{
    /// <summary>
    /// A-Train - Super-speed supe with velocity-based attacks
    /// </summary>
    public class ATrain : Character
    {
        public ATrain() : base(
            name: "A-Train",
            characterType: "Supe",
            maxHealth: 110f,
            speed: 10f,
            strength: 75f,
            spriteKey: "atrain_sprite"
        )
        {
            InitializeAbilities();
        }

        private void InitializeAbilities()
        {
            // Super speed dash
            AddAbility(new Ability(
                name: "Speedster Dash",
                description: "Dash at extreme speed, hitting all enemies in the path",
                cooldown: 1.5f,
                manaCost: 25f,
                damage: 38f
            ));

            // Velocity punch - stronger the faster you move
            AddAbility(new Ability(
                name: "Velocity Punch",
                description: "Build up speed and deliver a devastating punch",
                cooldown: 2f,
                manaCost: 20f,
                damage: 42f
            ));

            // Speed boost
            AddAbility(new Ability(
                name: "Adrenaline Rush",
                description: "Temporarily increase movement and attack speed",
                cooldown: 3f,
                manaCost: 15f,
                damage: 0f
            ));
        }

        public override void UseSpecialAbility()
        {
            if (Abilities.Count > 0 && Abilities[0].IsReady())
            {
                Abilities[0].Use();
                // Speedster dash logic would go here
            }
        }
    }
}

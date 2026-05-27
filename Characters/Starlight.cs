namespace TheBoysMod.Characters
{
    /// <summary>
    /// Starlight - Telekinetic supe with light manipulation
    /// </summary>
    public class Starlight : Character
    {
        public Starlight() : base(
            name: "Starlight",
            characterType: "Supe",
            maxHealth: 100f,
            speed: 7.5f,
            strength: 60f,
            spriteKey: "starlight_sprite"
        )
        {
            InitializeAbilities();
        }

        private void InitializeAbilities()
        {
            // Telekinetic push
            AddAbility(new Ability(
                name: "Telekinetic Push",
                description: "Push enemies back with telekinetic force",
                cooldown: 1.5f,
                manaCost: 25f,
                damage: 30f
            ));

            // Light burst
            AddAbility(new Ability(
                name: "Light Burst",
                description: "Release a burst of blinding light energy",
                cooldown: 2f,
                manaCost: 20f,
                damage: 25f
            ));

            // Enhanced reflexes
            AddAbility(new Ability(
                name: "Enhanced Reflexes",
                description: "Temporarily boost movement and dodge speed",
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
                // Telekinetic push logic would go here
            }
        }
    }
}

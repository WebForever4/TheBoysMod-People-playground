# The Boys Mod - People Playground

A mod for People Playground featuring characters from The Boys comic and TV series.

## Characters

### Homelander
- **Health**: 150
- **Speed**: 8
- **Strength**: 95
- **Abilities**:
  - Laser Vision (45 damage)
  - Super Punch (35 damage)
  - Flight

### Starlight
- **Health**: 100
- **Speed**: 7.5
- **Strength**: 60
- **Abilities**:
  - Telekinetic Push (30 damage)
  - Light Burst (25 damage)
  - Enhanced Reflexes

### The Deep
- **Health**: 120
- **Speed**: 6.5
- **Strength**: 70
- **Abilities**:
  - Summon Sea Creature (40 damage)
  - Aquatic Dash (20 damage)
  - Water Jet (28 damage)

### A-Train
- **Health**: 110
- **Speed**: 10
- **Strength**: 75
- **Abilities**:
  - Speedster Dash (38 damage)
  - Velocity Punch (42 damage)
  - Adrenaline Rush

## Project Structure

```
TheBoysMod-People-playground/
├── Character.cs           # Base character class
├── Ability.cs            # Ability system
├── SpriteManager.cs      # Sprite management
├── CharacterFactory.cs   # Character creation
├── Characters/
│   ├── Homelander.cs
│   ├── Starlight.cs
│   ├── TheDeep.cs
│   └── ATrain.cs
└── README.md
```

## Sprite Setup

Place your sprite files in the following directory structure:
```
Assets/
└── Sprites/
    ├── Homelander/
    ├── Starlight/
    ├── TheDeep/
    └── ATrain/
```

Update the sprite paths in `SpriteManager.cs` if your directory structure differs.

## Usage

```csharp
// Create a character
Character homelander = CharacterFactory.CreateCharacter(CharacterFactory.CharacterType.Homelander);

// Use abilities
homelander.UseSpecialAbility();

// Manage health
homelander.TakeDamage(20);
homelander.Heal(10);

// Check status
if (homelander.IsAlive())
{
    Console.WriteLine($"{homelander.Name} has {homelander.Health} HP");
}
```

## Next Steps

- [ ] Implement People Playground mod integration
- [ ] Add sprite animation system
- [ ] Create character selection UI
- [ ] Implement combat system
- [ ] Add more characters (Butcher, Queen Maeve, Kimiko, etc.)
- [ ] Add special power interactions

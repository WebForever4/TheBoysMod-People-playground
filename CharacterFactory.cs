using System;
using TheBoysMod.Characters;

namespace TheBoysMod
{
    /// <summary>
    /// Factory for creating character instances
    /// </summary>
    public static class CharacterFactory
    {
        public enum CharacterType
        {
            Homelander,
            Starlight,
            TheDeep,
            ATrain
        }

        /// <summary>
        /// Create a character instance by type
        /// </summary>
        public static Character CreateCharacter(CharacterType type)
        {
            return type switch
            {
                CharacterType.Homelander => new Homelander(),
                CharacterType.Starlight => new Starlight(),
                CharacterType.TheDeep => new TheDeep(),
                CharacterType.ATrain => new ATrain(),
                _ => throw new ArgumentException($"Unknown character type: {type}")
            };
        }

        /// <summary>
        /// Create a character instance by name string
        /// </summary>
        public static Character CreateCharacterByName(string name)
        {
            return name.ToLower() switch
            {
                "homelander" => new Homelander(),
                "starlight" => new Starlight(),
                "thedeep" => new TheDeep(),
                "atrain" => new ATrain(),
                _ => throw new ArgumentException($"Unknown character name: {name}")
            };
        }

        /// <summary>
        /// Get all available characters
        /// </summary>
        public static string[] GetAvailableCharacters()
        {
            return new string[]
            {
                "Homelander",
                "Starlight",
                "The Deep",
                "A-Train"
            };
        }
    }
}

using System;
using System.Collections.Generic;

namespace TheBoysMod
{
    /// <summary>
    /// Main mod loader and initializer for People Playground integration
    /// </summary>
    public class ModLoader
    {
        private static ModLoader instance;
        public static ModLoader Instance => instance ?? (instance = new ModLoader());

        private Dictionary<string, Character> activeCharacters = new Dictionary<string, Character>();
        private bool isInitialized = false;

        /// <summary>
        /// Initialize the mod with People Playground
        /// </summary>
        public void Initialize()
        {
            if (isInitialized)
                return;

            try
            {
                Console.WriteLine("[TheBoysMod] Initializing The Boys Mod for People Playground...");
                
                // Register character types
                RegisterCharacterTypes();
                
                // Load sprite assets
                LoadSpriteAssets();
                
                // Initialize combat system
                CombatSystem.Instance.Initialize();
                
                Console.WriteLine("[TheBoysMod] Mod initialized successfully!");
                isInitialized = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TheBoysMod] Initialization failed: {ex.Message}");
                isInitialized = false;
            }
        }

        /// <summary>
        /// Register all character types
        /// </summary>
        private void RegisterCharacterTypes()
        {
            Console.WriteLine("[TheBoysMod] Registering character types...");
            var characters = CharacterFactory.GetAvailableCharacters();
            foreach (var charName in characters)
            {
                Console.WriteLine($"  - Registered: {charName}");
            }
        }

        /// <summary>
        /// Load all sprite assets
        /// </summary>
        private void LoadSpriteAssets()
        {
            Console.WriteLine("[TheBoysMod] Loading sprite assets...");
            var spritePaths = SpriteManager.SpritePaths;
            foreach (var sprite in spritePaths)
            {
                SpriteManager.LoadSprite(sprite.Key);
                Console.WriteLine($"  - Loaded sprite: {sprite.Key}");
            }
        }

        /// <summary>
        /// Spawn a character at a specific position
        /// </summary>
        public Character SpawnCharacter(string characterName, float x, float y)
        {
            try
            {
                Character character = CharacterFactory.CreateCharacterByName(characterName);
                activeCharacters[characterName + "_" + Guid.NewGuid()] = character;
                
                Console.WriteLine($"[TheBoysMod] Spawned {characterName} at ({x}, {y})");
                return character;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TheBoysMod] Failed to spawn character: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get all active characters
        /// </summary>
        public Dictionary<string, Character> GetActiveCharacters()
        {
            return new Dictionary<string, Character>(activeCharacters);
        }

        /// <summary>
        /// Update all active characters
        /// </summary>
        public void Update(float deltaTime)
        {
            foreach (var character in activeCharacters.Values)
            {
                foreach (var ability in character.Abilities)
                {
                    ability.Update(deltaTime);
                }
            }
        }

        /// <summary>
        /// Shutdown the mod
        /// </summary>
        public void Shutdown()
        {
            Console.WriteLine("[TheBoysMod] Shutting down mod...");
            activeCharacters.Clear();
            SpriteManager.ClearCache();
            isInitialized = false;
            Console.WriteLine("[TheBoysMod] Mod shutdown complete");
        }
    }
}

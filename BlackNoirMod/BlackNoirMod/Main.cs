using System.Collections.Generic;
using UnityEngine;
using ZeroOne.Union.Durability;

namespace BlackNoir
{
    public class Mod
    {
        public static void OnLoad() { }

        public static void Main()
        {
            ModAPI.Register(new Modification()
            {
                OriginalItem      = ModAPI.FindSpawnable("Human"),
                NameOverride      = "Black Noir",
                DescriptionOverride = "The silent assassin of Vought. F on his head to toggle the mask.",
                CategoryOverride  = ModAPI.FindCategory("Entities"),
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Thumb.png"),
                AfterSpawn = (Instance) =>
                {
                    var person = Instance.GetComponent<PersonBehaviour>();

                    // Apply sprites with exact confirmed limb names
                    var spriteMap = new Dictionary<string, string>
                    {
                        { "Head",          "Sprites/HeadMasked.png" },
                        { "UpperBody",     "Sprites/UpperBody.png"  },
                        { "MiddleBody",    "Sprites/MiddleBody.png" },
                        { "LowerBody",     "Sprites/LowerBody.png"  },
                        { "UpperArmFront", "Sprites/UpperArm.png"   },
                        { "LowerArmFront", "Sprites/LowerArm.png"   },
                        { "UpperArm",      "Sprites/UpperArm.png"   },
                        { "LowerArm",      "Sprites/LowerArm.png"   },
                        { "UpperLegFront", "Sprites/UpperLeg.png"   },
                        { "LowerLegFront", "Sprites/LowerLeg.png"   },
                        { "FootFront",     "Sprites/Foot.png"       },
                        { "UpperLeg",      "Sprites/UpperLeg.png"   },
                        { "LowerLeg",      "Sprites/LowerLeg.png"   },
                        { "Foot",          "Sprites/Foot.png"       },
                    };

                    // Flesh/bone textures per limb matched to sprite size
                    var fleshMap = new Dictionary<string, string>
                    {
                        { "Head",          "Sprites/HeadSpriteFlesh.png"       },
                        { "UpperBody",     "Sprites/UpperBodySpriteFlesh.png"   },
                        { "UpperArmFront", "Sprites/UpperArmSpriteFlesh.png"    },
                        { "LowerArmFront", "Sprites/LowerArmSpriteFlesh.png"    },
                        { "UpperArm",      "Sprites/UpperArmSpriteFlesh.png"    },
                        { "LowerArm",      "Sprites/LowerArmSpriteFlesh.png"    },
                        { "UpperLegFront", "Sprites/UpperLegSpriteFlesh.png"    },
                        { "LowerLegFront", "Sprites/LowerLegSpriteFlesh.png"    },
                        { "FootFront",     "Sprites/FootSpriteFlesh.png"        },
                        { "UpperLeg",      "Sprites/UpperLegSpriteFlesh.png"    },
                        { "LowerLeg",      "Sprites/LowerLegSpriteFlesh.png"    },
                        { "Foot",          "Sprites/FootSpriteFlesh.png"        },
                        { "MiddleBody",    "Sprites/MiddleBodySpriteFlesh.png"  },
                        { "LowerBody",     "Sprites/LowerBodySpriteFlesh.png"   },
                    };

                    var boneMap = new Dictionary<string, string>
                    {
                        { "Head",          "Sprites/HeadSpriteBone.png"         },
                        { "UpperBody",     "Sprites/UpperBodySpriteBone.png"     },
                        { "UpperArmFront", "Sprites/UpperArmSpriteBone.png"      },
                        { "LowerArmFront", "Sprites/LowerArmSpriteBone.png"      },
                        { "UpperArm",      "Sprites/UpperArmSpriteBone.png"      },
                        { "LowerArm",      "Sprites/LowerArmSpriteBone.png"      },
                        { "UpperLegFront", "Sprites/UpperLegSpriteBone.png"      },
                        { "LowerLegFront", "Sprites/LowerLegSpriteBone.png"      },
                        { "FootFront",     "Sprites/FootSpriteBone.png"          },
                        { "UpperLeg",      "Sprites/UpperLegSpriteBone.png"      },
                        { "LowerLeg",      "Sprites/LowerLegSpriteBone.png"      },
                        { "Foot",          "Sprites/FootSpriteBone.png"          },
                        { "MiddleBody",    "Sprites/MiddleBodySpriteBone.png"    },
                        { "LowerBody",     "Sprites/LowerBodySpriteBone.png"     },
                    };

                    var headRenderers = new List<SpriteRenderer>();
                    var renderers = Instance.GetComponentsInChildren<SpriteRenderer>(true);

                    foreach (var sr in renderers)
                    {
                        string name = sr.gameObject.name;

                        // Apply skin sprite
                        if (spriteMap.ContainsKey(name))
                        {
                            var sprite = ModAPI.LoadSprite(spriteMap[name]);
                            if (sprite != null) sr.sprite = sprite;
                        }

                        // Apply flesh/bone directly to material shader properties
                        if (fleshMap.ContainsKey(name) && boneMap.ContainsKey(name))
                        {
                            var mat = sr.material;
                            if (mat != null)
                            {
                                var flesh = ModAPI.LoadTexture(fleshMap[name]);
                                var bone  = ModAPI.LoadTexture(boneMap[name]);
                                // Try common shader property names PP uses
                                if (flesh != null)
                                {
                                    mat.SetTexture("_FleshTex", flesh);
                                    mat.SetTexture("_Flesh",    flesh);
                                    mat.SetTexture("_MeatTex",  flesh);
                                }
                                if (bone != null)
                                {
                                    mat.SetTexture("_BoneTex",  bone);
                                    mat.SetTexture("_Bone",     bone);
                                }
                            }
                        }

                        if (name == "Head")
                            headRenderers.Add(sr);
                    }

                    // Durability
                    var dur = Instance.AddComponent<DurabilityControllerBehaviour>();
                    dur.personBehaviour = person;
                    var s = dur.Settings;
                    s.Health.BaseValue            = 10f;
                    s.Shot.BaseValue              = 0.01f;
                    s.Collision.BaseValue         = 0.01f;
                    s.Damage.BaseValue            = 0.01f;
                    s.Stab.BaseValue              = 0.02f;
                    s.Explosion.BaseValue         = 0.05f;
                    s.BreakingThreshold.BaseValue = 10f;
                    s.Strength.BaseValue          = 5f;
                    s.BloodRegen.BaseValue        = 10f;
                    s.BleedingRegen.BaseValue     = 10f;
                    s.Bleed.BaseValue             = false;
                    s.IgnoreBullets.BaseValue     = true;
                    s.IgnoreEMP.BaseValue         = true;
                    s.IgnoreSlice.BaseValue       = true;
                    s.IgnoreCrush.BaseValue       = true;
                    dur.UpdateParams();

                    // Mask toggle
                    var toggle = Instance.AddComponent<MaskToggle>();
                    toggle.person         = person;
                    toggle.maskedSprite   = ModAPI.LoadSprite("Sprites/HeadMasked.png");
                    toggle.unmaskedSprite = ModAPI.LoadSprite("Sprites/HeadUnmasked.png");
                    toggle.headRenderers  = headRenderers;
                }
            });
        }

        public static void OnUnload() { }
    }

    public class MaskToggle : MonoBehaviour
    {
        public PersonBehaviour       person;
        public Sprite                maskedSprite;
        public Sprite                unmaskedSprite;
        public List<SpriteRenderer>  headRenderers = new List<SpriteRenderer>();

        bool _masked   = true;
        bool _cooldown = false;

        void Update()
        {
            if (!Input.GetKeyDown(KeyCode.F) || _cooldown || person == null) return;
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (var limb in person.Limbs)
            {
                if (limb.RoughClassification != LimbBehaviour.BodyPart.Head) continue;
                var col = limb.GetComponent<Collider2D>();
                if (col != null && col.OverlapPoint(mouse))
                {
                    Toggle();
                    return;
                }
            }
        }

        void Toggle()
        {
            _masked = !_masked;
            foreach (var sr in headRenderers)
                if (sr != null)
                    sr.sprite = _masked ? maskedSprite : unmaskedSprite;
            _cooldown = true;
            Invoke("ResetCooldown", 0.4f);
        }

        void ResetCooldown() { _cooldown = false; }
    }
}

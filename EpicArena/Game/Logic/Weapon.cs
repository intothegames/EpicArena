using EpicArena.Game.Constants;

namespace EpicArena.Game.Logic 
{
    public enum WeaponType
    {
        Chopping,   // Рубящий
        Crushing,   // Дробящий
        Stabbing,   // Колющий
        Usual       // Оружие врагов
    }

    public abstract class Weapon : ILootable
    {
        public WeaponType TypeOfWeapon { get; protected set; }
        public int Damage { get; protected set; }
    }

    // Hero
    class Sword : Weapon
    {
        public Sword()
        {
            TypeOfWeapon = Values.SWORD_TYPE;
            Damage = Values.SWORD_DAMAGE;
        }
    }

    class Club : Weapon
    {
        public Club()
        {
            TypeOfWeapon = Values.CLUB_TYPE;
            Damage = Values.CLUB_DAMAGE;
        }
    }

    class Dagger : Weapon
    {
        public Dagger()
        {
            TypeOfWeapon = Values.DAGGER_TYPE;
            Damage = Values.DAGGER_DAMAGE;
        }
    }

    class Axe : Weapon
    {
        public Axe()
        {
            TypeOfWeapon = Values.AXE_TYPE;
            Damage = Values.AXE_DAMAGE;
        }
    }

    class Spear : Weapon
    {
        public Spear()
        {
            TypeOfWeapon = Values.SPEAR_TYPE;
            Damage = Values.SPEAR_DAMAGE;
        }
    }

    class LegendarySword : Weapon
    {
        public LegendarySword()
        {
            TypeOfWeapon = Values.LEGENDARYSWORD_TYPE;
            Damage = Values.LEGENDARYSWORD_DAMAGE;
        }
    }


    // Enemy
    class GoblinClaw : Weapon
    {
        public GoblinClaw()
        {
            TypeOfWeapon = Values.GOBLIN_CLAW_TYPE;
            Damage = Values.GOBLIN_CLAW_DAMAGE;
        }
    }

    class SkeletonJaw : Weapon
    {
        public SkeletonJaw()
        {
            TypeOfWeapon = Values.SKELETON_JAW_TYPE;
            Damage = Values.SKELETON_JAW_DAMAGE;
        }
    }

    class SlimeTongue : Weapon
    {
        public SlimeTongue()
        {
            TypeOfWeapon = Values.SLIME_TONGUE_TYPE;
            Damage = Values.SLIME_TONGUE_DAMAGE;
        }
    }

    class GhostFinger : Weapon
    {
        public GhostFinger()
        {
            TypeOfWeapon = Values.GHOST_FINDER_TYPE;
            Damage = Values.GHOST_FINDER_DAMAGE;
        }
    }

    class GolemHand : Weapon
    {
        public GolemHand()
        {
            TypeOfWeapon = Values.GOLEM_HAND_TYPE;
            Damage = Values.GOLEM_HAND_DAMAGE;
        }
    }

    class DragonPaw : Weapon
    {
        public DragonPaw()
        {
            TypeOfWeapon = Values.DRAGON_PAW_TYPE;
            Damage = Values.DRAGON_PAW_DAMAGE;
        }
    }
}
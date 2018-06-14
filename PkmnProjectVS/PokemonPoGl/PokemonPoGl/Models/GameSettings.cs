using System.Windows;
using System.Windows.Media;

namespace PokemonPoGl
{
    public class GameSettings
    {
        public static string ChoosenPokemon { get; set; }
        public static bool Hardmode { get; set; }
        public static bool Dodged { get; set; }
        public static bool CriticalHit { get; set; }
        public static Pokemon Groudon = new Pokemon(Types.Fire, nameof(Groudon), new Thickness(-39, -106, 426, -233), new Thickness(485, 10, 17, 361));
        public static Pokemon PlayerPokemon { get; set; }
        public static Pokemon EnemyPokemon { get; set; }
        public static Pokemon AttackingPokemon { get; set; }
        public static Pokemon DefendingPokemon { get; set; }
        public static Attack UsedAttack { get; set; }
        public static Brush Color { get; set; }
        public static string Effectiveness { get; set; }
        public const int MaxHealth = 1000;

        public const double DamageOfDodgedAttack = 50;
        public const double CriticalHitAttackFactor = 2;

        public const double VeryEffectiveAttackFactor = 1.75;
        public const double NotEffectiveAttackFactor = 0.5;

        public const double VeryEffectiveAttackFactorOfEnemyPokemon = 1.25;
        public const double NotEffectiveAttackFactorOfEnemyPokemon = 0.4;

    }
}
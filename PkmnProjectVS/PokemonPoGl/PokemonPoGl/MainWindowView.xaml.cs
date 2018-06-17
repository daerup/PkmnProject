using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using smoothBar;
using WpfAnimatedGif;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace PokemonPoGl
{
    /// <summary>
    ///     Interaktionslogik für MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView
    {
        private readonly Random random = new Random();

        private readonly List<Pokemon> allPokemon;

        private readonly SoundPlayer battleMusic = new SoundPlayer(@"../../res/music/battleMusic.wav");

        private readonly List<Attack> fireAttacks;
        readonly List<Attack> waterAttacks;
        private readonly List<Attack> plantAttacks;
        private readonly List<Attack> normalAttacks;

        public Pokemon Groudon;



            
        public MainWindowView()
        {
            this.InitializeComponent();

            string jsonFolderPath = @"../../res/json";


            this.allPokemon = JsonSerialization.ReadFromJsonFile<List<Pokemon>>($"{jsonFolderPath}/Pokemon.json");
            this.fireAttacks = JsonSerialization.ReadFromJsonFile<List<Attack>>($"{jsonFolderPath}/fire.json");
            this.waterAttacks = JsonSerialization.ReadFromJsonFile<List<Attack>>($"{jsonFolderPath}/water.json");
            this.plantAttacks = JsonSerialization.ReadFromJsonFile<List<Attack>>($"{jsonFolderPath}/plant.json");
            this.normalAttacks = JsonSerialization.ReadFromJsonFile<List<Attack>>($"{jsonFolderPath}/normal.json");

            this.Groudon = GameSettings.Groudon;
            GameSettings.Won = false;
            this.battleMusic.PlayLooping();

            if (GameSettings.ChoosenPokemon != "Groudon")
                GameSettings.PlayerPokemon = this.allPokemon.Find(pokemon => pokemon.Name == GameSettings.ChoosenPokemon);
            else
                GameSettings.PlayerPokemon = this.Groudon;

            this.AssignAttacks();
            this.PrepareUi();
            this.DelcareEnemyPokemon();
            this.ShowPokemon();
        }

        private void AssignAttacks()
        {
            int randomInt;
            foreach (Pokemon pokemon in this.allPokemon)
            {
                switch (pokemon.Type)
                {
                    case Types.Fire:
                        randomInt = this.random.Next(0, this.fireAttacks.Count - 1);
                        pokemon.StabAttack = this.fireAttacks[randomInt];
                        this.fireAttacks.RemoveAt(randomInt);
                        break;
                    case Types.Water:
                        randomInt = this.random.Next(0, this.waterAttacks.Count - 1);
                        pokemon.StabAttack = this.waterAttacks[randomInt];
                        this.waterAttacks.RemoveAt(randomInt);
                        break;
                    case Types.Plant:
                        randomInt = this.random.Next(0, this.plantAttacks.Count - 1);
                        pokemon.StabAttack = this.plantAttacks[randomInt];
                        this.plantAttacks.RemoveAt(randomInt);
                        break;
                }

                randomInt = this.random.Next(0, this.normalAttacks.Count - 1);
                pokemon.NormalAttack = this.normalAttacks[randomInt];
                this.normalAttacks.RemoveAt(randomInt);
            }

            randomInt = this.random.Next(0, this.normalAttacks.Count - 1);
            this.Groudon.NormalAttack = this.normalAttacks[randomInt];
            this.normalAttacks.RemoveAt(randomInt);
        }

        private void PrepareUi()
        {
            switch (GameSettings.PlayerPokemon.Type)
            {
                case Types.Fire:
                    GameSettings.Color = Brushes.OrangeRed;
                    break;
                case Types.Water:
                    GameSettings.Color = Brushes.CornflowerBlue;
                    break;
                case Types.Plant:
                    GameSettings.Color = Brushes.ForestGreen;
                    break;
            }

            this.Stab.Content = $"_{GameSettings.PlayerPokemon.StabAttack.Name}";
            this.Normal.Content = $"_{GameSettings.PlayerPokemon.NormalAttack.Name}";

            this.Normal.Background = new SolidColorBrush(Color.FromArgb(255, 95, 95, 95));
            this.Stab.Background = GameSettings.Color;
        }

        private void UpdateEnemy()
        {
            this.DelcareEnemyPokemon();
            ImageBehavior.SetAnimatedSource(this.ImgEnemyPokemon, GameSettings.EnemyPokemon.FrontPath);
            this.ImgEnemyPokemon_OnAnimationLoaded(this.ImgEnemyPokemon, null);
            this.EnemyHp.SmoothValue = GameSettings.MaxHealth;
        }

        private double CalculateDamage(Pokemon attackingPokemon, Attack usedAttack)
        {
            double damage;
            this.AnalyseAttack(attackingPokemon);

            if (GameSettings.Dodged)
            {
                damage = GameSettings.DamageOfDodgedAttack;
                return damage;
            }

            if (GameSettings.CriticalHit)
            {
                damage = usedAttack.Strength * GameSettings.CriticalHitAttackFactor;
                return damage;
            }

            damage = this.CalculateDamageWithEffectivenessOfAttack(usedAttack);

            return damage;
        }

        private void AnalyseAttack(Pokemon attackingPokemon)
        {
            this.SetPokemonRoles(attackingPokemon);
            GameSettings.CriticalHit = this.CheckIfAttackIsCritical();
            GameSettings.Dodged = this.CheckIfAttackIsDodged();
        }

        private void SetPokemonRoles(Pokemon attackingPokemon)
        {
            if (attackingPokemon == GameSettings.PlayerPokemon)
            {
                GameSettings.AttackingPokemon = GameSettings.PlayerPokemon;
                GameSettings.DefendingPokemon = GameSettings.EnemyPokemon;
            }
            else
            {
                GameSettings.AttackingPokemon = GameSettings.EnemyPokemon;
                GameSettings.DefendingPokemon = GameSettings.PlayerPokemon;
            }
        }

        private bool CheckIfAttackIsDodged()
        {
            if (this.CheckIfDodgedChanceIsRaised()) return this.CheckIfAttackIsDodgedInHardMode();

            return this.CheckIfAttackIsDodgedInNormalMode();
        }

        private bool CheckIfDodgedChanceIsRaised()
        {
            if (GameSettings.Hardmode && GameSettings.AttackingPokemon == GameSettings.EnemyPokemon) return true;

            return false;
        }

        private bool CheckIfAttackIsDodgedInHardMode()
        {
            if (this.random.Next(0, 7) == 0) return true;

            return false;
        }

        private bool CheckIfAttackIsDodgedInNormalMode()
        {
            if (this.random.Next(0, 11) == 0) return true;

            return false;
        }

        private bool CheckIfAttackIsCritical()
        {
            if (this.CheckIfCriticalHitChanceIsRaised()) return this.CheckIfAttackIsCriticalInHardMode();

            return this.CheckIfAttackIsCriticalInNormalMode();
        }

        private bool CheckIfCriticalHitChanceIsRaised()
        {
            if (GameSettings.Hardmode && GameSettings.AttackingPokemon == GameSettings.EnemyPokemon) return true;

            return false;
        }

        private bool CheckIfAttackIsCriticalInHardMode()
        {
            if (this.random.Next(0, 7) == 0)
            {
                GameSettings.Effectiveness = "a Critical Hit";
                return true;
            }

            return false;
        }

        private bool CheckIfAttackIsCriticalInNormalMode()
        {
            if (this.random.Next(0, 11) == 0)
            {
                GameSettings.Effectiveness = "a Critical Hit";
                return true;
            }

            return false;
        }

        private double CalculateDamageWithEffectivenessOfAttack(Attack usedAttack)
        {
            if (GameSettings.Hardmode) return this.CalculateDamageWithEffectivenessOfAttackInHardMode(usedAttack);
            return this.CalculateDamageWithEffectivenessOfAttackInNormalMode(usedAttack);
        }

        private double CalculateDamageWithEffectivenessOfAttackInHardMode(Attack usedAttack)
        {
            double damage;
            if (this.CheckIfAttackIsVeryEffectrive(usedAttack))
            {
                damage = usedAttack.Strength * GameSettings.VeryEffectiveAttackFactor;
                GameSettings.Effectiveness = "very Effective";
                return damage;
            }

            if (this.CheckIfAttackIsNotEffectrive(usedAttack))
            {
                damage = usedAttack.Strength * GameSettings.NotEffectiveAttackFactor;
                GameSettings.Effectiveness = "not Effective";
                return damage;
            }

            damage = usedAttack.Strength;
            GameSettings.Effectiveness = "Effective";
            return damage;
        }

        private double CalculateDamageWithEffectivenessOfAttackInNormalMode(Attack usedAttack)
        {
            double damage;
            if (this.CheckIfAttackIsVeryEffectrive(usedAttack) &&
                GameSettings.AttackingPokemon == GameSettings.PlayerPokemon)
            {
                damage = usedAttack.Strength * GameSettings.VeryEffectiveAttackFactor;
                GameSettings.Effectiveness = "very Effective";
                return damage;
            }

            if (this.CheckIfAttackIsVeryEffectrive(usedAttack) && GameSettings.AttackingPokemon == GameSettings.EnemyPokemon)
            {
                damage = usedAttack.Strength * GameSettings.VeryEffectiveAttackFactorOfEnemyPokemon;
                GameSettings.Effectiveness = "very Effective";
                return damage;
            }

            if (this.CheckIfAttackIsNotEffectrive(usedAttack) && GameSettings.AttackingPokemon == GameSettings.PlayerPokemon)
            {
                damage = usedAttack.Strength * GameSettings.NotEffectiveAttackFactor;
                GameSettings.Effectiveness = "not Effective";
                return damage;
            }

            if (this.CheckIfAttackIsNotEffectrive(usedAttack) && GameSettings.AttackingPokemon == GameSettings.EnemyPokemon)
            {
                damage = usedAttack.Strength * GameSettings.NotEffectiveAttackFactorOfEnemyPokemon;
                GameSettings.Effectiveness = "not Effective";
                return damage;
            }

            damage = usedAttack.Strength;
            GameSettings.Effectiveness = "Effective";
            return damage;
        }

        private bool CheckIfAttackIsVeryEffectrive(Attack usedAttack)
        {
            if (usedAttack.Type == GameSettings.DefendingPokemon.GetWeakness()) return true;

            return false;
        }

        private bool CheckIfAttackIsNotEffectrive(Attack usedAttack)
        {
            if (GameSettings.AttackingPokemon.GetWeakness() == GameSettings.DefendingPokemon.Type && this.CheckIfAttackGetsTypeBonus(usedAttack)) return true;

            return false;
        }

        private bool CheckIfAttackGetsTypeBonus(Attack usedAttack)
        {
            if (usedAttack.Type != Types.Normal) return true;

            return false;
        }

        private void TakeDamage(double damage, SmoothProgressBar hpBar)
        {
            double newHp = hpBar.Value - damage;

            if (newHp < 0)
                newHp = 0;
            else if (newHp > 1000) newHp = 1000;
            hpBar.SmoothValue = newHp;
        }

        private void DelcareEnemyPokemon()
        {
            int r = this.random.Next(0, this.allPokemon.Count - 1);

            this.UpdateList();
            if (GameSettings.Won)
            {
                GameSettings.Won = false;
            }
            else
            {
                GameSettings.EnemyPokemon = this.allPokemon[r];
                this.TxtPlayerPokemon.Text = GameSettings.PlayerPokemon.Name;
                this.TxtEnemyPokemon.Text = GameSettings.EnemyPokemon.Name;
            }
        }

        private void UpdateList()
        {
            this.allPokemon.RemoveAll(a => a.Beaten);
            this.allPokemon.RemoveAll(a => a.Name == GameSettings.PlayerPokemon.Name);
            this.CheckIfWon();
        }

        private void ShowPokemon()
        {
            this.PlayerHp.SmoothValue = 1000;
            this.EnemyHp.SmoothValue = 1000;
            ImageBehavior.SetAnimatedSource(this.ImgPlayerPokemon, GameSettings.PlayerPokemon.BackPath);
            ImageBehavior.SetAnimatedSource(this.ImgEnemyPokemon, GameSettings.EnemyPokemon.FrontPath);
        }

        private void PlayerHP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.PlayerHp.Value < this.PlayerHp.Maximum / 4) //Damit immer nach 25% geprüft wird
                this.PlayerHp.Foreground = Brushes.Red;
            else if (this.PlayerHp.Value < this.PlayerHp.Maximum / 2)
                this.PlayerHp.Foreground = Brushes.Orange;
            else
                this.PlayerHp.Foreground = Brushes.Green;

            if (this.PlayerHp.Value == this.PlayerHp.SmoothValue &&
                this.PlayerHp.SmoothValue != this.PlayerHp.Maximum && this.PlayerHp.SmoothValue != 0)
                this.EnableButtons();

            if (Math.Abs(this.PlayerHp.SmoothValue - this.PlayerHp.Value) > 0) //genauer als ==
            {
                if ((string) this.PlayerHp.Tag != @"ShouldBlink") this.PlayerHp.Tag = "ShouldBlink";
            }
            else
            {
                this.PlayerHp.Tag = "ShouldNotBlink";
            }

            if (this.PlayerHp.Value == 0 && this.PlayerHp.SmoothValue == 0)
            {
                bool waitforChoice = true;
                this.battleMusic.Stop();
                MessageBox.Show("You died!");
                while (waitforChoice)
                {
                    MessageBoxResult restartGame = MessageBox.Show("Do you want to restart the Game?", "Restart Pokemon PoGl", MessageBoxButton.YesNo);
                    if (restartGame == MessageBoxResult.Yes)
                    {
                        waitforChoice = false;
                        CharSelectView startWindow = new CharSelectView();
                        startWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBoxResult exitGame = MessageBox.Show("Are you sure you want to exit?", "Exit the Pokemon PoGl", MessageBoxButton.YesNo);
                        if (exitGame == MessageBoxResult.Yes)
                        {
                            waitforChoice = false;
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        private void EnemyHP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.EnemyHp.Value < this.EnemyHp.Maximum / 4)
                this.EnemyHp.Foreground = Brushes.Red;
            else if (this.EnemyHp.Value < this.EnemyHp.Maximum / 2)
                this.EnemyHp.Foreground = Brushes.Orange;
            else
                this.EnemyHp.Foreground = Brushes.Green;

            if (this.EnemyHp.Value == this.EnemyHp.SmoothValue && this.EnemyHp.SmoothValue != this.EnemyHp.Maximum &&
                this.EnemyHp.SmoothValue != 0)
                this.EnemyAttack();

            if (Math.Abs(this.EnemyHp.SmoothValue - this.EnemyHp.Value) > 0)
            {
                if ((string) this.EnemyHp.Tag != "ShouldBlink")
                {
                    this.EnemyHp.Tag = "ShouldBlink";
                    if (this.Stab != null && this.Normal != null) this.DisableButtons();
                }
            }
            else
            {
                this.EnemyHp.Tag = "ShouldNotBlink";
                if (this.Stab != null && this.Normal != null && this.EnemyHp.Value == this.EnemyHp.Maximum) this.EnableButtons();
            }

            if (this.EnemyHp.Value == 0)
            {
                GameSettings.EnemyPokemon.Beaten = true;
                this.DeathNarrator();
                this.PlayerHp.SmoothValue = this.PlayerHp.Maximum;
                this.UpdateEnemy();
            }
        }

        private void CheckIfWon()
        {
            if (this.allPokemon.Count == 0)
                if (!this.Groudon.Beaten)
                {
                    this.allPokemon.Add(this.Groudon);
                }
                else
                {
                    bool waitforChoice = true;
                    JsonSerialization.WriteToJsonFile(@"../../res/json/unlocked.json", true);
                    this.battleMusic.Stop();
                    MessageBox.Show("You have unlocked Groudon as playable character!", "You won!");
                    while (waitforChoice)
                    {
                        MessageBoxResult restartGame = MessageBox.Show("Do you want to restart the Game?", "Restart Pokemon PoGl", MessageBoxButton.YesNo);
                        if (restartGame == MessageBoxResult.Yes)
                        {
                            waitforChoice = false;
                            CharSelectView startWindow = new CharSelectView();
                            GameSettings.Won = true;
                            this.Close();
                            startWindow.Show();
                        }
                        else
                        {
                            MessageBoxResult exitGame = MessageBox.Show("Are you sure you want to exit?", "Exit the Pokemon PoGl", MessageBoxButton.YesNo);
                            if (exitGame == MessageBoxResult.Yes)
                            {
                                waitforChoice = false;
                                Environment.Exit(0);
                            }
                        }
                    }
                }
        }

        private void EnemyAttack()
        {
            List<Attack> availableAttacks = new List<Attack>
            {
                GameSettings.EnemyPokemon.NormalAttack,
                GameSettings.EnemyPokemon.StabAttack
            };

            int r = this.random.Next(0, 2);
            GameSettings.UsedAttack = availableAttacks[r];
            double damage = this.CalculateDamage(GameSettings.EnemyPokemon, GameSettings.UsedAttack);
            this.TakeDamage(damage, this.PlayerHp);

            if (GameSettings.Dodged)
            {
                this.DodgeNarrator();
                GameSettings.Dodged = false;
            }
            else
            {
                this.AttackNarrator();
            }

            availableAttacks.Clear();
        }

        private void DisableButtons()
        {
            this.Stab.IsEnabled = false;
            this.Normal.IsEnabled = false;
            this.Stab.Foreground = Brushes.SlateGray;
            this.Normal.Foreground = Brushes.SlateGray;
        }

        public void EnableButtons()
        {
            this.Stab.IsEnabled = true;
            this.Normal.IsEnabled = true;
            this.Stab.Foreground = Brushes.White;
            this.Normal.Foreground = Brushes.White;
        }

        private void AttackNarrator()
        {
            string statement =
                $"{GameSettings.AttackingPokemon.Name} used {GameSettings.UsedAttack.Name}...It's {GameSettings.Effectiveness}";
            this.Narrator.Text = statement;
        }

        private void DeathNarrator()
        {
            string statement = $"RIP, {GameSettings.DefendingPokemon.Name}. You will be missed";
            this.Narrator.Text = statement;
        }

        private void DodgeNarrator()
        {
            string statement = $"{GameSettings.DefendingPokemon.Name} has dodged {GameSettings.UsedAttack.Name}!";
            this.Narrator.Text = statement;
        }

        private void ImgPlayerPokemon_OnAnimationLoaded(object sender, RoutedEventArgs e)
        {
            ImageBehavior.SetRepeatBehavior(this.ImgPlayerPokemon, RepeatBehavior.Forever);
            ImageBehavior.SetAutoStart(this.ImgPlayerPokemon, true);
            this.ImgPlayerPokemon.Margin = GameSettings.PlayerPokemon.BackMargin;
        }

        private void ImgEnemyPokemon_OnAnimationLoaded(object sender, RoutedEventArgs e)
        {
            ImageBehavior.SetRepeatBehavior(this.ImgEnemyPokemon, RepeatBehavior.Forever);
            ImageBehavior.SetAutoStart(this.ImgEnemyPokemon, true);
            this.ImgEnemyPokemon.Margin = GameSettings.EnemyPokemon.FrontMargin;
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            GameSettings.Dodged = false;
            GameSettings.UsedAttack = GameSettings.PlayerPokemon.NormalAttack;

            double damage = this.CalculateDamage(GameSettings.PlayerPokemon, GameSettings.UsedAttack);
            this.TakeDamage(damage, this.EnemyHp);
            if (GameSettings.Dodged)
                this.DodgeNarrator();
            else
                this.AttackNarrator();
        }

        private void Stab_Click(object sender, RoutedEventArgs e)
        {
            GameSettings.Dodged = false;
            GameSettings.UsedAttack = GameSettings.PlayerPokemon.StabAttack;

            double damage = this.CalculateDamage(GameSettings.PlayerPokemon, GameSettings.UsedAttack);
            this.TakeDamage(damage, this.EnemyHp);
            if (GameSettings.Dodged)
                this.DodgeNarrator();
            else
                this.AttackNarrator();
        }
    }
}
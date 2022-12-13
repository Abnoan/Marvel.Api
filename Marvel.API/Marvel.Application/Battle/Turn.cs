namespace Marvel.Domain.Battle
{
    public class Turn
    {
        public Attacker Attacker { get; set; }
        public Defender Defender { get; set; }
        public int DiceAttackPower { get; set; }
        public int DiceDefensePower { get; set; }
        public int DamageDealed { get; set; }
    }

    public class PeopleHero
    {
        public string Name { get; set; }
        public int Hp { get; set; }
    }
    public class Attacker : PeopleHero
    {       
    }

    public class Defender : PeopleHero
    {
    }
}

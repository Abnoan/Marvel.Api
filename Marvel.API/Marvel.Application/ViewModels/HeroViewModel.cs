namespace Marvel.Application.ViewModels
{
    public class HeroViewModel
    {
        public HeroViewModel(int id, string name, int attackPower, int defensePower, int hP, bool affiliation)
        {
            Id = id;
            Name = name;
            AttackPower = attackPower;
            DefensePower = defensePower;
            HP = hP;
            Affiliation = affiliation;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int HP { get; set; }
        public bool Affiliation { get; set; }
    }
}

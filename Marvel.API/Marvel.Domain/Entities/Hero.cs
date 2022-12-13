namespace Marvel.Domain.Entities
{
    public class Hero : BaseEntity
    {
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int HP { get; set; }
        public bool Affiliation { get; set; }

        public void Update(string? name, int? attackPower, int? defensePower, int? hp, bool? affiliation)
        {
            if(!string.IsNullOrWhiteSpace(name)) Name = name;
            if (attackPower > 0) AttackPower = (int)attackPower;
            if (defensePower > 0) DefensePower = (int)defensePower;
            if (hp > 0) HP = (int)hp;
            if (affiliation is not null) Affiliation = (bool)affiliation;
        }

    }
}

using MediatR;

namespace Marvel.Application.Commands.Create
{
    public class CreateHeroCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int HP { get; set; }
        public bool Affiliation { get; set; }
    }
}

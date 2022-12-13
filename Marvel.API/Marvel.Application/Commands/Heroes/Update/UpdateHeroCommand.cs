using MediatR;

namespace Marvel.Application.Commands.Update
{
    public class UpdateHeroCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? AttackPower { get; set; }
        public int? DefensePower { get; set; }
        public int? HP { get; set; }
        public bool? Affiliation { get; set; }
    }
}

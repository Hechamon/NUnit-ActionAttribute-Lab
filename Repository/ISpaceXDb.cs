using System.Collections.Generic;

namespace Repository
{
    public interface ISpaceXDb : IEnumerable<Rocket>
    {
        void Initialize();
    }
}
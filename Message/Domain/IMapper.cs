

namespace Domain
{
    public interface IMapper<E, D>
        where E : class
        where D : class
    {
        public abstract D EntToDto(E ent);
        public abstract E DtoToEnt(D dto);
        public abstract E DtoToNewEnt(D dto);
    }
}

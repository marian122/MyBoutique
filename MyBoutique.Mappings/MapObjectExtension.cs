using AutoMapper;

namespace MyBoutique.Mappings
{
    public static class MapObjectExtension
    {
        public static TDestination MapTo<TDestination>(this object obj)
        {
            return Mapper.Instance.Map<TDestination>(obj);
        }
    }
}   

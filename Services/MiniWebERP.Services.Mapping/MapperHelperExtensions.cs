namespace MiniWebERP.Services.Mapping
{
    public static class MapperHelperExtensions
    {
        public static TDest MapTo<TDest>(this object src)
        {
            return (TDest)AutoMapper.Mapper.Map(src, src.GetType(), typeof(TDest));
        }
    }
}

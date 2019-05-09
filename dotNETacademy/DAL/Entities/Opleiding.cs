namespace dotNETacademy.Common.Entities
{
    public class Opleiding: IBaseEntity
    {
        public int Id { get; set; }
        public string Beschrijving { get; set; }
        //lazy loading
        public virtual TypeOpleiding Type { get; set; }
        public int Credits { get; set; }
    }
}

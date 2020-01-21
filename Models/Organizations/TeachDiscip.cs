namespace agos_api.Models.Organizations
{
    public class TeachDiscip 
    {
        public int TeachDiscipId { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
    }
}
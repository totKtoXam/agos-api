namespace agos_api.Models.Base
{
    public class TeachDiscip 
    {
        public int TeachDiscipId { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
    }
}
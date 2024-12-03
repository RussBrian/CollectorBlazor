namespace Collector.Client.Dtos.Pages
{
    public class PagesDto
    {
        public string Text { get; set; }
        public int Page {  get; set; }
        public bool Available { get; set; } = true;
        public bool Active { get; set; } = false;

        public PagesDto (int pagina) { 
            Page = pagina;
            Available = true;
        }
        public PagesDto(int pagem, bool available)
        {
            Page = pagem;
            Available = available;
        }

        public PagesDto (int pagem, bool available, string text) 
        {
            Page = pagem;
            Available = available;
            Text = text;
        }            
    }
}

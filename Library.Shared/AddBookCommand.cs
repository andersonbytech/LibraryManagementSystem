namespace Library.Shared
{
    public class AddBookCommand
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
    }

}

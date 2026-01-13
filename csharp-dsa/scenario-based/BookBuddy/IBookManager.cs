namespace BookBuddy
{
	public interface IBookManager
	{
		void AddBook(Book book);

		void SortBooksAlphabetically();

		void SearchByAuthor(string author);

		void DisplayBooks();
	}
}
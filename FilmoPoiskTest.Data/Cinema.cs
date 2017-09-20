using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FilmoPoiskTest.Data
{
	public class Cinema
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Index("CinemaUkByName", IsUnique =true)]
		[MaxLength(250)]
		public string Name { get; set; }

		public string Description { get; set; }

		public int ? Year { get; set; }

		public string Director { get; set; }

		public byte[] Poster { get; set; }

		[Required]
		public string User { get; set; }
	}
}

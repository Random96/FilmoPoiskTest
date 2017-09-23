using System.Drawing;
using System.ComponentModel.DataAnnotations;
using FilmoPoiskTest.Model;

namespace FilmoPoiskTest.Model
{
	public class CinemaViewModels
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Наименование фильма")]
		public string Name { get; set; }

		[Display(Name = "Описание")]
		public string Description { get; set; }

		[Display(Name = "Год выпуска")]
		public int Year { get; set; }

		[Display(Name = "Режиссёр")]
		public string Director { get; set; }

		public bool HasPoser { get; set; }


		[Display(Name = "Пользователь, который выложил информацию")]
		public string User { get; set; }
	}

	public class CinemaViewModelsWithPoster : CinemaViewModels
	{
		[Display(Name = "Постер")]
		public Bitmap Poster { get; set; }
	}
}
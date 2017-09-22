﻿using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace FilmoPoiskTest.Models
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

		[Display(Name = "Постер")]
		public Bitmap Poster { get; set; }

		[Required]
		[Display(Name = "Пользователь, который выложил информацию")]
		public string User { get; set; }
	}
}
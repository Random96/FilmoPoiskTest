using System.Reflection;
using Autofac;
using AutoMapper;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using FilmoPoiskTest.Model;

namespace FilmoPoiskTest.Data
{
	public static class ImageHekper
	{
		public static ImageFormat DefaultFormat => ImageFormat.Png;

		internal static byte[] ToByteArray(Bitmap image)
		{
			if (image == null ) return null;

			using (MemoryStream ms = new MemoryStream())
			{
				image.Save(ms, DefaultFormat);
				return ms.ToArray();
			}
		}

		internal static Bitmap ToBitmap(byte[] image)
		{
			if (image == null || image.Length == 0) return null;

			using (MemoryStream ms = new MemoryStream())
				return new Bitmap(ms);
		}

	}

	public class AutofacModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.AsImplementedInterfaces();

			builder.RegisterType<CinemaService>().As<ICinemaService>();

			builder.RegisterGeneric(typeof(Repository<>))
				.As(typeof(Model.IRWRepository<>));



			Mapper.Initialize(config =>
			{
				// automap configure
				config.CreateMap<CinemaViewModels, Cinema>()
				.ForMember(x => x.Poster, opt => opt.MapFrom(y => ImageHekper.ToByteArray( y.Poster ) ));

				config.CreateMap<Cinema, CinemaViewModels>()
				.ForMember(x => x.Poster, opt => opt.MapFrom(y => ImageHekper.ToBitmap(y.Poster)));
			});

		}
	}
}

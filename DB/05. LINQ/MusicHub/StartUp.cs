namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 120));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var stringBuilder = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Songs.Sum(s => s.Price))
                .Select(a => new
                 {
                     AlbumName = a.Name,
                     ReleaseDate = a.ReleaseDate,
                     a.Price,
                     ProducerName = a.Producer.Name,
                     Songs = a.Songs
                 });

            foreach (var album in albums)
            {
                stringBuilder.AppendLine($"-AlbumName: {album.AlbumName}");
                stringBuilder.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                stringBuilder.AppendLine($"-ProducerName: {album.ProducerName}");
                stringBuilder.AppendLine($"-Songs:");

                var index = 1;
                foreach (var song in album.Songs.OrderByDescending(s => s.Name).ThenBy(s => s.Writer))
                {
                    stringBuilder.AppendLine($"---#{index}");
                    stringBuilder.AppendLine($"---SongName: {song.Name}");
                    stringBuilder.AppendLine($"---Price: {song.Price:f2}");
                    stringBuilder.AppendLine($"---Writer: {song.Writer.Name}");

                    index++;
                }

                stringBuilder.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return stringBuilder.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var stringBuilder = new StringBuilder();

            var songs = context.Songs.AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,
                    PerformerInfo = s.SongPerformers
                        .Select(sp => new {sp.Performer.FirstName, sp.Performer.LastName}).FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    ProducerName = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerInfo);

            var index = 1;
            foreach (var song in songs)
            {
                stringBuilder.AppendLine($"-Song #{index}");
                stringBuilder.AppendLine($"---SongName: {song.Name}");
                stringBuilder.AppendLine($"---Writer: {song.WriterName}");
                if (song.PerformerInfo != null)
                {
                    stringBuilder.AppendLine($"---Performer: {song.PerformerInfo.FirstName} {song.PerformerInfo.LastName}");
                }
                else
                {
                    stringBuilder.AppendLine($"---Performer: ");
                }
                stringBuilder.AppendLine($"---AlbumProducer: {song.ProducerName}");
                stringBuilder.AppendLine($"---Duration: {song.Duration.ToString("c")}");

                index++;
            }

            return stringBuilder.ToString().Trim(); 
        }
    }
}

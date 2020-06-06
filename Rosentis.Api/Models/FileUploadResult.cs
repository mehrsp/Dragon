namespace Rosentis.Api.Models
{
	public enum FileType { Photo, Video, File }
	public class FileUploadResult
	{
		public bool IsUploaded { get; set; }
		public string FileName { get; set; }
		public float AspectRatio { get; set; }
		public string Message { get; set; }
		public FileType Type { get; set; }
		public int Size { get; set; }
		public string ContentType { get; set; }
	}
}
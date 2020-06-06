using Rosentis.Api.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Rosentis.Api.Helper
{
	public class UploadHelper
	{
		#region Methods
		public static FileUploadResult UploadMulti(HttpRequestMessage request, string path, string path2)
		{
			var model = new FileUploadResult();
			//var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			//json.UseDataContractJsonSerializer = true;
			//Dictionary<string, object> dict = new Dictionary<string, object>();
			HttpFileCollection uploadedFiles = HttpContext.Current.Request.Files;
			try
			{
				var httpRequest = HttpContext.Current.Request;
				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					//HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Created);
					//var t = 2;
					var postedFile = httpRequest.Files[i];
					if (postedFile != null && postedFile.ContentLength > 0)
					{
						var extension = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.')).ToLower();

						int MaxContentLength = int.MaxValue; //Size = 4 MB  

						IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
						if (!AllowedFileExtensions.Contains(extension))
						{
							model.Message = string.Format("Please Upload image of type .jpg,.gif,.png.");
							return model;
						}

						if (postedFile.ContentLength > MaxContentLength)
						{
							model.Message = string.Format("Please Upload a file upto 1 mb.");
							return model;
						}

						{
							var fileName = Guid.NewGuid().ToString() + extension;
							var userImageBasePath = path;
							var filePath = HttpContext.Current.Server.MapPath(userImageBasePath + fileName);
							postedFile.SaveAs(filePath);
							model.FileName = fileName;
							model.ContentType = postedFile.ContentType;
							model.Size = postedFile.ContentLength;
						}
					}
					if (i == uploadedFiles.Count - 1)
					{
						model.Message = string.Format("Image Updated Successfully.");
						{
							model.IsUploaded = true;
							return model;
						}
					}

				}
				{
					model.Message = string.Format("Please Upload a image.");
					return model;
				}
			}
			catch (System.Exception ex)
			{
				var exTest = ex;
				model.Message = string.Format("Unkonwn Error");
				return model;
			}
		}

		public static FileUploadResult Upload(HttpRequestMessage request, string path)
		{
			var model = new FileUploadResult();
			//var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			//json.UseDataContractJsonSerializer = true;
			//Dictionary<string, object> dict = new Dictionary<string, object>();
			try
			{
				var httpRequest = HttpContext.Current.Request;
				foreach (string file in httpRequest.Files)
				{
					//HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Created);

					var postedFile = httpRequest.Files[file];
					if (postedFile != null && postedFile.ContentLength > 0)
					{
						var extension = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.')).ToLower();
						var fileName = Guid.NewGuid().ToString() + extension;
						if (file == "photo")
						{
							int MaxContentLength = 2048 * 2048 * 1; //Size = 4 MB  

							IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
							if (!AllowedFileExtensions.Contains(extension))
							{
								model.Message = string.Format("Please Upload image of type .jpg,.gif,.png.");
								return model;
							}

							if (postedFile.ContentLength > MaxContentLength)
							{
								model.Message = string.Format("Please Upload a file upto 4 mb.");
								return model;
							}

							model.Type = FileType.Photo;
							model.ContentType = postedFile.ContentType;
							model.Size = postedFile.ContentLength;
							System.IO.Stream stream = postedFile.InputStream;
							System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

							int height = image.Height;
							int width = image.Width;
							model.AspectRatio = (float)((float)height / (float)width);

							var thumb = "thumb";
							var thumbPaths = new string[] { path, thumb, fileName };
							var thumbPath = Path.Combine(thumbPaths);
							var thumbFile = HttpContext.Current.Server.MapPath(thumbPath);

							
							resizeImage(thumbFile, image);
						}
						else if (file == "video")
						{
							long MaxContentLength = long.MaxValue; //Size = Max

							IList<string> AllowedFileExtensions = new List<string> { ".mp4", ".avi" };
							if (!AllowedFileExtensions.Contains(extension))
							{
								model.Message = string.Format("Please Upload video of type .mp4,.avi");
								return model;
							}

							if (postedFile.ContentLength > MaxContentLength)
							{
								model.Message = string.Format("Please Upload a file upto 100mb mb.");
								return model;
							}

							model.Type = FileType.Video;
							model.ContentType = postedFile.ContentType;
							model.Size = postedFile.ContentLength;
						}
						else if (file == "file")
						{
							long MaxContentLength = long.MaxValue; //Size = Max

							IList<string> DeniedFileExtensions = new List<string> { ".exe", ".cmd", ".bat" };
							if (DeniedFileExtensions.Contains(extension))
							{
								model.Message = string.Format("Please Upload a valid document.");
								return model;
							}
							if (postedFile.ContentLength > MaxContentLength)
							{
								model.Message = string.Format("Please Upload a file upto 100mb mb.");
								return model;
							}

							model.Type = FileType.File;
							model.ContentType = postedFile.ContentType;
							model.Size = postedFile.ContentLength;
						}
						
						var userImageBasePath = path;
						model.FileName = fileName;
						var paths = new string[] { userImageBasePath, fileName };
						var fullPath = Path.Combine(paths);
						var filePath = HttpContext.Current.Server.MapPath(fullPath);

						postedFile.SaveAs(filePath);

					}
					model.Message = string.Format("File Uploaded Successfully.");
					{
						model.IsUploaded = true;
						return model;
					}
				}
				{
					model.Message = string.Format("Please Upload an image.");
					return model;
				}
			}
			catch (System.Exception ex)
			{
				var exT = ex;

				model.Message = string.Format("Unkonwn Error");
				return model;
			}
		}

		public static FileUploadResult Upload2(HttpRequestMessage request, string path)
		{
			var model = new FileUploadResult();
			//var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			//json.UseDataContractJsonSerializer = true;
			//Dictionary<string, object> dict = new Dictionary<string, object>();
			try
			{
				var httpRequest = HttpContext.Current.Request;
				foreach (string file in httpRequest.Files)
				{
					//HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Created);

					var postedFile = httpRequest.Files[file];
					if (postedFile != null && postedFile.ContentLength > 0)
					{
						var extension = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.')).ToLower();
						if (file == "photo")
						{
							int MaxContentLength = 2048 * 2048 * 1; //Size = 4 MB  

							IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
							if (!AllowedFileExtensions.Contains(extension))
							{
								model.Message = string.Format("Please Upload image of type .jpg,.gif,.png.");
								return model;
							}

							if (postedFile.ContentLength > MaxContentLength)
							{
								model.Message = string.Format("Please Upload a file upto 4 mb.");
								return model;
							}

							model.Type = FileType.Photo;
							model.ContentType = postedFile.ContentType;
							model.Size = postedFile.ContentLength;
							System.IO.Stream stream = postedFile.InputStream;
							System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

							int height = image.Height;
							int width = image.Width;
							model.AspectRatio = (float)((float)height / (float)width);
						}
						else if (file == "video")
						{
							long MaxContentLength = long.MaxValue; //Size = Max

							IList<string> AllowedFileExtensions = new List<string> { ".mp4", ".avi" };
							if (!AllowedFileExtensions.Contains(extension))
							{
								model.Message = string.Format("Please Upload video of type .mp4,.avi");
								return model;
							}

							if (postedFile.ContentLength > MaxContentLength)
							{
								model.Message = string.Format("Please Upload a file upto 100mb mb.");
								return model;
							}

							model.Type = FileType.Video;
							model.ContentType = postedFile.ContentType;
							model.Size = postedFile.ContentLength;
						}
						else if (file == "file")
						{
							long MaxContentLength = long.MaxValue; //Size = Max

							IList<string> DeniedFileExtensions = new List<string> { ".exe", ".cmd", ".bat" };
							if (DeniedFileExtensions.Contains(extension))
							{
								model.Message = string.Format("Please Upload a valid document.");
								return model;
							}
							if (postedFile.ContentLength > MaxContentLength)
							{
								model.Message = string.Format("Please Upload a file upto 100mb mb.");
								return model;
							}

							model.Type = FileType.File;
							model.ContentType = postedFile.ContentType;
							model.Size = postedFile.ContentLength;
						}
						var fileName = Guid.NewGuid().ToString() + extension;
						var userImageBasePath = path;
						var filePath = HttpContext.Current.Server.MapPath(userImageBasePath + fileName);
						postedFile.SaveAs(filePath);
						model.FileName = fileName;
					}
					model.Message = string.Format("File Uploaded Successfully.");
					{
						model.IsUploaded = true;
						return model;
					}
				}
				{
					model.Message = string.Format("Please Upload an image.");
					return model;
				}
			}
			catch (System.Exception ex)
			{
				var exT = ex;
				model.Message = string.Format("Unkonwn Error");
				return model;
			}
		}

		public static HttpResponseMessage Download(string path, string fileName)
		{
				var fullPath = HttpContext.Current.Server.MapPath(path);
				if (File.Exists(fullPath))
				{
					var response = new HttpResponseMessage(HttpStatusCode.OK);
					var fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
					response.Content = new StreamContent(fileStream);
					response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
					{
						FileName = fileName
					};
					response.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
					return response;
				}

			return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
		}

		public static void resizeImage(string path, Image image) {
			
			float aspectRatio = (float)image.Size.Width / (float)image.Size.Height;
			int newHeight = 100;
			int newWidth = 100;
			System.Drawing.Bitmap thumbBitmap = new System.Drawing.Bitmap(newWidth, newHeight);
			System.Drawing.Graphics thumbGraph = System.Drawing.Graphics.FromImage(thumbBitmap);
			thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
			thumbGraph.DrawImage(image, imageRectangle);
			var test = path;
			thumbBitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
			thumbGraph.Dispose();
			thumbBitmap.Dispose();
			image.Dispose();

		}
		#endregion Methods
	}
}
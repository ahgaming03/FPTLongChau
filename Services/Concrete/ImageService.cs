using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FPTLongChau.Options;
using FPTLongChau.Services.Abstract;
using Microsoft.Extensions.Options;

namespace FPTLongChau.Services.Concrete
{
	public class ImageService : IImageService
	{
		private readonly AzureOptions _azureOptions;
		public ImageService(IOptions<AzureOptions> azureOptions)
		{
			_azureOptions = azureOptions.Value;
		}
		public string UploadImageToAzureBlob(IFormFile file)
		{
			string fileExtension = Path.GetExtension(file.FileName);

			using MemoryStream fileUploadStream = new MemoryStream();
			file.CopyTo(fileUploadStream);
			fileUploadStream.Position = 0;
			BlobContainerClient blobContainerClient = new BlobContainerClient(
														_azureOptions.ConnectionString,
														_azureOptions.Container);
			var uniqueName = Guid.NewGuid().ToString() + fileExtension;
			BlobClient blobClient = blobContainerClient.GetBlobClient(uniqueName);

			blobClient.Upload(fileUploadStream, new BlobUploadOptions()
			{
				HttpHeaders = new BlobHttpHeaders
				{
					ContentType = "image/bitmap"
				}
			}, cancellationToken: default);
			return uniqueName;
		}
		public void DeleteImageFromAzureBlob(string fileName)
		{
			BlobContainerClient blobContainerClient = new BlobContainerClient(
														_azureOptions.ConnectionString,
														_azureOptions.Container);
			BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
			blobClient.DeleteIfExistsAsync();
		}
	}
}

namespace FPTLongChau.Services.Abstract
{
	public interface IImageService
	{
		string UploadImageToAzureBlob(IFormFile file);
		void DeleteImageFromAzureBlob(string fileName);
	}
}

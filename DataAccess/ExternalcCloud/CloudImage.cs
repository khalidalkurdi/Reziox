﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
namespace DataAccess.ExternalcCloud
{
    public class CloudImage : ICloudImag
    {
        private readonly Cloudinary _cloudinary;
        public CloudImage(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }
        public async Task<string> SaveImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
                throw new Exception();
            //requst
            using var stream = image.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(image.FileName, stream)
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            if (uploadResult.Error != null)
                throw new Exception();
            return uploadResult.SecureUrl.ToString();
        }

    }
}

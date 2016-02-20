namespace ChooseMe.Services
{
    using System;
    using Models;
    using ChooseMe.Services.Contracts;
    using Data.Repositories;
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Photo> photos;

        public PhotoService(IRepository<Photo> photos)
        {
            this.photos = photos;
        }

        public void AddNew(Photo photo)
        {
            this.photos.Add(photo);
            this.photos.SaveChanges();
        }
    }
}

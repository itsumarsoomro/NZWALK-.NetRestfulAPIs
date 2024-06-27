using FirstRestfulAPI.Model.Domain;
using System.Net;

namespace FirstRestfulAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}

using NewCI.Entities.DTOs;
using NewCI.Entities.Models;
using NewCI.Interfaces.RepositoryInterfaces;

using NewCI.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Business.Services
{
    public class BannerService : GenericService<Banner>, IBannerService
    {
        public readonly IGenericInterface<Banner> _banner;
        public BannerService(IGenericInterface<Banner> repository) : base(repository)
        {
            _banner = repository;
        }
        public BannersDto? GetBanners()
        {
            BannersDto bannerDto = new BannersDto()
            {
                Banners =  _banner.GetAll(1, null, 20).Entries!.OrderBy(x => x.SortOrder).ToList()
            };

            return bannerDto;
        }

    }
}

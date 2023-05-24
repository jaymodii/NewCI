using NewCI.Entities.DTOs;
using NewCI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Interfaces.ServiceInterfaces
{
    public interface IBannerService
    {

        public BannersDto? GetBanners();
    }
}

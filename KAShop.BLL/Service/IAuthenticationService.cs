using KAShop.DAL.DTO.Request;
using KAShop.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAShop.BLL.Service
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> RegisterUser(RegisterRequest request);
    }
}

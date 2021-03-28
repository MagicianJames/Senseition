using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Senseition.Datas;

namespace Senseition.Controllers
{
    public abstract class BaseController : Controller
    {
        protected const string _baseUrl = "api/v1/";
        protected readonly ApplicationDbContext _db;
        
        public BaseController() { }
        public BaseController(ApplicationDbContext _db)
        {
            this._db = _db;
        }

    }
}
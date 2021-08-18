using Microsoft.AspNetCore.Mvc;
using System;

namespace EventReminder.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IServiceProvider _provider;

        public BaseController(IServiceProvider provider) : base()
        {
            _provider = provider;
        }
    }
}

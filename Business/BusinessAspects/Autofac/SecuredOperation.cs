using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        public string role { get; set; }
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var jwtToken = _httpContextAccessor.HttpContext.Session.GetString("token");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var jti = tokenS.Claims.ToList();
            var userRole = jti[3].Value;
            if (userRole.Equals(role))
            {
                return;
            }
            throw new Exception("Yetkiniz yoktur!");
        }
    }
}

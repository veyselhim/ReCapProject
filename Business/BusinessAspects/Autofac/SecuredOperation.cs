using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        //JWT
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');  //rolleri virgül ile ayırdık
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)    //Add methodunun çnünde çalıştırdık
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //O anki kullanıcının rollerini bul
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))  //claimlerinin içinde ilgili role varsa
                {
                    return; //methodu çaıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //Authorization hatası ver.
        }
    }
}

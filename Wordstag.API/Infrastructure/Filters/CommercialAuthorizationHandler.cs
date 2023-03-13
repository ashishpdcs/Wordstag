using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Wordstag.API.Infrastructure.Attributes;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Utility;
using Newtonsoft.Json;
using System.Security.Claims;
using Wordstag.Services.Entities.User;

namespace Wordstag.API.Infrastructure.Filters
{
    public class CommercialAuthorizationHandler : AttributeAuthorizationHandler<CommercialAuthorizationRequirement, CommercialAuthorizeAttribute>
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly AppSettings _appSettings;

        public CommercialAuthorizationHandler(IHttpContextAccessor accessor,
            IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork, IUnitOfWork<ReadWriteApplicationDbContext> readWriteUnitOfWork,
            IOptions<AppSettings> appSettings)
        {
            _accessor = accessor;
            _readOnlyUnitOfWork = readOnlyUnitOfWork;
            _readWriteUnitOfWork = readWriteUnitOfWork;
            this._appSettings = appSettings.Value;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            CommercialAuthorizationRequirement requirement, IEnumerable<CommercialAuthorizeAttribute> attributes)
        {
            foreach (var permissionAttribute in attributes)
            {
                if (!await AuthorizeAsync(context.User, permissionAttribute.Name))
                {
                    context.Fail();
                    throw new UnauthorizedAccessException();
                }
            }

            context.Succeed(requirement);
        }

        private async Task<bool> AuthorizeAsync(ClaimsPrincipal user, string permission = null)
        {
            var token = _accessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var subdomain = _accessor.HttpContext.Request.Headers["subdomain"].FirstOrDefault()?.Split(" ").Last();

            if (!user.Identity.IsAuthenticated)
                return false;

            if (subdomain != _appSettings.SubDomain)
            {
                //if (!await _readOnlyUnitOfWork.CurrentConnectionRepository.AnyAsync(c => c.JwtToken == token))
                //{
                //    throw new UnauthorizedAccessException("VAMS6008");
                //}
            }
            var sessionDetails = JsonConvert.DeserializeObject<SessionDetailsDto>(_accessor.HttpContext.Items[Constants.JwtTokenClaimKey].ToString());


            if (string.IsNullOrWhiteSpace(permission))
                return true;
            var permissions = permission.ToLower().Split(',');


            if (_accessor.HttpContext.Items[Constants.JwtTokenClaimKey] == null)
                return false;

            //var employeeLevel2 = _readOnlyUnitOfWork.EmployeeLevel2Repository
            //    .FindWithChilds(c => c.EmployeeId == sessionDetails.EmployeeId && c.IsDefault)
            //    .FirstOrDefault();

            //if (employeeLevel2 == null)
            //    return false;

            //var rolePermissions = _readOnlyUnitOfWork.RolePermissionRepository
            //    .Find(c => c.RoleId == employeeLevel2.Role.Id
            //            && permissions.Contains(c.Permission.PermissionKey.ToLower())
            //            && c.Permission.IsPermissible
            //            && c.IsPermissible).ToList();

            //if (!rolePermissions.Any())
            //    return false;

            return false;
        }
    }

    public class CommercialAuthorizationRequirement : IAuthorizationRequirement
    {
        //Add any custom requirement properties if you have them
    }
}

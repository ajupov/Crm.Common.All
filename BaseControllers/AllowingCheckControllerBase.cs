using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Common.All.UserContext;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Common.All.BaseControllers
{
    public class AllowingCheckControllerBase : ControllerBase
    {
        private readonly IUserContext _userContext;

        public AllowingCheckControllerBase(IUserContext userContext)
        {
            _userContext = userContext;
        }

        [NonAction]
        public async Task<ActionResult> ActionIfAllowed(
            Func<Task> action,
            string[] nonPrivilegedRoles,
            params Guid[] accountIds)
        {
            if (_userContext.HasRoles(Roles.Roles.Privileged))
            {
                await action();

                return NoContent();
            }

            if (_userContext.HasRoles(nonPrivilegedRoles) && _userContext.Belongs(accountIds))
            {
                await action();

                return NoContent();
            }

            if (_userContext.HasRoles(nonPrivilegedRoles) && !_userContext.Belongs(accountIds))
            {
                return Forbid();
            }

            throw new Exception();
        }

        [NonAction]
        public Task<ActionResult> ActionIfAllowed(
            Func<Task> action,
            string[] nonPrivilegedRoles,
            IEnumerable<Guid> accountIds)
        {
            return ActionIfAllowed(action, nonPrivilegedRoles, accountIds.ToArray());
        }

        public Task<ActionResult> ActionIfAllowed(
            Func<Task> action,
            string nonPrivilegedRole,
            params Guid[] accountIds)
        {
            return ActionIfAllowed(action, new[] {nonPrivilegedRole}, accountIds);
        }

        [NonAction]
        public Task<ActionResult> ActionIfAllowed(
            Func<Task> action,
            string nonPrivilegedRole,
            IEnumerable<Guid> accountIds)
        {
            return ActionIfAllowed(action, new[] {nonPrivilegedRole}, accountIds);
        }

        [NonAction]
        public ActionResult<TResult> ReturnIfAllowed<TResult>(
            TResult result,
            string[] nonPrivilegedRoles,
            params Guid[] accountIds)
        {
            if (_userContext.HasRoles(Roles.Roles.Privileged))
            {
                return result;
            }

            if (_userContext.HasRoles(nonPrivilegedRoles) && _userContext.Belongs(accountIds))
            {
                return result;
            }

            if (_userContext.HasRoles(nonPrivilegedRoles) && !_userContext.Belongs(accountIds))
            {
                return Forbid();
            }

            throw new Exception();
        }

        [NonAction]
        public ActionResult<TResult> ReturnIfAllowed<TResult>(
            TResult result,
            string nonPrivilegedRole,
            IEnumerable<Guid> accountIds)
        {
            return ReturnIfAllowed(result, new[] {nonPrivilegedRole}, accountIds.ToArray());
        }

        [NonAction]
        public ActionResult<TResult> ReturnIfAllowed<TResult>(
            TResult result,
            string nonPrivilegedRole,
            params Guid[] accountIds)
        {
            return ReturnIfAllowed(result, new[] {nonPrivilegedRole}, accountIds);
        }

        [NonAction]
        public ActionResult<TResult> ReturnIfAllowed<TResult>(
            TResult result,
            string[] nonPrivilegedRoles,
            IEnumerable<Guid> accountIds)
        {
            return ReturnIfAllowed(result, nonPrivilegedRoles, accountIds.ToArray());
        }
    }
}
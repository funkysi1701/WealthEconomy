//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Controllers.OData
{
    using BusinessObjects;
    using Facade;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Web.OData;
    using Web.Controllers.Extensions;

    public abstract class BaseUserRolesController : BaseODataController
    {
        public BaseUserRolesController()
		{
			MainUnitOfWork = new UserRoleUnitOfWork();		
		}

		protected UserRoleUnitOfWork MainUnitOfWork { get; private set; }

        // GET odata/UserRole
        //[Queryable]
        public virtual IQueryable<UserRole> Get()
        {
			var userId = this.GetCurrentUserId();
			if (!userId.HasValue)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);	

			var list = MainUnitOfWork.AllLive;
			list = list.Where(item => item.UserId == userId.Value);
            return list;
        }

        // GET odata/UserRole(5)
        //[Queryable]
        public virtual SingleResult<UserRole> Get([FromODataUri] int key)
        {
            return SingleResult.Create(MainUnitOfWork.AllLive.Where(userRole => userRole.UserId == key));
        }

        // PUT odata/UserRole(5)
        public virtual async Task<IHttpActionResult> Put([FromODataUri] int key, UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != userRole.UserId)
            {
                return BadRequest();
            }

            try
            {
                await MainUnitOfWork.UpdateAsync(userRole);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainUnitOfWork.Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }

            return Ok(userRole);
        }

        // POST odata/UserRole
        public virtual async Task<IHttpActionResult> Post(UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await MainUnitOfWork.InsertAsync(userRole);
            }
            catch (DbUpdateException)
            {
                if (MainUnitOfWork.Exists(userRole.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(userRole);
        }

        // PATCH odata/UserRole(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public virtual async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<UserRole> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userRole = await MainUnitOfWork.FindAsync(key);
            if (userRole == null)
            {
                return NotFound();
            }

            var patchEntity = patch.GetEntity();

            // TODO How is passed ModelState.IsValid?
            if (patchEntity.RowVersion == null)
                throw new InvalidOperationException("RowVersion property of the entity cannot be null");

            if (!userRole.RowVersion.SequenceEqual(patchEntity.RowVersion))
            {
                return Conflict();
            }

            patch.Patch(userRole);
            await MainUnitOfWork.UpdateAsync(userRole);

            return Ok(userRole);
        }

        // DELETE odata/UserRole(5)
        public virtual async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var userRole = await MainUnitOfWork.FindAsync(key);
            if (userRole == null)
            {
                return NotFound();
            }

            await MainUnitOfWork.DeleteAsync(userRole.UserId);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }

    public partial class UserRolesController : BaseUserRolesController
    {
	}
}

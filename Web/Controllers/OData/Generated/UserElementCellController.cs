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

    public abstract class BaseUserElementCellController : BaseODataController
    {
        public BaseUserElementCellController()
		{
			MainUnitOfWork = new UserElementCellUnitOfWork();		
		}

		protected UserElementCellUnitOfWork MainUnitOfWork { get; private set; }

        // GET odata/UserElementCell
        //[Queryable]
        public virtual IQueryable<UserElementCell> Get()
        {
			var userId = this.GetCurrentUserId();
			if (!userId.HasValue)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);	

			var list = MainUnitOfWork.AllLive;
			list = list.Where(item => item.UserId == userId.Value);
            return list;
        }

        // GET odata/UserElementCell(5)
        //[Queryable]
        public virtual SingleResult<UserElementCell> Get([FromODataUri] int key)
        {
            return SingleResult.Create(MainUnitOfWork.AllLive.Where(userElementCell => userElementCell.Id == key));
        }

        // PUT odata/UserElementCell(5)
        public virtual async Task<IHttpActionResult> Put([FromODataUri] int key, UserElementCell userElementCell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != userElementCell.Id)
            {
                return BadRequest();
            }

            try
            {
                await MainUnitOfWork.UpdateAsync(userElementCell);
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

            return Ok(userElementCell);
        }

        // POST odata/UserElementCell
        public virtual async Task<IHttpActionResult> Post(UserElementCell userElementCell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await MainUnitOfWork.InsertAsync(userElementCell);
            }
            catch (DbUpdateException)
            {
                if (MainUnitOfWork.Exists(userElementCell.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(userElementCell);
        }

        // PATCH odata/UserElementCell(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public virtual async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<UserElementCell> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userElementCell = await MainUnitOfWork.FindAsync(key);
            if (userElementCell == null)
            {
                return NotFound();
            }

            var patchEntity = patch.GetEntity();

            // TODO How is passed ModelState.IsValid?
            if (patchEntity.RowVersion == null)
                throw new InvalidOperationException("RowVersion property of the entity cannot be null");

            if (!userElementCell.RowVersion.SequenceEqual(patchEntity.RowVersion))
            {
                return Conflict();
            }

            patch.Patch(userElementCell);
            await MainUnitOfWork.UpdateAsync(userElementCell);

            return Ok(userElementCell);
        }

        // DELETE odata/UserElementCell(5)
        public virtual async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var userElementCell = await MainUnitOfWork.FindAsync(key);
            if (userElementCell == null)
            {
                return NotFound();
            }

            await MainUnitOfWork.DeleteAsync(userElementCell.Id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }

    public partial class UserElementCellController : BaseUserElementCellController
    {
	}
}

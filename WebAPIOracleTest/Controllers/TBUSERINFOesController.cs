using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Tracing;
using WebAPIOracleTest.Models;

namespace WebAPIOracleTest.Controllers
{
    [RoutePrefix("api/tbuserinfoes")]
    public class TBUSERINFOesController : ApiController
    {
        private SelfDbEntities db = new SelfDbEntities();

        //check user identity
        // GET: api/tbuserinfoes/certsn

        [Route("{certsn}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> GetTBUserPermission(string certsn)
        {
            TBUSERINFO tBUSERINFO;
            try
            {
                Configuration.Services.GetTraceWriter().Info(Request, "TBUSERINFOesController", "Check user perimission.");
                tBUSERINFO = await db.TBUSERINFOes.SingleOrDefaultAsync(p => p.CERTSN == certsn && p.ISSTAFF==1);


            }
            catch (Exception ex )
            {
                Configuration.Services.GetTraceWriter().Error(Request, "TBUSERINFOesController", ex);
                tBUSERINFO = null;
            }

            if (tBUSERINFO == null)
            {
                return NotFound();
            }
            return Ok(true);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBUSERINFOExists(long id)
        {
            return db.TBUSERINFOes.Count(e => e.ID == id) > 0;
        }
    }
}
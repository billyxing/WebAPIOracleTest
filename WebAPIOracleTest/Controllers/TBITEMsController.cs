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
using WebAPIOracleTest.Models;

namespace WebAPIOracleTest.Controllers
{
    [RoutePrefix("api/tbitems")]
    public class TBITEMsController : ApiController
    {
        private SelfDbEntities db = new SelfDbEntities();


        // GET: api/TBITEMs
        //[Route("")]
        //public IQueryable<TBITEM> GetTBITEMs()
        //{
        //    return db.TBITEMs;
        //}

        // GET: api/TBITEMs/5
        [Route("id:int")]
        [ResponseType(typeof(TBITEM))]
        public async Task<IHttpActionResult> GetTBITEM(long id)
        {
            TBITEM tBITEM = await db.TBITEMs.FindAsync(id);
            if (tBITEM == null)
            {
                return NotFound();
            }

            return Ok(tBITEM);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBITEMExists(long id)
        {
            return db.TBITEMs.Count(e => e.ITEMID == id) > 0;
        }
    }
}
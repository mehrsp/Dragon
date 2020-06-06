using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Rosentis.Api.JsonWebTokenConfig;
using Rosentis.DataContract.AuthEntities;
using Rosentis.ServiceContract.AuthEntities;
using Microsoft.AspNet.Identity;
using ServiceStack;

namespace Rosentis.Api.Controllers
{
    [System.Web.Http.RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly ITokenStoreApplicationService _tokenStoreApplicationService;
        private readonly IUsersApplicationService _usersApplicationService;

        public UserController(ITokenStoreApplicationService tokenStoreApplicationService, IUsersApplicationService usersApplicationService)
        {
            _tokenStoreApplicationService = tokenStoreApplicationService;
            _usersApplicationService = usersApplicationService;
        }
        [System.Web.Http.Route("create")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(UserDto userDto)
        {
            return Ok(_usersApplicationService.Save(userDto));
        }
        [System.Web.Http.Route("changePassword")]
        [System.Web.Http.HttpPost]
        [JwtAuthorize]
        public IHttpActionResult ChangePassword(ChangePasswordRequestDto userDto)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = long.Parse(identity.FindFirst(ClaimTypes.UserData).Value);
            userDto.UserId = userId;

            return Ok(_usersApplicationService.ChangePassword(userDto));
        }
        [System.Web.Http.Route("Findall")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult FindAll()
        {
            return Ok(_usersApplicationService.FindAll());
        }

        [System.Web.Http.Route("generateVerificationCode")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult GenerateVeificationCode(long phoneNumber)
        {
            _usersApplicationService.GenerateVerificationCode(phoneNumber);
            return Ok(true);
        }
        [System.Web.Http.Route("login")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Login(UserDto userDto)
        {
            return Ok();
        }
        [System.Web.Http.Route("ExportToExcel")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ExportToExcel()
        {
            // Create a new workbook.
        //    SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        //    SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        //    SpreadsheetGear.IRange cells = worksheet.Cells;

        //    // Set the worksheet name.
        //    worksheet.Name = "2005 Sales";

        //    // Load column titles and center.
        //    cells["B1"].Formula = "North";
        //    cells["C1"].Formula = "South";
        //    cells["D1"].Formula = "East";
        //    cells["E1"].Formula = "West";
        //    cells["B1:E1"].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

        //    // Load row titles using multiple cell text reference and iteration.
        //    int quarter = 1;
        //    foreach (SpreadsheetGear.IRange cell in cells["A2:A5"])
        //        cell.Formula = "Q" + quarter++;

        //    // Load random data and format as $ using a multiple cell range.
        //    SpreadsheetGear.IRange body = cells[1, 1, 4, 4];
        //    body.Formula = "=RAND() * 10000";
        //    body.NumberFormat = "$#,##0_);($#,##0)";


        //    // Save workbook to an Open XML (XLSX) workbook stream.
        //    System.IO.Stream stream = workbook.SaveToStream(
        //        SpreadsheetGear.FileFormat.OpenXMLWorkbook);

        //    // Reset stream's current position back to the beginning.
        //    stream.Seek(0, System.IO.SeekOrigin.Begin);

        //    // Stream the Excel spreadsheet to the client in a format
        //    // compatible with Excel 97/2000/XP/2003/2007/2010/2013/2016.
        //    //return new FileStreamResult(stream,
        //    //    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        //    HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
        //    httpResponseMessage.Content = new StreamContent(stream);
        //    httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //    httpResponseMessage.Content.Headers.ContentDisposition.FileName = "ExcelFile.xlsx";
        //    httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

        //    return httpResponseMessage;
        //}
        //[System.Web.Http.Route("ImportToDb")]
        //[System.Web.Http.HttpPost]

        //public HttpResponseMessage ImportToDb()
        //{
        //    var httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Files.Count < 1)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    foreach (string file in httpRequest.Files)
        //    {
        //        var postedFile = httpRequest.Files[file];
        //        var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
        //        SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();
        //        SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.OpenFromStream(postedFile.InputStream);
        //        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
        //        SpreadsheetGear.IRange cells = worksheet.Cells;
        //        var test = cells["B2"].Value;
        //        // NOTE: To store in memory use postedFile.InputStream
        //    }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [JwtAuthorize]
        [System.Web.Http.Route("logout")]
        [System.Web.Http.HttpGet, System.Web.Http.HttpPost]
        public IHttpActionResult Logout()
        {
            var accessToken = Request.Headers.Authorization.Parameter;
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.UserData).Value;
            // The OWIN OAuth implementation does not support "revoke OAuth token" (logout) by design.
            // Delete the user's tokens from the database (revoke its bearer token)
            _tokenStoreApplicationService.InvalidateUserTokens(accessToken);
            _tokenStoreApplicationService.DeleteExpiredTokens();

            return this.Ok(new { message = "Logout successful." });
        }
    }
}
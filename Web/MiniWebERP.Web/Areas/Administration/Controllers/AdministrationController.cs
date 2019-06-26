namespace MiniWebERP.Web.Areas.Administration.Controllers
{
    using MiniWebERP.Common;
    using MiniWebERP.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

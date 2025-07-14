using System.Web.Mvc;

namespace AciSozlukWebApp.Areas.MemberPanel
{
    public class MemberPanelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MemberPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
    "MemberPanel_default",
    "MemberPanel/{controller}/{action}/{id}",
    new { action = "Index", id = UrlParameter.Optional },
    namespaces: new[] { "AciSozlukWebApp.Areas.MemberPanel.Controllers" }
);
        }
    }
}
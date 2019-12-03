using System.Web;
using System.Web.Optimization;

namespace Pidev.Web
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery-ui.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jsBundle").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/raphael.min.js",
                        "~/Scripts/morris.min.js",
                        "~/Scripts/jquery.sparkline.min.js",
                        "~/Scripts/jquery-jvectormap-1.2.2.min.js",
                        "~/Scripts/jquery-jvectormap-world-mill-en.js",
                        "~/Scripts/jquery.knob.min.js",
                        "~/Scripts/moment.min.js",
                        "~/Scripts/daterangepicker.js",
                        "~/Scripts/bootstrap-datepicker.min.js",
                        "~/Scripts/bootstrap3-wysihtml5.all.min.js",
                        "~/Scripts/jquery.slimscroll.min.js",
                        "~/Scripts/fastclick.js",
                        "~/Scripts/adminlte.min.js",
                        "~/Scripts/dashboard.js",
                        "~/Scripts/demo.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/fullcalendar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/JSB").Include(
                        "~/Scripts/html5shiv.min.js",
                        "~/Scripts/respond.min.js"


                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Custom
            bundles.Add(new StyleBundle("~/Content/css/custom-style").Include(
                                        "~/Content/style/custom-style.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/_all-skins.min.css",
                      "~/Content/AdminLTE.min.css",
                      "~/Content/bootstrap-datepicker.min.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap3-wysihtml5.min.css",
                      "~/Content/daterangepicker.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/ionicons.min.css",
                      "~/Content/jquery-jvectormap.css",
                      "~/Content/morris.css",
                      "~/Content/googleFont.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/fullcalendar.min.css",
                      "~/Content/fullcalendar.print.min.css"));
        }
    }
}

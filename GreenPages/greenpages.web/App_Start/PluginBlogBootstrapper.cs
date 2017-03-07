﻿using System.Web.Optimization;
using GreenPages.WEb.Helpers;
using GreenPagesBlog.Repositories;
using GreenPagesBlog;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GreenPages.WEb.PluginBlogBootstrapper), "Start")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(GreenPages.WEb.PluginBlogBootstrapper), "PostStart")]
namespace GreenPages.WEb
{
    public class PluginBlogBootstrapper
    {
        public static void Start()
        {
            //Register a custom repository by implementing IBlogRepository 
            PluginBlogConfig.RegisterRepository = () => new BlogRepository(new BlogContext());

            //Register the authorization method used to access the blog admin area
            PluginBlogConfig.RegisterAuthorization = () =>
                                                     {
                                                         var authProvider = new SampleAuthProvider();
                                                         return authProvider;
                                                     };

        }

        //After App_Start is executed register the bundles
        public static void PostStart()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap", "http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.js").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/tinymce", "http://tinymce.cachefly.net/4.0/tinymce.min.js").Include("~/Scripts/tinymce/tinymce*"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/pluginblog").Include("~/Scripts/pluginblog.js"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap", "http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.css").Include("~/Content/bootstrap.css"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/pluginblog").Include("~/Content/pluginblog.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}


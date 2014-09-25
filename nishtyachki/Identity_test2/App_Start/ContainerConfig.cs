﻿using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.Unity;
using AdminApp.Infrastructure;
using AdminApp.QueueChannel;

namespace AdminApp.App_Start
{
    public static class ContainerConfig
    {
        public static void Config()
        {
            var container = new UnityContainer();
            MapTypes(container);

            // Set resolver to MVC.
            var controllerActivator = new UnityControllerActivator(container);
            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(controllerActivator));

            // Set resolver to WebApi.
            var httpControllerActivator = new UnityHttpControllerActivator(container);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), httpControllerActivator);

            // Set resolver to SignalR.
            var hubActivator = new UnityHubActivator(container);
            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => hubActivator);
        }

        private static void MapTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(IQueueChannel), typeof(QueueProxy));
        }
    }
}
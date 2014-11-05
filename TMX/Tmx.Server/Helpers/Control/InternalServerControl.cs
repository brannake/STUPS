﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/14/2014
 * Time: 9:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.Linq;
    using DotLiquid.NamingConventions;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using Nancy.Hosting.Self;
    using Nancy.Diagnostics;
    using Nancy.Json;
    using Nancy.Responses;
    using Nancy.Responses.Negotiation;
    using Nancy.TinyIoc;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.TestStructure;
    using Tmx.Server.Helpers.Control;
    using DotLiquid;
    
    /// <summary>
    /// Description of Control.
    /// </summary>
    public class InternalServerControl : DefaultNancyBootstrapper
    {
        static NancyHost _nancyHost;
        
        public static string Url { get; set; }
        
        public static void Start(string url)
        {
            Url = url;
            prepareComponents();
            loadModules();
            _nancyHost = new NancyHost(new Uri(url));
            setDotLiquidNamingConventions();
            registerTypes();
            loadPlugins();
			_nancyHost.Start();
//			JsonSettings.MaxJsonLength = Int32.MaxValue;
			// Nancy.Responses.JsonResponse..JsonSettings.MaxJsonLength
//			JsonSettings.MaxRecursions = 25;
//			JsonSettings.MaxJsonLength = 10000000;
        }
        
        public static void Stop()
        {
            Reset();
            _nancyHost.Stop();
        }
        
        public static void Reset()
        {
            ClientsCollection.Clients = new System.Collections.Generic.List<ITestClient>();
//            ClientsCollection.MaxUsedClientId = 0;
            TaskPool.TasksForClients = new System.Collections.Generic.List<ITestTask>();
            TaskPool.Tasks = new System.Collections.Generic.List<ITestTask>();
            // 20141030
            // CommonData.Data = new System.Collections.Generic.Dictionary<string, string>();
        }
        
        protected override DiagnosticsConfiguration DiagnosticsConfiguration {
            get {
                return new DiagnosticsConfiguration { Password = @"Tmx=admin" };
            }
        }
    	
    	protected override void ConfigureConventions(NancyConventions nancyConventions)
    	{
    	    // nancyConventions.StaticContentsConventions.Add(
    	    //     StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath(), "Root"));
    	    
    	    // TODO: to a separate assembly
    	    nancyConventions.StaticContentsConventions.Add(
    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"Views/Nwx", "Nwx"));
    	    
    	    nancyConventions.StaticContentsConventions.Add(
    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"Views/results", "results"));
    	    
    	    nancyConventions.StaticContentsConventions.Add(
    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + "Views/Scripts", @"Scripts", ".js"));
                
    	    nancyConventions.StaticContentsConventions.Add(
    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + "Views/settings", @"settings"));
                
    	    nancyConventions.StaticContentsConventions.Add(
    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + "Views/status", @"status"));
    	    
    		base.ConfigureConventions(nancyConventions);
    	}
    	
    	protected override IRootPathProvider RootPathProvider
    	{
    	    get { return new TmxServerRootPathProvider(); }
    	}
    	
        static void prepareComponents()
        {
            var testLabCollection = new TestLabCollection();
        }
        
        static void loadModules()
        {
            var modulesLoader = new ModulesLoader((new TmxServerRootPathProvider()).GetRootPath());
            modulesLoader.Load();
        }
        
        static void setDotLiquidNamingConventions()
        {
            Template.NamingConvention = new CSharpNamingConvention();
        }
        
        static void registerTypes()
        {
			Template.RegisterSafeType(typeof(TestSuite), new[] { "Id", "Name", "Status", "TestScenarios", "PlatformId" });
			Template.RegisterSafeType(typeof(TestScenario), new[] { "Id", "Name", "Status", "TestResults", "PlatformId" });
			Template.RegisterSafeType(typeof(TestResult), new[] { "Id", "Name", "Status", "Origin", "PlatformId" });
			Template.RegisterSafeType(typeof(ITestSuite), new[] { "Id", "Name", "Status", "TestScenarios", "PlatformId" });
			Template.RegisterSafeType(typeof(ITestScenario), new[] { "Id", "Name", "Status", "TestResults", "PlatformId" });
			Template.RegisterSafeType(typeof(ITestResult), new[] { "Id", "Name", "Status", "Origin", "PlatformId" });
			Template.RegisterSafeType(typeof(TestResultOrigins), member => member.ToString());
			
			Template.RegisterSafeType(typeof(TestWorkflow), new[] { "Id", "Name", "TestLabId", "Description" });
			Template.RegisterSafeType(typeof(TestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status" });
			Template.RegisterSafeType(typeof(TestRunStatuses), member => member.ToString());
			Template.RegisterSafeType(typeof(TestRunStartTypes), member => member.ToString());
			Template.RegisterSafeType(typeof(TestLab), new[] { "Id", "Name", "Description" });
			Template.RegisterSafeType(typeof(TestTask), new[] { "Id", "Name", "TaskStatus", "TaskResult" });
			
			Template.RegisterSafeType(typeof(Guid), member => member.ToString());
        }
        
        static void loadPlugins()
        {
            var pluginsLoader = new PluginsLoader((new TmxServerRootPathProvider()).GetRootPath() + @"\Plugins");
            pluginsLoader.Load();
        }
        
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.Caching.EnableRuntimeViewUpdates = true;
            StaticConfiguration.DisableErrorTraces = false;
            StaticConfiguration.EnableRequestTracing = true;
            JsonSettings.MaxJsonLength = int.MaxValue;
            // pipelines.BeforeRequest += ctx => { temporary_outputMethod(ctx, "BeforeRequest"); return null; };
            
            // pipelines.AfterRequest += ctx => { temporary_outputMethod(ctx, "AfterRequest"); return null; };
        }
        
        void temporary_outputMethod(NancyContext ctx, string state)
        {
            try { Console.WriteLine(state + " ControlPanelEnabled = " + ctx.ControlPanelEnabled); } catch {}
            try { Console.WriteLine(state + " Culture.DisplayName = " + ctx.Culture.DisplayName); } catch {}
            try { Console.WriteLine(state + " CurrentUser.UserName = " + ctx.CurrentUser.UserName); } catch {}
            try { 
                if (null != ctx.Items) {
                    foreach (var item in ctx.Items) {
                        Console.WriteLine(state + " Items " + item.Key + ": " + item.Value);
                    }
                }
            } catch {}
            try { Console.WriteLine(state + " ModelValidationResult.IsValid = " + ctx.ModelValidationResult.IsValid); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.ViewName = " + ctx.NegotiationContext.ViewName); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.ModuleName = " + ctx.NegotiationContext.ModuleName); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.ModulePath = " + ctx.NegotiationContext.ModulePath); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.Headers = " + ctx.NegotiationContext.Headers.Select(hdr => hdr.Value)); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.StatusCode = " + ctx.NegotiationContext.StatusCode); } catch {}
            try { Console.WriteLine(state + " ResolvedRoute = " + ctx.ResolvedRoute); } catch {}
            try { Console.WriteLine(state + " Text = " + ctx.Text); } catch {}
            try { Console.WriteLine(state + " ViewBag = " + ctx.ViewBag); } catch {}
        }
    }
}

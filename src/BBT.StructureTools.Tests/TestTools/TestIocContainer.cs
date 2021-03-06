﻿namespace BBT.StructureTools.Tests.TestTools
{
    using System;
    using BBT.StrategyPattern;
    using BBT.StructureTools.Initialization;
    using BBT.StructureTools.Tests.TestTools.IoC;
    using Ninject;

    /// <summary>
    /// Utilities to set up and configure for test runs.
    /// </summary>
    /// <remarks>
    /// Keep this code test framework-agnostic!.
    /// </remarks>
    public static class TestIocContainer
    {
        /// <summary>
        /// Register types for copy, convert, and compare with
        /// Ninject and create a resolver which is assigned to the
        /// <see cref="IocHandler.IocResolver"/>. The <see cref="INinjectContainer"/>
        /// which is used within the <see cref="IocHandler.IocResolver"/> is being
        /// returned for further manipulation from within the calling test or test setup method.
        /// </summary>
        public static IKernel Initialize()
        {
            var settings = new NinjectSettings();

            var kernel = new StandardKernel(settings);

            var resolver = new NinjectResolver(kernel);
            IocHandler.Instance.IocResolver = resolver;

            // Dependencies from BBT.StrategyPattern
            kernel.Bind(typeof(IStrategyLocator<>)).To(typeof(NinjectStrategyLocator<>));
            kernel.Bind(typeof(IInstanceCreator<,>)).To(typeof(GenericInstanceCreator<,>));

            IocHandler.Instance.DoIocRegistrations(
                (Type abstraction, Type implementation) =>
                    kernel.Bind(abstraction).To(implementation),
                (Type abstraction, Type implementation) =>
                    kernel.Bind(abstraction).To(implementation).InTransientScope());

            return kernel;
        }
    }
}

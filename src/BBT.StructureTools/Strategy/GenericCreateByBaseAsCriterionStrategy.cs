﻿namespace BBT.StructureTools.Strategy
{
    using BBT.StrategyPattern;
    using BBT.StructureTools.Extension;

    /// <inheritdoc/>
    internal class GenericCreateByBaseAsCriterionStrategy<TBaseInterface, TCriterion, TBaseTargetInterface, TInterface, TImpl> : ICreateByBaseAsCriterionStrategy<TBaseInterface, TBaseTargetInterface>
        where TImpl : TInterface, new()
        where TInterface : class, TBaseTargetInterface
    {
        private readonly IInstanceCreator<TInterface, TImpl> instanceCreator;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCreateByBaseAsCriterionStrategy{TBaseInterface, TCriterion, TConcreteInterface, TInterface, TImpl}"/> class.
        /// </summary>
        public GenericCreateByBaseAsCriterionStrategy(IInstanceCreator<TInterface, TImpl> instanceCreator)
        {
            instanceCreator.NotNull(nameof(instanceCreator));

            this.instanceCreator = instanceCreator;
        }

        /// <inheritdoc/>
        public TBaseTargetInterface CreateInstance()
        {
            var instance = this.instanceCreator.Create();
            return instance;
        }

        /// <inheritdoc/>
        public bool IsResponsible(TBaseInterface criterion)
        {
            return criterion is TCriterion;
        }
    }
}
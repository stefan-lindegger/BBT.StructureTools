﻿namespace BBT.StructureTools.Convert.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using BBT.StrategyPattern;
    using BBT.StructureTools;
    using BBT.StructureTools.Convert;
    using BBT.StructureTools.Extension;
    using BBT.StructureTools.Strategy;

    /// <inheritdoc/>
    internal class OperationConditionalCreateFromSourceWithReverseRelation<TSource, TTarget, TBaseSource, TBaseTarget, TIntention>
        : IOperationConditionalCreateFromSourceWithReverseRelation<TSource, TTarget, TBaseSource, TBaseTarget, TIntention>
            where TSource : class
            where TTarget : class
            where TBaseSource : class
            where TBaseTarget : class
            where TIntention : IBaseConvertIntention
    {
        private readonly IConvertStrategyProvider<TBaseSource, TBaseTarget, TIntention> convertStrategyProvider;
        private readonly IGenericStrategyProvider<ICreateByBaseAsCriterionStrategy<TBaseSource, TBaseTarget>, TBaseSource> instanceCreationStrategyProvider;

        /// <summary>
        /// Function which declares the base source value (e.g. LiBaseCover).
        /// </summary>
        private Func<TSource, TBaseSource> baseSourceFunc;

        /// <summary>
        /// Expression which declares the target value (created target class, e.g. LiClaimCover).
        /// </summary>
        private Expression<Func<TTarget, TBaseTarget>> targetValueExpression;

        /// <summary>
        /// Expression which declares the target parent (e.g. LiClaimCoverWrapper).
        /// </summary>
        private Expression<Func<TBaseTarget, TTarget>> targetParentExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationConditionalCreateFromSourceWithReverseRelation{TSource, TTarget, TTargetValue, TBaseTarget, TIntention}" /> class.
        /// </summary>
        public OperationConditionalCreateFromSourceWithReverseRelation(
            IConvertStrategyProvider<TBaseSource, TBaseTarget, TIntention> convertStrategyProvider,
            IGenericStrategyProvider<ICreateByBaseAsCriterionStrategy<TBaseSource, TBaseTarget>, TBaseSource> instanceCreationStrategyProvider)
        {
            convertStrategyProvider.NotNull(nameof(convertStrategyProvider));
            instanceCreationStrategyProvider.NotNull(nameof(instanceCreationStrategyProvider));

            this.convertStrategyProvider = convertStrategyProvider;
            this.instanceCreationStrategyProvider = instanceCreationStrategyProvider;
        }

        /// <inheritdoc/>
        public void Initialize(
            Func<TSource, TBaseSource> baseSourceFunc,
            Expression<Func<TTarget, TBaseTarget>> targetValueExpression,
            Expression<Func<TBaseTarget, TTarget>> targetParentExpression)
        {
            baseSourceFunc.NotNull(nameof(baseSourceFunc));
            targetValueExpression.NotNull(nameof(targetValueExpression));
            targetParentExpression.NotNull(nameof(targetParentExpression));

            this.baseSourceFunc = baseSourceFunc;
            this.targetValueExpression = targetValueExpression;
            this.targetParentExpression = targetParentExpression;
        }

        /// <inheritdoc/>
        public void Execute(
            TSource source,
            TTarget targetParent,
            ICollection<IBaseAdditionalProcessing> additionalProcessings)
        {
            source.NotNull(nameof(source));
            targetParent.NotNull(nameof(targetParent));

            var baseSource = this.baseSourceFunc(source);

            var instanceCreationStrategy = this.instanceCreationStrategyProvider.GetStrategy(baseSource);
            var target = instanceCreationStrategy.CreateInstance();

            var strategy = this.convertStrategyProvider.GetConvertStrategyFromSource(baseSource);

            // Sets reference to the child on the parent class
            targetParent.SetPropertyValue(this.targetValueExpression, target);

            // Sets reference to the parent on the child class
            target.SetPropertyValue(this.targetParentExpression, targetParent);

            strategy.Convert(baseSource, target, additionalProcessings);
        }
    }
}
